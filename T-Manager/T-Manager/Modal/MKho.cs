using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using T_Manager.REPORT;

namespace T_Manager.Modal
{
    class MKho
    {
        public const int KHO_HANG = 0;
        public const int KHO_TK_NGANHANG = 1;
        public const int KHO_QUY = 2;

        public static IQueryable<T_Manager.KHO> Get(int type)
        {
            return DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == type);
        }

        /// <summary>
        /// Lấy tất cả thông tin về nhập xuất hàng tưng kho
        /// Order theo thời gian tạo
        /// Nhập: + Nhập hàng
        /// Xuất: + Bán hàng
        ///       + Xuất hàng
        /// </summary>
        /// <param name="MAKHO"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public static List<CNhapXuatTungKho> NHAP_XUAT(long MAKHO, DateTime From, DateTime To)
        {
            /*Lấy dữ liêu*/
            List<CNhapXuatTungKho> list = new List<CNhapXuatTungKho>();
            var nhap = (from n in DataInstance.Instance().DBContext().NHAP_HANG
                        join hh in DataInstance.Instance().DBContext().HANG_HOA on n.MAHH equals hh.ID
                        join ncc in DataInstance.Instance().DBContext().NHA_CUNG_CAP on n.MANCC equals ncc.ID
                        where n.MAKHO == MAKHO
                        where n.NGAY_NHAP >= From && n.NGAY_NHAP <= To
                        select new CNhapXuatTungKho
                        {
                            CREATED_AT = n.CREATED_AT,
                            DONGIA = n.DON_GIA_MUA,
                            HANGHOA = hh.NAME,
                            NHAPXUAT = "NHẬP",
                            SOLUONG = n.SO_LUONG,
                            THANHTIEN = -n.DON_GIA_MUA * n.SO_LUONG,
                            NOIDUNG = ncc.NAME,
                            NGAY = n.NGAY_NHAP
                        });

            var xuat = (from x in DataInstance.Instance().DBContext().XUAT_HANG
                        join hh in DataInstance.Instance().DBContext().HANG_HOA on x.MAHH equals hh.ID
                        join kh in DataInstance.Instance().DBContext().KHACH_HANG on x.MAKH equals kh.ID
                        where x.MAKHO == MAKHO
                        where x.NGAY_XUAT >= From && x.NGAY_XUAT <= To
                        select new CNhapXuatTungKho
                        {
                            CREATED_AT = x.CREATED_AT,
                            DONGIA = x.DON_GIA_BAN,
                            HANGHOA = hh.NAME,
                            NHAPXUAT = "XUẤT",
                            SOLUONG = -x.SO_LUONG,
                            THANHTIEN = x.DON_GIA_BAN * x.SO_LUONG,
                            NOIDUNG = "KH: " + kh.NAME,
                            NGAY = x.NGAY_XUAT.Value
                        });

            var ban = (from b in DataInstance.Instance().DBContext().BAN_HANG
                       join hh in DataInstance.Instance().DBContext().HANG_HOA on b.MAHH equals hh.ID
                       where b.MAKHO == MAKHO
                       where b.NGAY_BAN >= From && b.NGAY_BAN <= To
                       select new CNhapXuatTungKho
                       {
                           CREATED_AT = b.CREATED_TIME,
                           DONGIA = b.DON_GIA_BAN,
                           HANGHOA = hh.NAME,
                           NHAPXUAT = "XUẤT",
                           SOLUONG = -b.SO_LUONG,
                           THANHTIEN = b.DON_GIA_BAN * b.SO_LUONG,
                           NOIDUNG = "BÁN MẶT",
                           NGAY = b.NGAY_BAN
                       });
            /*Thêm dữ liệu vào list*/
            foreach (CNhapXuatTungKho _r in nhap)
            {
                list.Add(_r);
            }
            foreach (CNhapXuatTungKho _r in ban)
            {
                list.Add(_r);
            }
            foreach (CNhapXuatTungKho _r in xuat)
            {
                list.Add(_r);
            }
            /*Sắp xếp dữ liệu theo created time*/
            list.OrderBy(u => u.NGAY);
            return list.OrderBy(u => u.NGAY).ToList();
        }
    }
}
