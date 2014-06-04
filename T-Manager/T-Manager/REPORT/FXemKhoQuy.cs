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
    public partial class FXemKhoQuy : Form
    {
        public FXemKhoQuy()
        {
            InitializeComponent();
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _from = dateTimePickerFROM.Value;
            BindingSource bs = new BindingSource();
            CrystalReportXEMKHOQUY rpt = new CrystalReportXEMKHOQUY();
            List<CXemKhoQuy> list = new List<CXemKhoQuy>();
            var khos = (from _kho in DataInstance.Instance().DBContext().KHOes select _kho);
            foreach (KHO k in khos)
            {
                CXemKhoQuy c = new CXemKhoQuy();
                c.KHO = k.NAME;
                c.CHI = MKho.Total_Chi(k.ID, _from, _from);
                c.THU = MKho.Total_Thu(k.ID, _from, _from);
                c.TONGTIEN = c.THU - c.CHI;
                list.Add(c);
            }
            bs.DataSource = list;
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("DATE", _from);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void FXemKhoQuy_Load(object sender, EventArgs e)
        {

        }
    }

    class CXemKhoQuy
    {
        public string KHO;
        public long CHI;
        public long THU;
        public long TONGTIEN;
    }

}
