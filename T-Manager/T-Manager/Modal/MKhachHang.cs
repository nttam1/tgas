using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MKhachHang
    {
        private int MAKH = -1;
        private int MAKHO = -1;

        public MKhachHang(int MAKH)
        {
            this.MAKH = MAKH;
        }

        public MKhachHang(int MAKH, int MAKHO)
        {
            this.MAKH = MAKH;
            this.MAKHO = MAKHO;
        }

        #region Relationship
        /// <summary>
        /// Cập nhật tiền đã trả vào Xuất Hàng hoặc Cho Vay
        /// </summary>
        /// <param name="_TienGoc"></param>
        /// <param name="_TienLai"></param>
        /// <param name="ele"></param>
        public void CapNhatNo(long _TienGoc, double _TienLai, THU_NO ele)
        {
            if (ele.LOAI_NO == MThuNo.THU_NO_HH)
            {
                // Xuat Hang
                int _break = 0;
                while (_break == 0)
                {
                    XUAT_HANG xuat_hang;
                    if (MAKHO == -1)
                    {
                        xuat_hang = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                     where xh.MAKH == MAKH
                                     where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                                     orderby xh.NGAY_XUAT
                                     select xh).First();
                    }
                    else
                    {
                        xuat_hang = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                     where xh.MAKH == MAKH
                                     where xh.MAKHO == MAKHO
                                     where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                                     orderby xh.NGAY_XUAT
                                     select xh).First();
                    }
                    var conno = xuat_hang.SO_LUONG * xuat_hang.DON_GIA_BAN - xuat_hang.TRA_TRUOC - (long)xuat_hang.DA_TRA;
                    var laino = (DateTime.Now - (DateTime)xuat_hang.NGAY_XUAT).Days * conno * xuat_hang.LAI_SUAT / 3000;
                    if (_TienLai + _TienGoc >= conno + laino)
                    {
                        xuat_hang.DA_TRA += conno + laino;
                        xuat_hang.TRA_XONG = 1;
                        _TienLai = _TienLai - laino;
                        _TienGoc = _TienGoc - conno;
                        if (_TienGoc == 0 && _TienLai == 0)
                        {
                            _break = -1;
                        }
                    }
                    else
                    {
                        xuat_hang.DA_TRA += _TienLai + _TienGoc;
                        _break = -1;
                    }
                    xuat_hang.NGAY_TRA = DateTime.Now;
                    DataInstance.Instance().DBContext().SaveChanges();
                }
            }
            else
            {
                // Cho vay
                int _break = 0;
                while (_break == 0)
                {
                    T_Manager.CHO_VAY cv;
                    if (MAKHO == -1)
                    {
                        cv = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                              where xh.MA_NGUON_NO == MAKH
                              where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                              orderby xh.NGAY_CHO_VAY
                              select xh).First();
                    }
                    else
                    {
                        cv = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                              where xh.MA_NGUON_NO == MAKH
                              where xh.MAKHO == MAKHO
                              where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                              orderby xh.NGAY_CHO_VAY
                              select xh).First();
                    }
                    var conno = cv.TONG_TIEN - (long)cv.DA_TRA;
                    var laino = (DateTime.Now - (DateTime)cv.NGAY_CHO_VAY).Days * conno * cv.LAI_SUAT / 3000;
                    if (_TienLai + _TienGoc >= conno + laino)
                    {
                        cv.DA_TRA += conno + laino;
                        cv.TRA_XONG = 1;
                        _TienLai = _TienLai - laino;
                        _TienGoc = _TienGoc - conno;
                        if (_TienGoc == 0 && _TienLai == 0)
                        {
                            _break = -1;
                        }
                    }
                    else
                    {
                        cv.DA_TRA += _TienLai + _TienGoc;
                        _break = -1;
                    }
                    cv.NGAY_TRA = DateTime.Now;
                    DataInstance.Instance().DBContext().SaveChanges();
                }
            }
        }
        #endregion

        #region Get
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
        #endregion

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

        public double NoHHHienTai()
        {
            try
            {
                if (MAKHO == -1)
                {
                    return (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where xh.MAKH == MAKH
                            where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                            select xh.SO_LUONG * xh.DON_GIA_BAN - (double)xh.DA_TRA - xh.TRA_TRUOC
                                      ).Sum();

                }
                else
                {
                    return (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where xh.MAKH == MAKH
                            where xh.MAKHO == MAKHO
                            where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                            select xh.SO_LUONG * xh.DON_GIA_BAN - (double)xh.DA_TRA - xh.TRA_TRUOC
                                      ).Sum();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double LaiHHHienTai()
        {
            try
            {
                IQueryable<XUAT_HANG> rows = null;
                if (MAKHO == -1)
                {
                    rows = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where xh.MAKH == MAKH
                            where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                            select xh);
                }
                else
                {
                    rows = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where xh.MAKH == MAKH
                            where xh.MAKHO == MAKHO
                            where xh.TRA_XONG == MXuatHang.CHUA_TRA_XONG
                            select xh);

                }
                double total = 0;
                foreach (var r in rows)
                {
                    var thanhtien_A = r.SO_LUONG * r.DON_GIA_BAN;
                    var thanhtien_B = r.SO_LUONG * r.DON_GIA_BAN - r.DA_TRA.Value;
                    var ngay_tra = r.NGAY_TRA.Value.Date;
                    var ngay_xuat = r.NGAY_XUAT.Value.Date;
                    var now = DateTime.Now.Date;
                    var n_ngay_A = (ngay_tra - ngay_xuat).Days;
                    var n_ngay_B = (now - ngay_tra).Days; ;
                    total += (thanhtien_A * r.LAI_SUAT * n_ngay_A / 3000) +  (thanhtien_B * r.LAI_SUAT * n_ngay_B / 3000);
                }
                return total;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Nợ Vay
        public double NoVayHienTai()
        {
            if (MAKHO == -1)
            {
                return (from novay in DataInstance.Instance().DBContext().CHO_VAY
                        where novay.MA_NGUON_NO == MAKH
                        where novay.TRA_XONG == MChoVay.CHUA_TRA_XONG
                        select novay.TONG_TIEN - (double)novay.DA_TRA).Sum();
            }
            else
            {
                return (from novay in DataInstance.Instance().DBContext().CHO_VAY
                        where novay.MA_NGUON_NO == MAKH
                        where novay.MAKHO == MAKHO
                        where novay.TRA_XONG == MChoVay.CHUA_TRA_XONG
                        select novay.TONG_TIEN - (double)novay.DA_TRA).Sum();
            }
        }

        public double LaiVayHienTai()
        {
            double sum = 0;
            IQueryable<T_Manager.CHO_VAY> nos = null;
            if (MAKHO == -1)
            {
                nos = (from novay in DataInstance.Instance().DBContext().CHO_VAY
                       where novay.MA_NGUON_NO == MAKH
                       where novay.TRA_XONG == MChoVay.CHUA_TRA_XONG
                       select novay);
            }
            else
            {
                nos = (from novay in DataInstance.Instance().DBContext().CHO_VAY
                       where novay.MA_NGUON_NO == MAKH
                       where novay.TRA_XONG == MChoVay.CHUA_TRA_XONG
                       select novay);
            }
            foreach (var _e in nos)
            {
                sum += (DateTime.Now - (DateTime)_e.NGAY_CHO_VAY).Days * (_e.TONG_TIEN - (double)_e.DA_TRA) * _e.LAI_SUAT / 3000;
            }
            return sum;
        }

        public double TongNoVay()
        {
            return NoVayHienTai() + LaiVayHienTai();
        }

        #endregion
    }
}