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
using T_Manager.Modal;

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

            dateTimePickerFROM.Value = dateTimePickerFROM.Value.AddMonths(-1);
        }

        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportViewerKH_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CCongNoKhachHang> _datasource = new List<CCongNoKhachHang>();
            var include_THUNO = checkBoxTHUNO.Checked;
            BindingSource bs = new BindingSource();
            long MAKH = long.Parse(comboBox1.SelectedValue.ToString());
            DateTime FROM = dateTimePickerFROM.Value.Date;
            DateTime TO = dateTimePickerTO.Value.Date;

            /* Lấy tất cả dữ liệu xuất hàng cho khách hàng này */
            /* Từ ngày đến ngày */
            IQueryable<CCongNoKhachHang> xuat_hang = (from _xh in DataInstance.Instance().DBContext().XUAT_HANG
                                                      join _kho in DataInstance.Instance().DBContext().KHOes on _xh.MAKHO equals _kho.ID
                                                      join _hh in DataInstance.Instance().DBContext().HANG_HOA on _xh.MAHH equals _hh.ID
                                                      where _xh.MAKH == MAKH
                                                      where _xh.NGAY_XUAT >= FROM && _xh.NGAY_XUAT <= TO
                                                      orderby _xh.NGAY_XUAT ascending
                                                      select new CCongNoKhachHang
                                                      {
                                                          ID = (int)_xh.ID,
                                                          NGAY = _xh.NGAY_XUAT.Value,
                                                          KHO = _kho.NAME,
                                                          HANGHOA = _hh.NAME,
                                                          SOLUONG = _xh.SO_LUONG,
                                                          DONGIABAN = _xh.DON_GIA_BAN,
                                                          THANHTIEN = _xh.SO_LUONG * _xh.DON_GIA_BAN,
                                                          TRATRUOC = _xh.TRA_TRUOC,
                                                          LAISUAT = _xh.LAI_SUAT,
                                                          LAI = 0,
                                                          TRAGOC = 0,
                                                          TRALAI = 0,
                                                          CONNO = 0
                                                      });

            if (include_THUNO == true)
            {
                /* Có sử dụng dữ liệu từ thu nợ */
                foreach (CCongNoKhachHang row in xuat_hang)
                {
                    double lai = MXuatHang.GetLaiPhatSinh(row.ID);
                    long tragoc = (long)MChiTietThuNo.TraGocHH(row.ID) ;
                    long tralai = (long)MChiTietThuNo.TraLaiHH(row.ID);
                    _datasource.Add(new CCongNoKhachHang()
                    {
                        NGAY = row.NGAY,
                        KHO = row.KHO,
                        HANGHOA = row.HANGHOA,
                        SOLUONG = row.SOLUONG,
                        DONGIABAN = row.DONGIABAN,
                        THANHTIEN = row.THANHTIEN,
                        TRATRUOC = row.TRATRUOC,
                        LAISUAT = row.LAISUAT * 100,
                        /* Cần tính lãi */
                        LAI = lai,
                        TRAGOC = tragoc,
                        TRALAI = tralai,
                        CONNO = row.THANHTIEN + (long)lai - row.TRATRUOC - tragoc - tralai
                    });
                }
            }
            else
            {
                /* Không sử dụng dữ liệu từ thu nợ */
                foreach (CCongNoKhachHang row in xuat_hang)
                {
                    double lai = Utility.Lai(row.NGAY, row.LAISUAT, row.THANHTIEN - row.TRATRUOC);
                    _datasource.Add(new CCongNoKhachHang()
                    {
                        NGAY = row.NGAY,
                        KHO = row.KHO,
                        HANGHOA = row.HANGHOA,
                        SOLUONG = row.SOLUONG,
                        DONGIABAN = row.DONGIABAN,
                        THANHTIEN = row.THANHTIEN,
                        TRATRUOC = row.TRATRUOC,
                        LAISUAT = row.LAISUAT * 100,
                        /* Cần tính lãi */
                        LAI = lai,
                        TRAGOC = 0,
                        TRALAI = 0,
                        CONNO = row.THANHTIEN + (long)lai - row.TRATRUOC
                    });
                }
            }
            bs.DataSource = _datasource;
            CrystalReportCongNoKhachHang rpt = new CrystalReportCongNoKhachHang();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KH", comboBox1.Text);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
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
        public int ID;
        public DateTime NGAY;
        public string KHO;
        public string HANGHOA;
        public Int64 SOLUONG;
        public Int64 DONGIABAN;
        public Int64 THANHTIEN;
        public Int64 TRATRUOC;
        public double LAISUAT;
        public double LAI;
        public Int64 TRAGOC;
        public Int64 TRALAI;
        public Int64 CONNO;
    }
}
