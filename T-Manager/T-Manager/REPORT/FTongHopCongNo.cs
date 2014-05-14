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
    public partial class FTongHopCongNo : Form
    {
        public FTongHopCongNo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            var _from = dateTimePicker1.Value;
            var _to = dateTimePicker2.Value;

            BindingSource bs = new BindingSource();
            bs.DataSource = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                             join kh in DataInstance.Instance().DBContext().KHACH_HANG on xh.MAKH equals kh.ID
                             where xh.MAKHO == kho
                             where xh.NGAY_XUAT >= _from
                             where xh.NGAY_XUAT <= _to
                             group xh by new {xh.MAKH, kh.NAME} into g
                             select new
                             {
                                 STT = g.Key.MAKH,
                                 KHACHHANG = g.Key.NAME,
                                 TIENNO = g.Sum(xh => xh.SO_LUONG * xh.DON_GIA_BAN),
                                 THANHTOAN = g.Sum(xh => xh.TRA_TRUOC),
                                 CONNO = g.Sum(xh => xh.SO_LUONG * xh.DON_GIA_BAN - xh.TRA_TRUOC)
                             });
            CrystalReportTONGHOPCONGNO rpt = new CrystalReportTONGHOPCONGNO();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KHO", comboBoxKHO.Text);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void FTongHopCongNo_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 0);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
        }
    }
}
