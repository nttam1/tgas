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
    public partial class FChiTietThanhToanNCC : Form
    {
        public FChiTietThanhToanNCC()
        {
            InitializeComponent();
        }

        private void FChiTietThanhToanNCC_Load(object sender, EventArgs e)
        {

            comboBoxNCC.DataSource = T_Manager.Modal.MNcc.Get().OrderBy(u => u.NAME);
            comboBoxNCC.DisplayMember = "NAME";
            comboBoxNCC.ValueMember = "ID";

            dateTimePickerFROM.Value = dateTimePickerFROM.Value.AddMonths(-1);
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            var _ncc = long.Parse(comboBoxNCC.SelectedValue.ToString());
            var _from = dateTimePickerFROM.Value.Date;
            var _to = dateTimePickerTO.Value.Date;
            BindingSource bs = new BindingSource();
            bs.DataSource = (from _n in DataInstance.Instance().DBContext().TRA_NO_NCC
                             join _kho in DataInstance.Instance().DBContext().KHOes on _n.MAKHO equals _kho.ID
                             where _n.MANCC == _ncc
                             where _n.NGAY_TRA >= _from && _n.NGAY_TRA <= _to
                             select new CChiTietThanhToanNCC
                             {
                                 NGAY = _n.NGAY_TRA,
                                 THANHTOAN = _kho.NAME,
                                 TONGTIEN = _n.TONG_TIEN
                             }
                             );
            CrystalReportCHITIETTHANHTOANNCC rpt = new CrystalReportCHITIETTHANHTOANNCC();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("NCC", comboBoxNCC.Text);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
        }

    }

    class CChiTietThanhToanNCC
    {
        public DateTime NGAY;
        public string THANHTOAN;
        public long TONGTIEN;
    }

}
