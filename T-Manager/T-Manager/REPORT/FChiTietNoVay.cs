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
    public partial class FChiTietNoVay : Form
    {
        public FChiTietNoVay()
        {
            InitializeComponent();
        }

        private void FChiTietNoVay_Load(object sender, EventArgs e)
        {
            comboBoxNCC.DataSource = DataInstance.Instance().DBContext().NGUON_VAY.OrderBy(u => u.NAME); ;
            comboBoxNCC.ValueMember = "ID";
            comboBoxNCC.DisplayMember = "NAME";

            dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1);
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _ncc = long.Parse(comboBoxNCC.SelectedValue.ToString());
            var _from = dateTimePicker1.Value.Date;
            var _to = dateTimePicker2.Value.Date;

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
                l.Add(new CChiTietNoVay
                {
                    NGAYVAY = _r.NGAY_VAY.Date,
                    TONGTIEN = _r.TONG_TIEN,
                    LAISUAT = _r.LAI_SUAT * 100,
                    THOIDOAN = "Vay",
                    TRAGOC = 0,
                    TRALAI = 0
                });
            }
            foreach (TRA_NO_VAY _r in DataInstance.Instance().DBContext().TRA_NO_VAY
                .Where( u=> u.MA_NGUON_VAY == _ncc && u.NGAY_TRA >= _from && u.NGAY_TRA <= _to))
            {
                l.Add(new CChiTietNoVay
                {
                    NGAYVAY = _r.NGAY_TRA.Date,
                    TONGTIEN = 0,
                    LAISUAT = 0,
                    THOIDOAN = "Trả nợ vay",
                    TRAGOC = _r.TIEN_GOC,
                    TRALAI = _r.TIEN_LAI
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
