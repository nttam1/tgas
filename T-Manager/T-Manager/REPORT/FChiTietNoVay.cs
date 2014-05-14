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
    public partial class FChiTietNoVay : Form
    {
        public FChiTietNoVay()
        {
            InitializeComponent();
        }

        private void FChiTietNoVay_Load(object sender, EventArgs e)
        {
            comboBoxNCC.DataSource = DataInstance.Instance().DBContext().NGUON_VAY;
            comboBoxNCC.ValueMember = "ID";
            comboBoxNCC.DisplayMember = "NAME";

            dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1);
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _ncc = long.Parse(comboBoxNCC.SelectedValue.ToString());
            var _from = dateTimePicker1.Value;
            var _to = dateTimePicker2.Value;

            BindingSource bs = new BindingSource();
            bs.DataSource = (from v in DataInstance.Instance().DBContext().VAYs
                             join nv in DataInstance.Instance().DBContext().NGUON_VAY on v.MA_NGUON_VAY equals nv.ID
                             where v.MA_NGUON_VAY == _ncc
                             where v.NGAY_VAY >= _from
                             where v.NGAY_VAY <= _to
                             select new
                             {
                                 NGAYVAY = v.NGAY_VAY,
                                 TONGTIEN = v.TONG_TIEN,
                                 LAISUAT = v.LAI_SUAT
                             });
            CrystalReportCHITIETNOVAY rpt = new CrystalReportCHITIETNOVAY();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("NV", comboBoxNCC.Text);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
