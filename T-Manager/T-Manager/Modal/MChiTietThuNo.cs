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
