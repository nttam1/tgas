using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager
{
    public class Utility
    {
        public static string StringToVND(string input){
            return string.Format("{0:#,##0 VND}", double.Parse(input));
        }
    }
}
