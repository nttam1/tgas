using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MNcc
    {
        public static IQueryable<T_Manager.NHA_CUNG_CAP> Get()
        {
            return DataInstance.Instance().DBContext().NHA_CUNG_CAP;
        }

        public static long TraNoTO(long MANCC, DateTime TO)
        {
            long value = 0;
            TO = TO.Date;
            try
            {
                value = DataInstance.Instance().DBContext().TRA_NO_NCC
                    .Where(u => u.MANCC == MANCC && u.NGAY_TRA < TO)
                    .Sum(u => u.TONG_TIEN);
            }
            catch (Exception ex)
            {

            }
            return value;
        }

        public static long NoTO(long MANCC, DateTime TO)
        {
            long value = 0;
            TO = TO.Date;
            try
            {
                value = DataInstance.Instance().DBContext().NHAP_HANG
                    .Where(u => u.MANCC == MANCC && u.NGAY_NHAP < TO)
                    .Sum(u => u.SO_LUONG * u.DON_GIA_MUA);
            }
            catch (Exception ex)
            {

            }
            return value;
        }
    }
}
