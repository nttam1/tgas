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
    public partial class FTongHopNoNCC : Form
    {
        public FTongHopNoNCC()
        {
            InitializeComponent();
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _from = dateTimePicker1.Value;
            var _to = dateTimePicker2.Value;

            BindingSource bs = new BindingSource();
            bs.DataSource = (from nh in DataInstance.Instance().DBContext().NHAP_HANG
                             join ncc in DataInstance.Instance().DBContext().NHA_CUNG_CAP on nh.MANCC equals ncc.ID
                             join hh in DataInstance.Instance().DBContext().HANG_HOA on nh.MAHH equals hh.ID
                             where nh.NGAY_NHAP >= _from
                             where nh.NGAY_NHAP <= _to
                             select new
                             {
                                 NCC = ncc.NAME,
                                 HANGHOA = hh.NAME,
                                 SOLUONG = nh.SO_LUONG,
                                 THANHTIEN = nh.SO_LUONG * nh.DON_GIA_MUA,
                             });
            CrystalReportTONGHOPNONCC rpt = new CrystalReportTONGHOPNONCC();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void FTongHopNoNCC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
        }
    }
}
