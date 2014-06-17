using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MHangHoa
    {
        public static IQueryable<T_Manager.HANG_HOA> Get()
        {
            return DataInstance.Instance().DBContext().HANG_HOA;
        }

        public static HANG_HOA GetByID(long ID)
        {
            try
            {
                return DataInstance.Instance().DBContext().HANG_HOA.Where(u => u.ID == ID).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetNameByID(long ID)
        {
            try
            {
                return DataInstance.Instance().DBContext().HANG_HOA.Where(u => u.ID == ID).First().NAME;
            }
            catch (Exception ex)
            {
                return "Cho vay";
            }
        }

        public static long GetIDbyName(string NAME)
        {
            try
            {
                return DataInstance.Instance().DBContext().HANG_HOA.Where(u => u.NAME == NAME).First().ID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
