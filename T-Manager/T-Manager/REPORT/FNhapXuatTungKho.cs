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
    public partial class FNhapXuatTungKho : Form
    {
        public FNhapXuatTungKho()
        {
            InitializeComponent();
        }

        private void FNhapXuatTungKho_Load(object sender, EventArgs e)
        {
            dateTimePickerFROM.Value = dateTimePickerFROM.Value.AddMonths(-1);
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            long _kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            DateTime _from = dateTimePickerFROM.Value;
            DateTime _to = dateTimePickerTO.Value;
            BindingSource bs = new BindingSource();
            bs.DataSource = MKho.NHAP_XUAT(_kho, _from, _to) ;
            CrystalReportNHAPXUATTUNGKHO rpt = new CrystalReportNHAPXUATTUNGKHO();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KHO", comboBoxKHO.Text);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }
    }
    class CNhapXuatTungKho
    {
        public DateTime CREATED_AT;
        public DateTime NGAY;
        public string NHAPXUAT;
        public string HANGHOA;
        public long SOLUONG;
        public long DONGIA;
        public long THANHTIEN;
        public string NOIDUNG;


    }
}
