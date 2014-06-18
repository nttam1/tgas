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
            string note = "";
            long da_tra = 0;
            var _from = dateTimePickerFROM.Value;
            var _to = dateTimePickerTO.Value;

            BindingSource bs = new BindingSource();
            List<CTongHopNoNCC> dt = new List<CTongHopNoNCC>();
            var _nh = (from nh in DataInstance.Instance().DBContext().NHAP_HANG
                       join ncc in DataInstance.Instance().DBContext().NHA_CUNG_CAP on nh.MANCC equals ncc.ID
                       join hh in DataInstance.Instance().DBContext().HANG_HOA on nh.MAHH equals hh.ID
                       /* Khac ton kho */
                       where nh.NGAY_NHAP >= _from && nh.NGAY_NHAP <= _to
                       select new CTongHopNoNCC
          {
              NCC = ncc.NAME,
              HANGHOA = hh.NAME,
              SOLUONG = nh.SO_LUONG,
              THANHTIEN = nh.SO_LUONG * nh.DON_GIA_MUA,
          });
            foreach (CTongHopNoNCC row in _nh)
            {
                dt.Add(new CTongHopNoNCC
                {
                    NCC = row.NCC,
                    HANGHOA = row.HANGHOA,
                    SOLUONG = row.SOLUONG,
                    THANHTIEN = row.THANHTIEN,
                });
            }
            var _tn = (from nh in DataInstance.Instance().DBContext().TRA_NO_NCC
                       join ncc in DataInstance.Instance().DBContext().NHA_CUNG_CAP on nh.MANCC equals ncc.ID
                       where nh.NGAY_TRA >= _from && nh.NGAY_TRA <= _to
                       select new CTongHopNoNCC
                       {
                           NCC = ncc.NAME,
                           HANGHOA = "z Trả Nợ z",
                           SOLUONG = 0,
                           THANHTIEN = - nh.TONG_TIEN,
                       });
            foreach (CTongHopNoNCC row in _tn)
            {
                dt.Add(new CTongHopNoNCC
                {
                    NCC = row.NCC,
                    HANGHOA = row.HANGHOA,
                    SOLUONG = row.SOLUONG,
                    THANHTIEN = row.THANHTIEN,
                });
            }
            bs.DataSource = dt;
            CrystalReportTONGHOPNONCC rpt = new CrystalReportTONGHOPNONCC();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void FTongHopNoNCC_Load(object sender, EventArgs e)
        {
            dateTimePickerFROM.Value = dateTimePickerFROM.Value.AddMonths(-1);
        }
    }

    class CTongHopNoNCC
    {
        public string NCC;
        public string HANGHOA;
        public long SOLUONG;
        public long THANHTIEN;
    }
}
