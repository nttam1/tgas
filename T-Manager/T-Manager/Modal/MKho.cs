using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace T_Manager.Modal
{
    class MKho
    {
        public const int KHO_HANG = 0;
        public const int KHO_TK_NGANHANG = 1;
        public const int KHO_QUY = 2;

        public static IQueryable<T_Manager.KHO> Get(int type)
        {
            return DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == type);
        }
    }
}
