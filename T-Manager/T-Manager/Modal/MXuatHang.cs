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
        }

    }
}