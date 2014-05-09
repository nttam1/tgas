using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager
{
    class DataInstance
    {
        private static DataInstance _this = null;

        public static DataInstance Instance()
        {
            if (_this == null)
            {
                _this = new DataInstance();
            }
            return _this;
        }

        private tgasEntities dbContext = null;

        public DataInstance()
        {
            dbContext = new tgasEntities();
        }

        public tgasEntities DBContext()
        {
            return dbContext;
        }
    }
}
