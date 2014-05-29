using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MVay
    {
        public static List<object> ThoiDoan()
        {
            List<object> l = new List<object>();
            l.Add(new { NAME = "1 Tháng", VALUE = 1 });
            l.Add(new { NAME = "2 Tháng", VALUE = 2 });
            l.Add(new { NAME = "3 Tháng", VALUE = 3 });
            l.Add(new { NAME = "6 Tháng", VALUE = 6 });
            l.Add(new { NAME = "9 Tháng", VALUE = 9 });
            l.Add(new { NAME = "12 Tháng", VALUE = 12 });
            l.Add(new { NAME = "24 Tháng", VALUE = 24 });
            l.Add(new { NAME = "36 Tháng", VALUE = 36 });
            return l;
        }
    }

    class CThoiDoan
    {
        public string NAME;
        public int VALUE;
    }

}
