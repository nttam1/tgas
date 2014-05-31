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
            var rows = (from v in DataInstance.Instance().DBContext().VAYs
                             join nv in DataInstance.Instance().DBContext().NGUON_VAY on v.MA_NGUON_VAY equals nv.ID
                             where v.MA_NGUON_VAY == _ncc
                             where v.NGAY_VAY >= _from && v.NGAY_VAY <= _to
                             orderby v.NGAY_VAY ascending
                             select v);
            List<CChiTietNoVay> l = new List<CChiTietNoVay>();
            foreach (VAY _r in rows)
            {
                long lai = (long)Utility.Lai(_r.NGAY_VAY.Date, _r.LAI_SUAT,(int)_r.KY_HAN, _r.TONG_TIEN);
                long tragoc = 0;
                long tralai = 0;
                l.Add(new CChiTietNoVay
                {
                    NGAYVAY = _r.NGAY_VAY.Date,
                    TONGTIEN = _r.TONG_TIEN,
                    LAISUAT = _r.LAI_SUAT * 100,
                    THOIDOAN = _r.KY_HAN.ToString() + " Tháng",
                    TRAGOC = tragoc,
                    TRALAI = tralai
                });
            }
            bs.DataSource = l;
            CrystalReportCHITIETNOVAY rpt = new CrystalReportCHITIETNOVAY();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("NV", comboBoxNCC.Text);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
    class CChiTietNoVay
    {
        public DateTime NGAYVAY;
        public long TONGTIEN;
        public double LAISUAT;
        public string THOIDOAN;
        public long TRAGOC;
        public double TRALAI;
    }
}
