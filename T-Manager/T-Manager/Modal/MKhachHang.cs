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
        private long _MA_FROM;
        private long _MA_TO;

        public MKhachHang(int MAKH)
        {
            this.MAKH = MAKH;
            this._MA_FROM = 1;
            this._MA_TO = (from kho in DataInstance.Instance().DBContext().KHOes select kho.ID).Max();
        }

        public MKhachHang(int MAKH, int MAKHO)
        {
            this.MAKH = MAKH;
            this.MAKHO = MAKHO;
            _MA_FROM = MAKHO;
            _MA_TO = MAKHO;
        }

        #region Nợ hàng hóa
        /// <summary>
        /// Tổng tiền gốc hiện tại khách hàng nợ
        /// </summary>
        /// <returns></returns>
        public double NoHHHienTai(bool include_THUNO = true)
        {
            double value = 0;
            IQueryable<XUAT_HANG> _rows;
            if (include_THUNO == true)
            {
                /* Lấy tất cả những lần xuất hàng cho khách hàng mà khách chưa trả xong */
                /* Có thể sử dụng cách Sum(Nợ) - Sum(Trả).
                 * Vì chỉ tính tiền gốc, không tính lãi nên ko cần quan tâm ngày trả 
                 * Tuy nhiên khi lượng dữ liệu lớn sẽ tốn thời gian để lấy những dữ liệu không cần thiết
                 */
                _rows = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                         where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                         where xh.MAKH == MAKH
                         where xh.TRANG_THAI == MXuatHang.CHUA_TRA_XONG
                         orderby xh.NGAY_XUAT ascending
                         select xh);

                /* Tìm phần đã được thanh toán đó, trừ vào tổng nợ những lần chưa trả xong */

                foreach (XUAT_HANG row in _rows)
                {
                    /* Tìm những phần đã thanh toán của lần xuất hàng này */
                    double da_thanh_toan = 0;
                    try
                    {
                        da_thanh_toan = (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                                         where cttn.LOAI_NO == MThuNo.NO_HANG_HOA
                                         where cttn.NO_ID == row.ID
                                         select cttn.TIEN_GOC
                                                      ).Sum();
                    }
                    catch (Exception ex)
                    {

                    }
                    value += row.SO_LUONG * row.DON_GIA_BAN - da_thanh_toan;

                }

            }
            else
            {
                try
                {
                    double _tong_no = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                       where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                                       where xh.MAKH == MAKH
                                       orderby xh.NGAY_XUAT ascending
                                       select xh.SO_LUONG * xh.DON_GIA_BAN).Sum();
                    value = _tong_no;
                }
                catch (Exception ex)
                {

                }
            }
            return value;
        }
        /// <summary>
        /// Tính lãi nợ hàng hóa hiện tại của khách hàng
        /// </summary>
        /// <param name="include_THUNO"></param>
        /// <returns></returns>
        public double LaiHHHienTai(bool include_THUNO = true)
        {
            double value = 0;
            IQueryable<XUAT_HANG> _rows;
            if (include_THUNO == true)
            {
                /* Lấy tất cả những lần xuất hàng cho khách hàng mà khách chưa trả xong*/
                _rows = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                         where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                         where xh.MAKH == MAKH
                         where xh.TRANG_THAI == MXuatHang.CHUA_TRA_XONG
                         orderby xh.NGAY_XUAT ascending
                         select xh);
                /* Tìm những phần đã được thanh toán đó, trừ vào tổng nợ lãi những lần chưa trả xong */
                foreach (XUAT_HANG row in _rows)
                {
                    /* Tìm những phần đã thanh toán của lần xuất hàng này */
                    var da_thanh_toan = (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                                         where cttn.LOAI_NO == MThuNo.NO_HANG_HOA
                                         where cttn.NO_ID == row.ID
                                         select cttn);
                    DateTime _ngay_no = row.NGAY_XUAT.Value;
                    double _tong_tien_hien_tai = row.SO_LUONG * row.DON_GIA_BAN;
                    foreach (CHI_TIET_THU_NO tn in da_thanh_toan)
                    {
                        value += Utility.Lai(_ngay_no, tn.NGAY_TRA, row.LAI_SUAT, _tong_tien_hien_tai) - tn.TIEN_LAI;
                        _ngay_no = tn.NGAY_TRA;
                        _tong_tien_hien_tai -= tn.TIEN_GOC;
                    }
                    value += Utility.Lai(_ngay_no, row.LAI_SUAT, _tong_tien_hien_tai);

                }

            }
            else
            {
                /* Vì không sử dụng dữ liệu từ thu nợ */
                /* Tổng lãi nợ của khách hàng từ đầu đến bây giờ */
                var _xh = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                           where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                           where xh.MAKH == MAKH
                           orderby xh.NGAY_XUAT ascending
                           select xh);
                double _tong_lai_no = 0;
                foreach (XUAT_HANG row in _xh)
                {
                    _tong_lai_no += Utility.Lai(row.NGAY_XUAT.Value, row.LAI_SUAT, row.SO_LUONG * row.DON_GIA_BAN);
                }
                value = _tong_lai_no;
            }
            return value;
        }
        #endregion

        #region Nợ vay
        /// <summary>
        /// Tổng tiền gốc hiện tại khách hàng nợ
        /// </summary>
        /// <returns></returns>
        public double NoVayHienTai(bool include_THUNO = true)
        {
            double value = 0;
            IQueryable<CHO_VAY> _rows;
            if (include_THUNO == true)
            {
                /* Lấy tất cả những lần xuất hàng cho khách hàng mà khách chưa trả xong */
                /* Có thể sử dụng cách Sum(Nợ) - Sum(Trả).
                 * Vì chỉ tính tiền gốc, không tính lãi nên ko cần quan tâm ngày trả 
                 * Tuy nhiên khi lượng dữ liệu lớn sẽ tốn thời gian để lấy những dữ liệu không cần thiết
                 */
                _rows = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                         where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                         where xh.MA_NGUON_NO == MAKH
                         where xh.TRANG_THAI == MXuatHang.CHUA_TRA_XONG
                         orderby xh.NGAY_CHO_VAY ascending
                         select xh);

                /* Tìm phần đã được thanh toán đó, trừ vào tổng nợ những lần chưa trả xong */

                foreach (CHO_VAY row in _rows)
                {
                    /* Tìm những phần đã thanh toán của lần xuất hàng này */
                    double da_thanh_toan = 0;
                    try
                    {
                        da_thanh_toan = (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                                         where cttn.LOAI_NO == MThuNo.NO_VAY
                                         where cttn.NO_ID == row.ID
                                         select cttn.TIEN_GOC
                                                      ).Sum();
                    }
                    catch (Exception ex)
                    {

                    }
                    value += row.TONG_TIEN - da_thanh_toan;

                }

            }
            else
            {
                try
                {
                    double _tong_no = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                                       where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                                       where xh.MA_NGUON_NO == MAKH
                                       orderby xh.NGAY_CHO_VAY ascending
                                       select xh.TONG_TIEN).Sum();
                    value = _tong_no;
                }
                catch (Exception ex)
                {

                }
            }
            return value;
        }
        /// <summary>
        /// Tính lãi nợ hàng hóa hiện tại của khách hàng
        /// </summary>
        /// <param name="include_THUNO"></param>
        /// <returns></returns>
        public double LaiVayHienTai(bool include_THUNO = true)
        {
            double value = 0;
            IQueryable<CHO_VAY> _rows;
            if (include_THUNO == true)
            {
                /* Lấy tất cả những lần xuất hàng cho khách hàng mà khách chưa trả xong*/
                _rows = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                         where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                         where xh.MA_NGUON_NO == MAKH
                         where xh.TRANG_THAI == MXuatHang.CHUA_TRA_XONG
                         orderby xh.NGAY_CHO_VAY ascending
                         select xh);
                /* Tìm những phần đã được thanh toán đó, trừ vào tổng nợ lãi những lần chưa trả xong */
                foreach (CHO_VAY row in _rows)
                {
                    /* Tìm những phần đã thanh toán của lần xuất hàng này */
                    var da_thanh_toan = (from cttn in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                                         where cttn.LOAI_NO == MThuNo.NO_VAY
                                         where cttn.NO_ID == row.ID
                                         select cttn);
                    DateTime _ngay_no = row.NGAY_CHO_VAY;
                    double _tong_tien_hien_tai = row.TONG_TIEN;
                    foreach (CHI_TIET_THU_NO tn in da_thanh_toan)
                    {
                        value += Utility.Lai(_ngay_no, tn.NGAY_TRA, row.LAI_SUAT, _tong_tien_hien_tai) - tn.TIEN_LAI;
                        _ngay_no = tn.NGAY_TRA;
                        _tong_tien_hien_tai -= tn.TIEN_GOC;
                    }
                    value += Utility.Lai(_ngay_no, row.LAI_SUAT, _tong_tien_hien_tai);

                }

            }
            else
            {
                /* Vì không sử dụng dữ liệu từ thu nợ */
                /* Tổng lãi nợ của khách hàng từ đầu đến bây giờ */
                var _xh = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                           where xh.MAKHO >= _MA_FROM && xh.MAKHO <= _MA_TO
                           where xh.MA_NGUON_NO == MAKH
                           orderby xh.NGAY_CHO_VAY ascending
                           select xh);
                double _tong_lai_no = 0;
                foreach (CHO_VAY row in _xh)
                {
                    _tong_lai_no += Utility.Lai(row.NGAY_CHO_VAY, row.LAI_SUAT, row.TONG_TIEN);
                }
                value = _tong_lai_no;
            }
            return value;
        }
        #endregion

    }
}