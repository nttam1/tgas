using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace T_Manager.Modal
{
    class MKho
    {
        public static IQueryable<T_Manager.KHO> Get(int type)
        {
            return DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == type);
        }
    }
}
