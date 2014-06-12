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
