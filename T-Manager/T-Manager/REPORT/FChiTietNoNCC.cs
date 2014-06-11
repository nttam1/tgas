using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
}
