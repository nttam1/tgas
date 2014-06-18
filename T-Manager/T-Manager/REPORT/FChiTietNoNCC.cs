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
    public partial class FChiTietNoNCC : Form
    {
        public FChiTietNoNCC()
        {
            InitializeComponent();
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _ncc = long.Parse(comboBoxNCC.SelectedValue.ToString());
            var _from = dateTimePickerFROM.Value;
            var _to = dateTimePickerTO.Value;
            string note = "";
            BindingSource bs = new BindingSource();
            if (checkBoxTRANO.Checked == false)
            {
                bs.DataSource = (from nh in DataInstance.Instance().DBContext().NHAP_HANG
                                 join kho in DataInstance.Instance().DBContext().KHOes on nh.MAKHO equals kho.ID
                                 join ncc in DataInstance.Instance().DBContext().NHA_CUNG_CAP on nh.MANCC equals ncc.ID
                                 join hh in DataInstance.Instance().DBContext().HANG_HOA on nh.MAHH equals hh.ID
                                 where nh.MANCC == _ncc
                                 where nh.NGAY_NHAP >= _from
                                 where nh.NGAY_NHAP <= _to
                                 select new
                                 {
                                     NGAY = nh.NGAY_NHAP,
                                     KHO = kho.NAME,
                                     HANGHOA = hh.NAME,
                                     SOLUONG = nh.SO_LUONG,
                                     DONGIA = nh.DON_GIA_MUA,
                                     THANHTIEN = nh.SO_LUONG * nh.DON_GIA_MUA
                                 });
                CrystalReportCHITIETNONCC rpt = new CrystalReportCHITIETNONCC();
                rpt.SetDataSource(bs);
                rpt.SetParameterValue("NCC", comboBoxNCC.Text);
                rpt.SetParameterValue("FROM", _from);
                rpt.SetParameterValue("TO", _to);
                rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
                crystalReportViewer1.ReportSource = rpt;
            }
            else
            {
                List<CThanhToanNCC> lst = new List<CThanhToanNCC>();
                foreach (NHAP_HANG nh in DataInstance.Instance().DBContext().NHAP_HANG
                    .Where(u => u.MANCC == _ncc && u.NGAY_NHAP >= _from && u.NGAY_NHAP <= _to))
                {
                    lst.Add(new CThanhToanNCC
                    {
                        NGAY = nh.NGAY_NHAP,
                        KHO = MKho.GetNamebyID(nh.MAKHO),
                        HANGHOA = MHangHoa.GetNameByID(nh.MAHH),
                        DONGIA = nh.DON_GIA_MUA,
                        SOLUONG = nh.SO_LUONG,
                        THANHTIEN = nh.SO_LUONG * nh.DON_GIA_MUA,
                        TIENTHANHTOAN = 0,
                        CONNO = 0,
                        THANHTOAN = "-",
                    });
                }
                foreach (TRA_NO_NCC tn in DataInstance.Instance().DBContext().TRA_NO_NCC
                    .Where(u => u.MANCC == _ncc && u.NGAY_TRA >= _from && u.NGAY_TRA <= _to))
                {
                    lst.Add(new CThanhToanNCC
                    {
                        NGAY = tn.NGAY_TRA,
                        KHO = MKho.GetNamebyID(tn.MAKHO),
                        HANGHOA = "-",
                        DONGIA = 0,
                        SOLUONG = 0,
                        TIENTHANHTOAN = tn.TONG_TIEN,
                        CONNO = 0,
                        THANHTOAN = "TRẢ NỢ NCC",
                    });
                }
                var datasource = lst.OrderBy(u => u.NGAY);
                long nodauki = MNcc.NoTO(_ncc, _from) - MNcc.TraNoTO(_ncc, _from);
                long _nodauki = nodauki;
                foreach (CThanhToanNCC c in datasource)
                {
                    c.CONNO = nodauki - c.TIENTHANHTOAN + c.THANHTIEN;
                    nodauki = c.CONNO;
                }
                bs.DataSource = lst;
                CrystalReportTHANHTOANNCC rpt = new CrystalReportTHANHTOANNCC();
                rpt.SetDataSource(bs);
                rpt.SetParameterValue("NCC", comboBoxNCC.Text);
                rpt.SetParameterValue("FROM", _from);
                rpt.SetParameterValue("TO", _to);
                rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
                rpt.SetParameterValue("NODAUKI", _nodauki);
                crystalReportViewer1.ReportSource = rpt;
            }
        }

        private void FChiTietNoNCC_Load(object sender, EventArgs e)
        {
            comboBoxNCC.DataSource = T_Manager.Modal.MNcc.Get().OrderBy(u => u.NAME); ;//DataInstance.Instance().DBContext().NHA_CUNG_CAP;
            comboBoxNCC.DisplayMember = "NAME";
            comboBoxNCC.ValueMember = "ID";

            dateTimePickerFROM.Value = dateTimePickerFROM.Value.AddMonths(-1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    class CThanhToanNCC
    {
        public DateTime NGAY;
        public string KHO;
        public string HANGHOA;
        public string THANHTOAN;
        public long DONGIA;
        public long SOLUONG;
        public long TIENTHANHTOAN;
        public long THANHTIEN;
        public long CONNO;
    }
}
