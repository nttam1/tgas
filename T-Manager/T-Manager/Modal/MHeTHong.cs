using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MHeTHong
    {
        public const string MATKHAU = "PASSWORD";

        public static bool IsSet(string NAME)
        {
            try
            {
                var ht = DataInstance.Instance().DBContext().HE_THONG.Where(u => u.NAME == NAME).First();
                if (ht != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string Get(string NAME)
        {
            if (IsSet(NAME) == true)
            {
                return DataInstance.Instance().DBContext().HE_THONG.Where(u => u.NAME == NAME).First().VALUE;
            }
            else
            {
                return null;
            }
        }

        public static void Set(string NAME, string VALUE)
        {
            try
            {
                var ht = DataInstance.Instance().DBContext().HE_THONG.Where(u => u.NAME == NAME).First();
                foreach (HE_THONG row in DataInstance.Instance().DBContext().HE_THONG.Where(u => u.NAME == NAME))
                {
                    row.VALUE = VALUE;
                    break;
                }
            }
            catch (Exception ex)
            {
                HE_THONG ht = new HE_THONG();
                ht.NAME = NAME;
                ht.VALUE = VALUE;
                DataInstance.Instance().DBContext().AddToHE_THONG(ht);
            }
            DataInstance.Instance().DBContext().SaveChanges();
        }
    }
}
