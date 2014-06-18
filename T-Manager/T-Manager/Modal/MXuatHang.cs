﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace T_Manager.Modal
{
    class MXuatHang
    {
        public const int CHUA_TRA_XONG = 0;
        public const int DA_TRA_XONG = 1;
        public const int MAKH_XUAT_MAT = -1;
        public const int MAHH_CHO_VAY = -1;
        /// <summary>
        /// Trừ số lượng xuất hàng vào số lượng còn lại của nhập hàng
        /// </summary>
        /// <param name="_SoLuong">Số lượng xuất hàng</param>
        /// <param name="ele">Object Xuất hàng</param>
        public static void Update(long _SoLuong, XUAT_HANG ele)
        {
            if (_SoLuong > 0)
            {
                List<CXuatHangChiTiet> chitiet = new List<CXuatHangChiTiet>();
                foreach (var row in DataInstance.Instance().DBContext().NHAP_HANG
                    .Where(u => u.MAKHO == ele.MAKHO)
                    .Where(u => u.MAHH == ele.MAHH)
                    .Where(u => u.SL_CON_LAI > 0)
                    .OrderBy(u => u.NGAY_NHAP))
                {
                    /**
                     * Cập nhật số lượng vào nhập hàng
                     */
                    var sub_SL = row.SL_CON_LAI;
                    row.SL_CON_LAI = _SoLuong >= row.SL_CON_LAI ? 0 : row.SL_CON_LAI - _SoLuong;

                    /* Cập nhật chi tiết số lượng, đơn giá để tính lãi lỗi*/
                    long __subSL = row.SL_CON_LAI > 0 ? _SoLuong : sub_SL;
                    if (__subSL > 0)
                    {
                        chitiet.Add(new CXuatHangChiTiet()
                        {
                            NHAPHANGID = row.ID,
                            SOLUONG = row.SL_CON_LAI > 0 ? _SoLuong : sub_SL,
                            DONGIA = row.DON_GIA_MUA
                        });
                    }

                    _SoLuong = _SoLuong >= sub_SL ? _SoLuong - sub_SL : 0;

                    if (_SoLuong == 0)
                    {
                        break;
                    }
                }
                string s_chitiet = JsonConvert.SerializeObject(chitiet);
                ele.CHI_TIET_XUAT_HANG = s_chitiet;
            }
            else
            {
                _SoLuong = -_SoLuong;
                List<CXuatHangChiTiet> chitiet = new List<CXuatHangChiTiet>();
                foreach (var row in DataInstance.Instance().DBContext().NHAP_HANG
                    .Where(u => u.MAKHO == ele.MAKHO)
                    .Where(u => u.MAHH == ele.MAHH)
                    .Where(u => u.SL_CON_LAI < u.SO_LUONG)
                    .OrderByDescending(u => u.NGAY_NHAP))
                {
                    /**
                     * Cập nhật số lượng vào nhập hàng
                     */
                    var sub_SL = row.SL_CON_LAI;
                    row.SL_CON_LAI = _SoLuong >= row.SO_LUONG - row.SL_CON_LAI ? row.SO_LUONG : row.SL_CON_LAI + _SoLuong;

                    /* Cập nhật chi tiết số lượng, đơn giá để tính lãi lỗi*/
                    long __subSL = row.SL_CON_LAI < row.SO_LUONG ? _SoLuong : _SoLuong - (row.SO_LUONG - row.SL_CON_LAI);
                    chitiet.Add(new CXuatHangChiTiet()
                    {
                        NHAPHANGID = row.ID,
                        SOLUONG = __subSL,
                        DONGIA = row.DON_GIA_MUA
                    });

                    _SoLuong = _SoLuong - sub_SL;

                    if (_SoLuong == 0)
                    {
                        break;
                    }
                }
                string s_chitiet = JsonConvert.SerializeObject(chitiet);
                ele.CHI_TIET_XUAT_HANG = s_chitiet;
            }
            DataInstance.Instance().DBContext().SaveChanges();
        }

        /// <summary>
        /// Tính lãi hiện tại của xuất hàng theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include_THUNO"></param>
        /// <returns></returns>
        public static double GetLai(int id, DateTime TO, bool include_THUNO = true)
        {
            double value = 0;
            XUAT_HANG xh = (from _xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where _xh.ID == id
                            select _xh).First();
            /* Sử dụng chi tiết thu nợ để tính lãi */
            if (include_THUNO == true)
            {
                /* Những lần khách hàng đã trả cho phần nợ xuất hàng này */
                var thu_no_s = MChiTietThuNo.BelongTo(xh, TO);
                value = Utility.LaiKep((DateTime)xh.NGAY_XUAT, TO, xh.LAI_SUAT, xh.THANH_TIEN - xh.TRA_TRUOC, thu_no_s);

            }
            /* Không sử dụng chi tiết thu nợ */
            else
            {
                value = Utility.Lai(xh.NGAY_XUAT.Value, TO, xh.LAI_SUAT, xh.THANH_TIEN - xh.TRA_TRUOC);
            }
            return value;
        }

        /// <summary>
        /// Tính lãi phát sinh của xuất hàng theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include_THUNO"></param>
        /// <returns></returns>
        public static double GetLaiPhatSinh(int id, DateTime TO, bool include_THUNO = true)
        {
            double value = 0;
            XUAT_HANG xh = (from _xh in DataInstance.Instance().DBContext().XUAT_HANG
                            where _xh.ID == id
                            select _xh).First();
            /* Sử dụng chi tiết thu nợ để tính lãi */
            if (include_THUNO == true)
            {
                /* Những lần khách hàng đã trả cho phần nợ xuất hàng này */
                var thu_no_s = MChiTietThuNo.BelongTo(xh, TO);
                value = Utility.LaiKep((DateTime)xh.NGAY_XUAT, TO, xh.LAI_SUAT, xh.THANH_TIEN - xh.TRA_TRUOC, thu_no_s, false);

            }
            /* Không sử dụng chi tiết thu nợ */
            else
            {
                value = Utility.Lai(xh.NGAY_XUAT.Value, TO, xh.LAI_SUAT, xh.THANH_TIEN - xh.TRA_TRUOC);
            }
            return value;
        }

        public static long TongNoDauKi(long MAKH, DateTime TO)
        {
            TO = TO.Date;
            long value = 0;
            try
            {
                value = DataInstance.Instance().DBContext().XUAT_HANG
                    .Where(u => u.MAKH == MAKH)
                    .Where(u => u.NGAY_XUAT < TO)
                    .Select(u => u.THANH_TIEN - u.TRA_TRUOC)
                    .Sum();
            }
            catch (Exception ex)
            {

            }
            return value;
        }
    }

    class CXuatHangChiTiet
    {
        public long NHAPHANGID;
        public long SOLUONG;
        public long DONGIA;
    }
}