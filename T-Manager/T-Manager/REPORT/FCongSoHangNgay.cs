using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager.Modal;

namespace T_Manager.REPORT
{
    public partial class FCongSoHangNgay : Form
    {
        public FCongSoHangNgay()
        {
            InitializeComponent();
        }

        private void FCongSoHangNgay_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _today = dateTimePickerFROM.Value.Date;
            long _kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            BindingSource bs = new BindingSource();
            CrystalReportCONGOSHANGNGAT rpt = new CrystalReportCONGOSHANGNGAT();
            List<CCongSoHangNgay> list = new List<CCongSoHangNgay>();
            var hh = (from _hh in DataInstance.Instance().DBContext().HANG_HOA select _hh);
            foreach (HANG_HOA h in hh)
            {
                foreach (XUAT_HANG bh in (from _bh in DataInstance.Instance().DBContext().XUAT_HANG
                                          where _bh.MAHH == h.ID
                                          where _bh.MAKHO == _kho
                                          where _bh.NGAY_XUAT == _today
                                          select _bh))
                {
                    CCongSoHangNgay c = new CCongSoHangNgay();
                    c.HANGHOA = h.NAME;
                    c.SOLUONG = bh.SO_LUONG;
                    c.DONGIA = bh.DON_GIA_BAN;
                    c.THANHTIEN = bh.THANH_TIEN;
                    list.Add(c);
                }
            }
            if (list.Count > 0)
            {
                bs.DataSource = (from d in list
                                 group d by new { d.HANGHOA, d.DONGIA } into g
                                 orderby g.Key.HANGHOA
                                 select new CCongSoHangNgay
                                 {
                                     HANGHOA = g.Key.HANGHOA,
                                     DONGIA = g.Key.DONGIA,
                                     SOLUONG = g.Sum(u => u.SOLUONG),
                                     THANHTIEN = g.Sum(u => u.THANHTIEN)
                                 });
            }
            else
            {
                bs.DataSource = list;
            }
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("DATE", _today);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            long thuno = 0;
            long thukhac = 0;
            long chiluong = 0;
            long chikhac = 0;
            long chincc = 0;
            long no = 0;

            try
            {
                thuno = (from tn in DataInstance.Instance().DBContext().THU_NO
                         where tn.NGAY_TRA == _today
                         where tn.MAKHO == _kho
                         where tn.LOAI_NO != MThuNo.NO_KHAC
                         select tn.TIEN_GOC + tn.TIEN_LAI
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }
            try
            {
                thukhac = (from tn in DataInstance.Instance().DBContext().THU_NO
                           where tn.NGAY_TRA == _today
                           where tn.MAKHO == _kho
                           where tn.LOAI_NO == MThuNo.NO_KHAC
                           select tn.TIEN_GOC + tn.TIEN_LAI).Sum();
            }
            catch (Exception ex)
            {

            }
            try
            {
                chiluong = (from tn in DataInstance.Instance().DBContext().CHI_LUONG
                            where tn.MAKHO == _kho
                            where tn.NGAY_CHI == _today
                            select tn.TONG_TIEN
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }
            try
            {
                chikhac = (from tn in DataInstance.Instance().DBContext().CHI_KHAC
                           where tn.MAKHO == _kho
                           where tn.NGAY_CHI == _today
                           select tn.TONG_TIEN
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }
            try
            {
                chincc = (from tn in DataInstance.Instance().DBContext().TRA_NO_NCC
                          where tn.MAKHO == _kho
                          where tn.NGAY_TRA == _today
                          select tn.TONG_TIEN
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }
            try
            {
                no = (from tn in DataInstance.Instance().DBContext().TRA_NO_VAY
                      where tn.NGAY_TRA == _today
                      where tn.MAKHO == _kho
                      select tn.TIEN_GOC + tn.TIEN_LAI
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }

            long kh_no = 0;
            try
            {
                kh_no = (from tn in DataInstance.Instance().DBContext().XUAT_HANG
                         where tn.NGAY_XUAT == _today
                         where tn.MAKH != MXuatHang.MAKH_XUAT_MAT
                         where tn.MAKHO == _kho
                         select tn.THANH_TIEN - tn.TRA_TRUOC
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }

            long chi_xe = 0;

            try
            {
                chi_xe = (from tn in DataInstance.Instance().DBContext().CHI_TIEU_DUNG_NOI_BO
                         where tn.NGAY_CHI == _today
                         where tn.MAKHO == _kho
                         where tn.MAHH == -1
                         select tn.TONG_TIEN
                                                ).Sum();
            }
            catch (Exception ex)
            {

            }

            rpt.SetParameterValue("THUNO", thuno);
            rpt.SetParameterValue("THUKHAC", thukhac);
            rpt.SetParameterValue("CHILUONG", chiluong);
            rpt.SetParameterValue("CHITRANCC", chincc);
            rpt.SetParameterValue("CHIKHAC", chikhac + chi_xe);
            rpt.SetParameterValue("TRANO", no);
            rpt.SetParameterValue("KHNO", kh_no);

            crystalReportViewer1.ReportSource = rpt;
        }
    }

    class CCongSoHangNgay
    {
        public string HANGHOA;
        public long SOLUONG;
        public long DONGIA;
        public long THANHTIEN;
    }
}
