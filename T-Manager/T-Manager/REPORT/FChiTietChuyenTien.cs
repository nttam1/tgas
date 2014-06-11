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
    public partial class FChiTietChuyenTien : Form
    {
        public FChiTietChuyenTien()
        {
            InitializeComponent();
        }

        private void FChiTietChuyenTien_Load(object sender, EventArgs e)
        {
            dateTimePickerFROM.Value = dateTimePickerTO.Value.AddMonths(-1);
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_TK_NGANHANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            var _from = dateTimePickerFROM.Value.Date;
            var _to = dateTimePickerTO.Value.Date;
            var _kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            bs.DataSource = DataInstance.Instance().DBContext().CHUYEN_TIEN
                .Where(u => u.NGAY_CHUYEN >= _from && u.NGAY_CHUYEN <= _to && u.ID_TAI_KHOAN == _kho)
                .Select(u => new CChiTietChuyenTien { NGAY = u.NGAY_CHUYEN, TONGTIEN = u.TONG_TIEN});
            CrystalReportLICHSUCHUYENTIEN rpt = new CrystalReportLICHSUCHUYENTIEN();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KHO", comboBoxKHO.Text);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }
    }

    class CChiTietChuyenTien
    {
        public DateTime NGAY;
        public long TONGTIEN;
    }
}
