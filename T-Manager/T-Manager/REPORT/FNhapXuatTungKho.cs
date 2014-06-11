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
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            long _kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            DateTime _from = dateTimePickerFROM.Value;
            DateTime _to = dateTimePickerTO.Value;
            BindingSource bs = new BindingSource();
            List<CNhapXuatTungKho> list = new List<CNhapXuatTungKho>();
            // Tất cả hàng hóa
            var hh = (from _hh in DataInstance.Instance().DBContext().HANG_HOA orderby _hh.NAME select _hh);
            foreach (HANG_HOA h in hh)
            {
                CNhapXuatTungKho c = new CNhapXuatTungKho();
                c.HANGHOA = h.NAME;
                c.TONDAU = MKho.TON_DAU(_kho, _from, h.ID);
                c.NHAP = MKho.Total_Nhap_To(_kho, _from, _to, true, h.ID);
                c.XUAT = MKho.Total_Xuat_To(_kho, _from, _to, true, h.ID);
                c.TONCUOI = MKho.TON_CUOI(_kho, _to, h.ID);
                list.Add(c);
            }
            bs.DataSource = list;
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
        public string HANGHOA;
        public long TONDAU;
        public long NHAP;
        public long XUAT;
        public long TONCUOI;


    }
}
