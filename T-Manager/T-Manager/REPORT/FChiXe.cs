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
    public partial class FChiXe : Form
    {
        public FChiXe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long xe = long.Parse(comboBox1.SelectedValue.ToString());
            DateTime from = dateTimePickerFROM.Value.Date;
            DateTime to = dateTimePickerTO.Value.Date;
            var lst = DataInstance.Instance().DBContext().CHI_TIEU_DUNG_NOI_BO.Where(u => u.MAXE == xe)
                .Where(u => u.NGAY_CHI >= from && u.NGAY_CHI <= to)
                .OrderBy(u => u.NGAY_CHI);
            List<object> list = new List<object>();
            foreach (CHI_TIEU_DUNG_NOI_BO nb in lst)
            {
                list.Add(new
                {
                    NGAY = nb.NGAY_CHI,
                    KHO = MKho.GetNamebyID(nb.MAKHO),
                    NOIDUNG = nb.NOI_DUNG,
                    HANGHOA = nb.MAHH == -1 ? "" : MHangHoa.GetNameByID(nb.MAHH),
                    SOLUONG = nb.SO_LUONG,
                    DONGIA = nb.DON_GIA_BAN,
                    THANHTIEN = nb.TONG_TIEN,
                });
            }
            CrystalReportCHIDUNGCHOXE rpt = new CrystalReportCHIDUNGCHOXE();
            rpt.SetDataSource(list);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            rpt.SetParameterValue("KH", comboBox1.Text);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }

        private void FChiXe_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = DataInstance.Instance().DBContext().XEs.OrderBy(u => u.BIEN_SO);
            comboBox1.DisplayMember = "BIEN_SO";
            comboBox1.ValueMember = "ID";
        }
    }
}
