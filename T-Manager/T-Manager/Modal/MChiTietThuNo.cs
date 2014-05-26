using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MChiTietThuNo
    {
        public const int CHUA_TRA_XONG = 0;
        public const int TRA_XONG = 1;

        /// <summary>
        /// Tổng tiền mà khách hàng đã trả cho lần xuất hàng có ID = _ID_
        /// </summary>
        /// <param name="xuat_hang_ID"></param>
        /// <returns></returns>
        public static double DaTraHH(int xuat_hang_ID)
        {
            return TraGocHH(xuat_hang_ID) + TraLaiHH(xuat_hang_ID);
        }

        /// <summary>
        /// Tổng gốc hàng hóa mà khách hàng đã trả
        /// </summary>
        /// <param name="xuat_hang_ID"></param>
        /// <returns></returns>
        public static double TraGocHH(int xuat_hang_ID)
        {
            double value = 0;
            try
            {
                value = (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                        where cttn.LOAI_NO == MThuNo.NO_HANG_HOA
                        where cttn.NO_ID == xuat_hang_ID
                        select cttn.TIEN_GOC).Sum();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        /// <summary>
        /// Tổng lãi HH mà khách hàng đã trả
        /// </summary>
        /// <param name="xuat_hang_ID"></param>
        /// <returns></returns>
        public static double TraLaiHH(int xuat_hang_ID)
        {
            double value = 0;
            try
            {
                value = (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                         where cttn.LOAI_NO == MThuNo.NO_HANG_HOA
                         where cttn.NO_ID == xuat_hang_ID
                         select cttn.TIEN_LAI).Sum();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public static IQueryable<CHI_TIET_THU_NO> BelongTo(XUAT_HANG xh)
        {
            return (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                    where cttn.LOAI_NO == MThuNo.NO_HANG_HOA
                    where cttn.NO_ID == xh.ID
                    select cttn);
        }

        public static IQueryable<CHI_TIET_THU_NO> BelongTo(CHO_VAY cv)
        {
            return (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                    where cttn.LOAI_NO == MThuNo.NO_VAY
                    where cttn.NO_ID == cv.ID
                    select cttn);
        }


    }
}
