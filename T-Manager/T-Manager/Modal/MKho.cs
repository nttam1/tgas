using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using T_Manager.REPORT;

namespace T_Manager.Modal
{
    class MKho
    {
        public const int KHO_HANG = 0;
        public const int KHO_TK_NGANHANG = 1;
        public const int KHO_QUY = 2;

        /// <summary>
        /// SỐ LƯỢNG HÀNG HÓA CÒN LẠI TRONG KHO
        /// </summary>
        /// <param name="MAKHO"></param>
        /// <param name="MAHH"></param>
        /// <returns></returns>
        public static long Ton(long MAKHO, long MAHH)
        {
            long value = 0;
            try
            {
                value = (from ton in DataInstance.Instance().DBContext().NHAP_HANG
                         where ton.MAKHO == MAKHO
                         where ton.MAHH == MAHH
                         select ton.SL_CON_LAI).Sum();
            }
            catch (Exception ex)
            {

            }
            return value;
        }

        public static IQueryable<T_Manager.KHO> Get(int type)
        {
            return DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == type);
        }

        /// <summary>
        /// TÍNH TỔNG TIỀN HIỆN TẠI CÓ TRONG KHO QUỸ
        /// TỔNG THU - TỔNG CHI - TIỀN ĐÃ CHUYỂN VÀO TÀI KHOẢN
        /// </summary>
        /// <param name="TO"></param>
        /// <returns></returns>
        public static long Tong_Tien_Hien_Tai(DateTime TO)
        {
            long value = 0;
            TO = TO.Date;
            DateTime FROM = new DateTime(1991, 12, 25);

            /* THU - CHI CỦA TẤT CẢ CÁC KHO */
            foreach (KHO kho in (from _kho in DataInstance.Instance().DBContext().KHOes select _kho))
            {
                value += Total_Thu(kho.ID, FROM, TO) + Total_Chi(kho.ID, FROM, TO);
            }
            /* TRỪ TỔNG TIỀN ĐÃ CHUYỂN VÀO TÀI KHOẢN */

            long tchuyen = 0;
            try
            {
                tchuyen = (from c in DataInstance.Instance().DBContext().CHUYEN_TIEN
                           where c.NGAY_CHUYEN <= TO
                           select c.TONG_TIEN).Sum();
            }
            catch (Exception ex)
            {

            }

            value = value - tchuyen;

            return value;
        }

        /// <summary>
        /// TỔNG TIỀN KHO THU VÀO
        /// + TIỀN BÁN HÀNG, XUẤT HÀNG
        /// + TIỀN THU NỢ - đã bao gồm thu nợ và thu khác
        /// </summary>
        /// <param name="MAKHO"></param>
        /// <param name="FROM"></param>
        /// <param name="TO"></param>
        /// <returns></returns>
        public static long Total_Thu(long MAKHO, DateTime FROM, DateTime TO)
        {
            long banhang = 0;
            long xuathang = 0;
            long thuno = 0;
            FROM = FROM.Date;
            TO = TO.Date;

            try
            {
                banhang = (from _luong in DataInstance.Instance().DBContext().BAN_HANG
                           where _luong.MAKHO == MAKHO
                           where _luong.NGAY_BAN >= FROM && _luong.NGAY_BAN <= TO
                           select _luong.SO_LUONG * _luong.DON_GIA_BAN).Sum();
            }
            catch (Exception ex) { }

            try
            {
                xuathang = (from _luong in DataInstance.Instance().DBContext().XUAT_HANG
                           where _luong.MAKHO == MAKHO
                           where _luong.NGAY_XUAT >= FROM && _luong.NGAY_XUAT <= TO
                           select _luong.SO_LUONG * _luong.DON_GIA_BAN).Sum();
            }
            catch (Exception ex) { }

            try
            {
                thuno = (from _luong in DataInstance.Instance().DBContext().THU_NO
                            where _luong.MAKHO == MAKHO
                            where _luong.NGAY_TRA >= FROM && _luong.NGAY_TRA <= TO
                            select _luong.TIEN_GOC +  _luong.TIEN_LAI).Sum();
            }
            catch (Exception ex) { }
            return xuathang + banhang + thuno;
        }



        /// <summary>
        /// TỔNG SỐ TIỀN MÀ KHO CHI RA
        /// + CHI LƯƠNG
        /// + CHI KHÁC
        /// + CHI NỘI BỘ
        /// + CHO VAY
        /// + CHI KHÁC
        /// </summary>
        /// <param name="MAKHO"></param>
        /// <param name="FROM"></param>
        /// <param name="TO"></param>
        /// <returns></returns>
        public static long Total_Chi(long MAKHO, DateTime FROM, DateTime TO)
        {
            long _kho = MAKHO;
            DateTime _from = FROM.Date;
            DateTime _to = TO.Date;
            long luong = 0;
            long noibo = 0;
            long khac = 0;
            long chovay = 0;
            long chikhac = 0;

            try
            {
                luong = (from _luong in DataInstance.Instance().DBContext().CHI_LUONG
                         join _nv in DataInstance.Instance().DBContext().NHAN_VIEN on _luong.MANV equals _nv.ID
                         where _luong.MAKHO == _kho
                         where _luong.NGAY_CHI >= _from && _luong.NGAY_CHI <= _to
                         select _luong.TONG_TIEN).Sum();
            }
            catch (Exception ex) { }

            try
            {
                noibo = (from _chi in DataInstance.Instance().DBContext().CHI_TIEU_DUNG_NOI_BO
                         join _xe in DataInstance.Instance().DBContext().XEs on _chi.MAXE equals _xe.ID
                         where _chi.MAKHO == _kho
                         where _chi.NGAY_CHI >= _from && _chi.NGAY_CHI <= _to
                         select _chi.SO_LUONG * _chi.DON_GIA_BAN).Sum();
            }
            catch (Exception ex) { }

            try
            {
                khac = (from _luong in DataInstance.Instance().DBContext().CHI_KHAC
                        where _luong.MAKHO == _kho
                        where _luong.NGAY_CHI >= _from && _luong.NGAY_CHI <= _to
                         select _luong.TONG_TIEN).Sum();
            }
            catch (Exception ex) { }

            try
            {
                chovay = (from _luong in DataInstance.Instance().DBContext().CHO_VAY
                          where _luong.MAKHO == _kho
                          where _luong.NGAY_CHO_VAY >= _from && _luong.NGAY_CHO_VAY <= _to
                          select _luong.TONG_TIEN).Sum();
            }
            catch (Exception ex)
            {
            }

            try
            {
                chikhac = (from _luong in DataInstance.Instance().DBContext().CHI_KHAC
                          where _luong.MAKHO == _kho
                          where _luong.NGAY_CHI >= _from && _luong.NGAY_CHI <= _to
                          select _luong.TONG_TIEN).Sum();
            }
            catch (Exception ex)
            {
            }

            return luong + noibo + khac + chovay;
        }

        public static long Total_Nhap_To(long KHO_ID, DateTime TO, bool INCLUDE_TODAY = false, long MAHH = 0)
        {
            DateTime FROM = new DateTime(1991, 12, 25);
            return Total_Nhap_To(KHO_ID, FROM, TO, INCLUDE_TODAY, MAHH);
        }

        public static long Total_Xuat_To(long KHO_ID, DateTime TO, bool INCLUDE_TODAY = false, long MAHH = 0)
        {
            DateTime FROM = new DateTime(1991, 12, 25);
            return Total_Xuat_To(KHO_ID, FROM, TO, INCLUDE_TODAY, MAHH);
        }

        /// <summary>
        /// Tính tổng số lượng đã nhập vào kho
        /// </summary>
        /// <param name="KHO_ID"></param>
        /// <param name="TO"></param>
        /// <param name="INCLUDE_TODAY">true: tính luôn cả ngày đang tính</param>
        /// <param name="MAHH">0: tất cả hàng hóa</param>
        /// <returns></returns>
        public static long Total_Nhap_To(long KHO_ID, DateTime FROM, DateTime TO, bool INCLUDE_TODAY = false, long MAHH = 0)
        {
            long value = 0;
            long _MAFrom = MAHH;
            long _MATo = MAHH;
            FROM = FROM.Date;
            TO = TO.Date;
            if (INCLUDE_TODAY == false)
            {
                TO = TO.AddDays(-1);
            }
            try
            {
                if (MAHH == 0)
                {
                    _MAFrom = 1;
                    _MATo = (from _n in DataInstance.Instance().DBContext().HANG_HOA select _n.ID).Max();
                }
                value = (from _n in DataInstance.Instance().DBContext().NHAP_HANG
                         where _n.MAKHO == KHO_ID
                         where _n.NGAY_NHAP >= FROM && _n.NGAY_NHAP <= TO
                         where _n.MAHH >= _MAFrom && _n.MAHH <= _MATo
                         select _n.SO_LUONG).Sum();
            }
            catch (Exception ex)
            {

            }
            return value;
        }

        /// <summary>
        /// Tổng số lượng xuất hàng
        /// </summary>
        /// <param name="KHO_ID"></param>
        /// <param name="TO"></param>
        /// <param name="INCLUDE_TODAY">true: tính luôn cả ngày đang tính</param>
        /// <param name="MAHH">0: tất cả hàng hóa</param>
        /// <returns></returns>
        public static long Total_Xuat_To(long KHO_ID, DateTime FROM, DateTime TO, bool INCLUDE_TODAY = false, long MAHH = 0)
        {
            long value = 0;
            long _MAFrom = MAHH;
            long _MATo = MAHH;
            FROM = FROM.Date;
            TO = TO.Date;
            if (INCLUDE_TODAY == false)
            {
                TO = TO.AddDays(-1);
            }
            try
            {
                if (MAHH == 0)
                {
                    _MAFrom = 1;
                    _MATo = (from _n in DataInstance.Instance().DBContext().HANG_HOA select _n.ID).Max();
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                value = (from _n in DataInstance.Instance().DBContext().XUAT_HANG
                         where _n.MAKHO == KHO_ID
                         where _n.NGAY_XUAT >= FROM && _n.NGAY_XUAT <= TO
                         where _n.MAHH >= _MAFrom && _n.MAHH <= _MATo
                         select _n.SO_LUONG).Sum();
            }
            catch (Exception ex)
            {

            } try
            {
                value += (from _n in DataInstance.Instance().DBContext().BAN_HANG
                          where _n.MAKHO == KHO_ID
                          where _n.NGAY_BAN >= FROM && _n.NGAY_BAN <= TO
                          where _n.MAHH >= _MAFrom && _n.MAHH <= _MATo
                          select _n.SO_LUONG).Sum();
            }
            catch (Exception ex)
            {

            }
            return value;
        }


        /// <summary>
        /// Tính tồn đầu kì số lượng hàng hóa trong kho
        /// </summary>
        /// <param name="KHO_ID"></param>
        /// <param name="TO"></param>
        /// <param name="MAHH">0: tất cả hàng hóa</param>
        /// <returns></returns>
        public static long TON_DAU(long KHO_ID, DateTime TO, long MAHH = 0)
        {
            long value = 0;
            value = Total_Nhap_To(KHO_ID, TO, false, MAHH) - Total_Xuat_To(KHO_ID, TO, false, MAHH);
            return value;
        }

        /// <summary>
        /// Tính tồn cuối kì số lượng hàng hóa trong kho
        /// </summary>
        /// <param name="KHO_ID"></param>
        /// <param name="TO"></param>
        /// <param name="MAHH">0: tất cả hàng hóa</param>
        /// <returns></returns>
        public static long TON_CUOI(long KHO_ID, DateTime TO, long MAHH = 0)
        {
            long value = 0;
            long nhap = Total_Nhap_To(KHO_ID, TO, true, MAHH);
            long xuat = Total_Xuat_To(KHO_ID, TO, true, MAHH);
            value = nhap - xuat;
            return value;
        }
    }
}
