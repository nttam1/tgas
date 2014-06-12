using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace T_Manager.Modal
{
    class MThuNo
    {
        public const int NO_KHAC = 0;
        public const int NO_VAY = 1;
        public const int NO_HANG_HOA = 2;

        /// <summary>
        /// Khách hàng trả nợ, bao gồm lãi và gốc hoặc nợ khác (Nợ phát sinh, không lãi, có lý do)
        /// Loại nợ: Nợ hàng hóa hoặc nợ vay
        /// - Tạo một record THU_NO mới
        /// - Cập nhật chi tiết thu nợ
        /// </summary>
        /// <param name="TYPE"></param>
        /// <param name="MAKH"></param>
        /// <param name="TIENGOC"></param>
        /// <param name="TIENLAI"></param>
        public static void Create(int LOAINO, int MAKHO, Int64 MAKH, Int64 TIENGOC, Int64 TIENLAI, DateTime NGAYTRA, string NOIDUNG = "Thanh Toán Nợ")
        {
            /**
             * Tạo mới một THU_NO
             */
            THU_NO ele = new THU_NO();
            ele.MAKH = MAKH;
            ele.MAKHO = MAKHO;
            ele.TIEN_GOC = TIENGOC;
            ele.TIEN_LAI = TIENLAI;
            ele.NOI_DUNG = NOIDUNG;
            ele.LOAI_NO = LOAINO;
            ele.CREATED_AT = DateTime.Now;
            ele.NGAY_TRA = NGAYTRA.Date;
            DataInstance.Instance().DBContext().AddToTHU_NO(ele);
            DataInstance.Instance().DBContext().SaveChanges();
            Update(ele);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LOAINO"></param>
        /// <param name="MAKHO"></param>
        /// <param name="MAKH"></param>
        /// <param name="TIENGOC"></param>
        /// <param name="TIENLAI"></param>
        /// <param name="NGAYTRA"></param>
        /// <param name="NOIDUNG"></param>
        public static void Update(THU_NO ele)
        {
            long LOAINO = ele.LOAI_NO;
            long MAKHO  = ele.MAKHO;
            Int64 MAKH = ele.MAKH;
            Int64 TIENGOC = ele.TIEN_GOC;
            Int64 TIENLAI = ele.TIEN_LAI;
            DateTime NGAYTRA = ele.NGAY_TRA;
            string NOIDUNG = ele.NOI_DUNG;
            /**
             * Nợ khác: Thêm vào 1 record, không tác động gì khác
             * Nợ vay và nợ HH: Cần cập nhật chi tiết nợ
             */
            if (LOAINO != NO_KHAC)
            {
                var _TIENGOC = TIENGOC;
                var _TIENLAI = TIENLAI;
                long _start_id = 0;
                while (true)
                {
                    long _id = 0; // ID nợ của Khách Hàng
                    double _tong_no = 0; // Tổng nợ nợ của Khách Hàng
                    double _lai_suat = 0; // Lãi suất nợ của Khách Hàng
                    DateTime _ngay_no = new DateTime(); //Ngày nợ của Khách Hàng

                    /* Lấy ra record nợ xa nhất chưa trả xong của khách hàng */
                    switch (ele.LOAI_NO)
                    {
                        case NO_HANG_HOA:
                            try
                            {
                                XUAT_HANG _xh = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                                 where xh.MAKHO == ele.MAKHO
                                                 where xh.MAKH == ele.MAKH
                                                 where xh.ID > _start_id
                                                 where xh.TRANG_THAI == MXuatHang.CHUA_TRA_XONG
                                                 orderby xh.NGAY_XUAT ascending
                                                 select xh).First();
                                _id = _xh.ID;
                                _tong_no = _xh.SO_LUONG * _xh.DON_GIA_BAN - _xh.TRA_TRUOC;
                                _ngay_no = _xh.NGAY_XUAT.Value.Date;
                                _lai_suat = _xh.LAI_SUAT;
                            }
                            catch (Exception ex)
                            {

                            }
                            break;
                        case NO_VAY:
                            try
                            {
                                CHO_VAY _cv = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                                               where xh.MAKHO == ele.MAKHO
                                               where xh.MA_NGUON_NO == ele.MAKH
                                               where xh.TRANG_THAI == MXuatHang.CHUA_TRA_XONG
                                               where xh.ID > _start_id
                                               orderby xh.NGAY_CHO_VAY ascending
                                               select xh).First();
                                _id = _cv.ID;
                                _tong_no = _cv.TONG_TIEN;
                                _ngay_no = _cv.NGAY_CHO_VAY.Date;
                                _lai_suat = _cv.LAI_SUAT;
                            }
                            catch (Exception ex)
                            {

                            }
                            break;
                    }

                    double _lai = 0; // Lãi mà khách hàng nợ
                    double _goc = _tong_no; // Tiền mà khách hàng nợ

                    /* Lấy chi tiết những lần thanh toán trước cho record nợ này. Nếu có */
                    var _thanh_toan_s = (from tt in DataInstance.Instance().DBContext().CHI_TIET_THU_NO
                                         where tt.LOAI_NO == ele.LOAI_NO
                                         where tt.NO_ID == _id
                                         orderby tt.NGAY_TRA ascending
                                         select tt
                                             );

                    /* Tính lãi phần còn lại sau khi đã thanh toán một hay nhiều phần */
                    DateTime _ngay_no_hien_tai = _ngay_no;
                    foreach (CHI_TIET_THU_NO _r in _thanh_toan_s)
                    {
                        _lai += Utility.Lai(_ngay_no_hien_tai, _r.NGAY_TRA, _lai_suat, _goc) - _r.TIEN_LAI;
                        _ngay_no_hien_tai = _r.NGAY_TRA;
                        _goc -= _r.TIEN_GOC;

                    }

                    _lai += Utility.Lai(_ngay_no_hien_tai, _lai_suat, _goc);

                    // Đã tổng tiền gốc nợ và lãi hiện tại khách hàng nợ.
                    CHI_TIET_THU_NO _e = new CHI_TIET_THU_NO();
                    _e.LOAI_NO = ele.LOAI_NO;
                    _e.THU_NO_ID = ele.ID;
                    _e.NO_ID = _id;
                    _e.NGAY_TRA = ele.NGAY_TRA;
                    _e.TIEN_GOC = (long)(_goc < _TIENGOC ? _goc : _TIENGOC);
                    _e.TIEN_LAI = (long)(_lai < _TIENLAI ? _lai : _TIENLAI); ;
                    _e.CREATED_AT = DateTime.Now;
                    if (!(_e.TIEN_GOC == 0 && _e.TIEN_LAI == 0))
                    {
                        DataInstance.Instance().DBContext().AddToCHI_TIET_THU_NO(_e);
                        DataInstance.Instance().DBContext().SaveChanges();
                    }

                    /* Cập nhật TRANG_THAI của nợ hàng hóa hoặc nợ vay */
                    if (_TIENGOC >= _goc && _TIENLAI >= _lai)
                    {
                        switch (ele.LOAI_NO)
                        {
                            case NO_HANG_HOA:
                                try
                                {
                                    var _xh = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                               where xh.ID == _id
                                               select xh).First();
                                    _xh.TRANG_THAI = MXuatHang.DA_TRA_XONG;
                                    DataInstance.Instance().DBContext().SaveChanges();
                                }
                                catch (Exception ex)
                                {

                                }
                                break;
                            case NO_VAY:
                                try
                                {
                                    var _nv = (from xh in DataInstance.Instance().DBContext().CHO_VAY
                                               where xh.ID == _id
                                               select xh).First();
                                    _nv.TRANG_THAI = MChoVay.DA_TRA_XONG;
                                    DataInstance.Instance().DBContext().SaveChanges();
                                }
                                catch (Exception ex)
                                {

                                }
                                break;
                        }
                    }


                    /* Cập nhập lại tiền gốc tiền lãi */
                    _TIENGOC = (long)(_TIENGOC > _goc ? _TIENGOC - _goc : 0);
                    _TIENLAI = (long)(_TIENLAI > _lai ? _TIENLAI - _lai : 0);

                    /* Hết tiền để thanh toán */
                    if (_TIENGOC == 0 && _TIENLAI == 0)
                    {
                        break;
                    }
                    /* Hết tiền gốc hoặc lãi để thanh toán lần xuất hàng hiện tại */
                    if ((_TIENGOC == 0 && _TIENLAI != 0) || (_TIENGOC != 0 && _TIENLAI == 0))
                    {
                        _start_id = _id;
                    }
                }
            }
        }
    }
}
