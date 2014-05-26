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

        /// <summary>
        /// Tính lãi đơn đến ngày hiện tại
        /// </summary>
        /// <param name="start_date"></param>
        /// <param name="lai_suat"></param>
        /// <param name="tong_tien"></param>
        /// <returns></returns>
        public static double Lai(DateTime start_date, double lai_suat, double tong_tien)
        {
            ///double value = (DateTime.Now.Date - start_date.Date).Days * lai_suat / ConstClass.NGAY_TINH_LAI;
            ///return tong_tien * value;
            return Lai(start_date, DateTime.Now, lai_suat, tong_tien);
        }

        /// <summary>
        /// Tính lãi đơn từ ngày đến ngày
        /// </summary>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="lai_suat"></param>
        /// <param name="tong_tien"></param>
        /// <returns></returns>
        public static double Lai(DateTime start_date, DateTime end_date, double lai_suat, double tong_tien)
        {
            double value = (end_date.Date - start_date.Date).Days * lai_suat / ConstClass.NGAY_TINH_LAI;
            return tong_tien * value;
        }

        /// <summary>
        /// Tính lãi kép đến ngày hiện tại
        /// hien_tai: Tính lãi đến ngày hiện tại hoặc tính lãi đá phát sinh
        /// </summary>
        /// <param name="start_date"></param>
        /// <param name="lai_suat"></param>
        /// <param name="tong_tien"></param>
        /// <param name="chi_tiet_thu_no"></param>
        /// <returns></returns>
        public static double LaiKep(DateTime start_date, double lai_suat, double tong_tien, IQueryable<CHI_TIET_THU_NO> chi_tiet_thu_no, bool hien_tai = true)
        {
            return LaiKep(start_date, DateTime.Now, lai_suat, tong_tien, chi_tiet_thu_no, hien_tai);
        }

        /// <summary>
        /// TÍnh lãi kép từ ngày đến ngày
        /// </summary>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="lai_suat"></param>
        /// <param name="tong_tien"></param>
        /// <param name="chi_tiet_thu_no"></param>
        /// <returns></returns>
        public static double LaiKep(DateTime start_date, DateTime end_date,double lai_suat, double tong_tien, IQueryable<CHI_TIET_THU_NO> chi_tiet_thu_no, bool hien_tai = true)
        {
            double value = 0;
            DateTime _ngay_no = start_date.Date;
            double _tong_no_hien_tai = tong_tien;
            foreach (CHI_TIET_THU_NO tn in chi_tiet_thu_no)
            {
                if (hien_tai == true)
                {
                    value += Utility.Lai(_ngay_no, tn.NGAY_TRA, lai_suat, _tong_no_hien_tai) - tn.TIEN_LAI;
                }
                else
                {
                    value += Utility.Lai(_ngay_no, tn.NGAY_TRA, lai_suat, _tong_no_hien_tai);
                }
                _ngay_no = tn.NGAY_TRA;
                _tong_no_hien_tai -= tn.TIEN_GOC;
            }
            value += Utility.Lai(_ngay_no, end_date, lai_suat, _tong_no_hien_tai);
            return value;
        }
    }
}
