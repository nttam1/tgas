using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MKhachHang
    {
        private int MAKH;

        public MKhachHang(int MAKH)
        {
            this.MAKH = MAKH;
        }

        public double TongNo()
        {
            return TongNoHH() + TongNoVay() - TongThu();
        }
        public double NoHienTai()
        {
            return 0;
        }
        public double LaiHienTai()
        {
            return 0;
        }


        #region Thu Nợ
        public double ThuNo()
        {
            try
            {
                return (from tn in DataInstance.Instance().DBContext().THU_NO
                        where tn.MAKH == MAKH
                        select tn.TIEN_GOC
                                  ).Sum();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double ThuLai()
        {
            try
            {
                return (from tn in DataInstance.Instance().DBContext().THU_NO
                        where tn.MAKH == MAKH
                        select tn.TIEN_LAI
                                  ).Sum();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double TongThu()
        {
            try
            {
                return (from tn in DataInstance.Instance().DBContext().THU_NO
                        where tn.MAKH == MAKH
                        select tn.TIEN_GOC + tn.TIEN_LAI
                                  ).Sum();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Nợ Xuất Hàng
        public double TongNoHH()
        {
            return NoHHHienTai() + LaiHHHienTai();
        }


        public double No()
        {
            try
            {
                return (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                        where xh.MAKH == MAKH
                        select xh.SO_LUONG * xh.DON_GIA_BAN
                                  ).Sum();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double Lai()
        {
            try
            {
                var rows = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where xh.MAKH == MAKH
                            select new
                            {
                                days = xh.NGAY_XUAT.Value,
                                value = xh.SO_LUONG * xh.DON_GIA_BAN * xh.LAI_SUAT / 3000
                            });
                double total = 0;
                foreach (var r in rows)
                {
                    total += DateTime.Now.Subtract(r.days).TotalDays * r.value;
                }
                return total;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double NoHHHienTai()
        {
            return No() - ThuNo();
        }

        public double LaiHHHienTai()
        {
            return Lai() - ThuLai();
        }
        #endregion

        #region Nợ Vay
        public double NoVayHienTai()
        {
            return 0;
        }

        public double LaiVayHienTai()
        {
            return 0;
        }

        public double TongNoVay()
        {
            return NoVayHienTai() + LaiVayHienTai();
        }

        #endregion
    }
}