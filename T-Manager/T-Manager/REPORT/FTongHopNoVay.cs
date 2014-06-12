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
    public partial class FTongHopNoVay : Form
    {
        public FTongHopNoVay()
        {
            InitializeComponent();
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _from = dateTimePickerFROM.Value.Date;
            var _to = dateTimePickerTO.Value.Date;

            BindingSource bs = new BindingSource();
            var rows = (from v in DataInstance.Instance().DBContext().VAYs
                        join nv in DataInstance.Instance().DBContext().NGUON_VAY on v.MA_NGUON_VAY equals nv.ID
                        where v.NGAY_VAY >= _from && v.NGAY_VAY <= _to
                        orderby v.NGAY_VAY ascending
                        group v by new { v.MA_NGUON_VAY, nv.NAME } into g
                        select new CTongHopNoVay
                        {
                            NGUONVAY = g.Key.NAME,
                            TONGTIEN = g.Sum(u => u.TONG_TIEN),
                            TRAGOC = 0,
                            TRALAI = 0,
                            NGUONVAYID = g.Key.MA_NGUON_VAY
                        });
            List<CTongHopNoVay> l = new List<CTongHopNoVay>();
            foreach (CTongHopNoVay _r in rows)
            {
                CThanhToan _tt = MVay.THANHTOAN(_r.NGUONVAYID, _from.Date, _to.Date);
                _r.TRALAI = _tt.LAI;
                _r.TRAGOC = _tt.GOC;
                l.Add(_r);
            }
            bs.DataSource = l;
            CrystalReportTONGHOPNOVAY rpt = new CrystalReportTONGHOPNOVAY();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void FTongHopNoVay_Load(object sender, EventArgs e)
        {
            dateTimePickerFROM.Value = dateTimePickerTO.Value.AddMonths(-1);
        }
    }

    class CTongHopNoVay
    {
        public string NGUONVAY;
        public long NGUONVAYID;
        public long TONGTIEN;
        public long TRAGOC;
        public long TRALAI;
    }
}
