using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Entity;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.Objects;

namespace T_Manager.REPORT
{
    public partial class FCongNoKH : Form
    {
        public FCongNoKH()
        {
            InitializeComponent();
        }



        private void FCongNoKH_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = DataInstance.Instance().DBContext().KHACH_HANG;
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "ID";

            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
        }

        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportViewerKH_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var include_THUNO = checkBoxTHUNO.Checked;
            BindingSource bs = new BindingSource();
            long MAKH = long.Parse(comboBox1.SelectedValue.ToString());
            if (include_THUNO == true)
            {
                bs.DataSource = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                 join hh in DataInstance.Instance().DBContext().HANG_HOA on xh.MAHH equals hh.ID
                                 join kho in DataInstance.Instance().DBContext().KHOes on xh.MAKHO equals kho.ID
                                 join kh in DataInstance.Instance().DBContext().KHACH_HANG on xh.MAKH equals kh.ID
                                 where xh.NGAY_XUAT >= dateTimePicker1.Value
                                 where xh.NGAY_XUAT <= dateTimePicker2.Value
                                 where xh.MAKH == MAKH
                                 orderby xh.NGAY_XUAT ascending
                                 select new
                                 {
                                     DATE = xh.NGAY_XUAT.Value,
                                     KHO = kho.NAME,
                                     HANGHOA = hh.NAME,
                                     SOLUONG = xh.SO_LUONG,
                                     DONGIABAN = xh.DON_GIA_BAN,
                                     THANHTIEN = xh.SO_LUONG * xh.DON_GIA_BAN,
                                     THANHTOAN = xh.TRA_TRUOC,
                                     CONNO = xh.SO_LUONG * xh.DON_GIA_BAN - xh.TRA_TRUOC,
                                     KHACHHANG = kh.NAME,
                                     DATRA = 0,//xh.DA_TRA.Value,
                                     NGAYTRA = 0,//xh.NGAY_TRA.Value,
                                     LAISUAT = xh.LAI_SUAT
                                 });
            }
            else
            {
                bs.DataSource = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                                 join hh in DataInstance.Instance().DBContext().HANG_HOA on xh.MAHH equals hh.ID
                                 join kho in DataInstance.Instance().DBContext().KHOes on xh.MAKHO equals kho.ID
                                 join kh in DataInstance.Instance().DBContext().KHACH_HANG on xh.MAKH equals kh.ID
                                 where xh.NGAY_XUAT >= dateTimePicker1.Value
                                 where xh.NGAY_XUAT <= dateTimePicker2.Value
                                 where xh.MAKH == MAKH
                                 orderby xh.NGAY_XUAT ascending
                                 select new
                                 {
                                     DATE = xh.NGAY_XUAT.Value,
                                     KHO = kho.NAME,
                                     HANGHOA = hh.NAME,
                                     SOLUONG = xh.SO_LUONG,
                                     DONGIABAN = xh.DON_GIA_BAN,
                                     THANHTIEN = xh.SO_LUONG * xh.DON_GIA_BAN,
                                     THANHTOAN = xh.TRA_TRUOC,
                                     CONNO = xh.SO_LUONG * xh.DON_GIA_BAN - xh.TRA_TRUOC,
                                     KHACHHANG = kh.NAME,
                                     DATRA = 0,
                                     NGAYTRA = 0,//xh.NGAY_TRA.Value,
                                     LAISUAT = xh.LAI_SUAT
                                 });
            }
            CrystalReportCongNoKhachHang rpt = new CrystalReportCongNoKhachHang();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KH", comboBox1.Text);
            rpt.SetParameterValue("FROM", dateTimePicker1.Value);
            rpt.SetParameterValue("TO", dateTimePicker2.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FCongNoKH_Resize(object sender, EventArgs e)
        {
            crystalReportViewer1.Height = this.Height - 20 - groupBox1.Height;
            crystalReportViewer1.Width = this.Width;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

    class CCongNoKhachHang
    {
        public DateTime NGAY;
        public string KHO;
        public string HANGHOA;
        public Int64 SOLUONG;
        public Int64 DONGIA;
        public Int64 THANHTIEN;
        public Int64 TRATRUOC;
        public double LAISUAT;
        public double LAI;
        public Int64 TRAGOC;
        public Int64 TRALAI;
        public Int64 CONNO;
    }
}
