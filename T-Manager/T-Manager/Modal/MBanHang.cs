using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MBanHang
    {
        /// <summary>
        /// Bán hàng và cập nhật số lượng hàng hóa tồn kho
        /// </summary>
        /// <param name="MAKHO"></param>
        /// <param name="MAHH"></param>
        /// <param name="SOLUONG"></param>
        /// <param name="DONGIABAN"></param>
        /// <param name="NGAYBAN"></param>
        public static void Creat(long MAKHO, long MAHH, long SOLUONG, long DONGIABAN, DateTime NGAYBAN)
        {
            /* Tạo mới record bán hàng */
            BAN_HANG bh = new BAN_HANG();
            bh.MAKHO = MAKHO;
            bh.MAHH = MAHH;
            bh.SO_LUONG = SOLUONG;
            bh.DON_GIA_BAN = DONGIABAN;
            bh.NGAY_BAN = NGAYBAN.Date;
            bh.CREATED_TIME = DateTime.Now;
            DataInstance.Instance().DBContext().AddToBAN_HANG(bh);
            DataInstance.Instance().DBContext().SaveChanges();

            /* Cập nhật số lượng tồn kho */
            long _soluong = bh.SO_LUONG;
            foreach (NHAP_HANG nh in (from _nh in DataInstance.Instance().DBContext().NHAP_HANG
                                      where _nh.SL_CON_LAI > 0
                                      where _nh.MAHH == bh.MAHH
                                      orderby _nh.NGAY_NHAP ascending
                                      select _nh))
            {
                var sub_SL = nh.SL_CON_LAI;
                nh.SL_CON_LAI = _soluong >= nh.SL_CON_LAI ? 0 : nh.SL_CON_LAI - _soluong;
                _soluong = _soluong >= sub_SL ? _soluong - sub_SL : 0;
                DataInstance.Instance().DBContext().SaveChanges();
                if (_soluong == 0)
                {
                    break;
                }
            }
        }
    }
}
