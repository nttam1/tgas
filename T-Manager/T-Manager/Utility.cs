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

        public static double Lai(DateTime start_date, double lai_suat, double tong_tien)
        {
            double value = (DateTime.Now.Date - start_date.Date).Days * lai_suat / ConstClass.NGAY_TINH_LAI;
            return tong_tien * value;
        }

        public static double Lai(DateTime start_date, DateTime end_date, double lai_suat, double tong_tien)
        {
            double value = (end_date.Date - start_date.Date).Days * lai_suat / ConstClass.NGAY_TINH_LAI;
            return tong_tien * value;
        }
    }
}
