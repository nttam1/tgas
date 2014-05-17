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

    }
}
