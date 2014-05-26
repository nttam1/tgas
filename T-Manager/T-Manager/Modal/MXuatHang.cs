using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MXuatHang
    {
        public const int CHUA_TRA_XONG = 0;
        public const int DA_TRA_XONG = 1;
        /// <summary>
        /// Trừ số lượng xuất hàng vào số lượng còn lại của nhập hàng
        /// </summary>
        /// <param name="_SoLuong">Số lượng xuất hàng</param>
        /// <param name="ele">Object Xuất hàng</param>
        public static void Update(long _SoLuong, XUAT_HANG ele)
        {
            foreach (var row in DataInstance.Instance().DBContext().NHAP_HANG
                .Where(u => u.MAKHO == ele.MAKHO)
                .Where(u => u.MAHH == ele.MAHH)
                .OrderBy(u => u.NGAY_NHAP))
            {
                var sub_SL = row.SL_CON_LAI;
                row.SL_CON_LAI = _SoLuong >= row.SL_CON_LAI ? 0 : row.SL_CON_LAI - _SoLuong;
                _SoLuong = _SoLuong >= sub_SL ? _SoLuong - sub_SL : 0;
                if (_SoLuong == 0)
                {
                    break;
                }
            }
            DataInstance.Instance().DBContext().SaveChanges();
        }

        /// <summary>
        /// Tính lãi hiện tại của xuất hàng theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include_THUNO"></param>
        /// <returns></returns>
        public static double GetLai(int id, bool include_THUNO = true)
        {
            double value = 0;
            XUAT_HANG xh = (from _xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where _xh.ID == id
                            select _xh).First();
            /* Sử dụng chi tiết thu nợ để tính lãi */
            if (include_THUNO == true)
            {
                /* Những lần khách hàng đã trả cho phần nợ xuất hàng này */
                var thu_no_s = MChiTietThuNo.BelongTo(xh);
                value = Utility.LaiKep((DateTime)xh.NGAY_XUAT, xh.LAI_SUAT, xh.SO_LUONG * xh.DON_GIA_BAN, thu_no_s);

            }
            /* Không sử dụng chi tiết thu nợ */
            else
            {               
                value = Utility.Lai(xh.NGAY_XUAT.Value, xh.LAI_SUAT, xh.SO_LUONG * xh.DON_GIA_BAN);
            }
            return value;
        }

        /// <summary>
        /// Tính lãi phát sinh của xuất hàng theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include_THUNO"></param>
        /// <returns></returns>
        public static double GetLaiPhatSinh(int id, bool include_THUNO = true)
        {
            double value = 0;
            XUAT_HANG xh = (from _xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where _xh.ID == id
                            select _xh).First();
            /* Sử dụng chi tiết thu nợ để tính lãi */
            if (include_THUNO == true)
            {
                /* Những lần khách hàng đã trả cho phần nợ xuất hàng này */
                var thu_no_s = MChiTietThuNo.BelongTo(xh);
                value = Utility.LaiKep((DateTime)xh.NGAY_XUAT, xh.LAI_SUAT, xh.SO_LUONG * xh.DON_GIA_BAN, thu_no_s, false);

            }
            /* Không sử dụng chi tiết thu nợ */
            else
            {
                value = Utility.Lai(xh.NGAY_XUAT.Value, xh.LAI_SUAT, xh.SO_LUONG * xh.DON_GIA_BAN);
            }
            return value;
        }
        public static double GetNo(int id, bool include_THUNO = true)
        {
            double value = 0;
            return value;
        }
    }
}