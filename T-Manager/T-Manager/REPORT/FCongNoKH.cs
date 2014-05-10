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
            BindingSource bs = new BindingSource();
            bs.DataSource = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                             join hh in DataInstance.Instance().DBContext().HANG_HOA on xh.MAHH equals hh.ID
                             join kho in DataInstance.Instance().DBContext().KHOes on xh.MAKHO equals kho.ID
                             join kh in DataInstance.Instance().DBContext().KHACH_HANG on xh.MAKH equals kh.ID
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
                                 LAISUAT = xh.LAI_SUAT
                             });
            CrystalReportCongNoKhachHang rpt = new CrystalReportCongNoKhachHang();
            rpt.SetDataSource(bs);
            crystalReportViewer1.ReportSource = rpt;

            crystalReportViewer1.RefreshReport();
        }

        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportViewerKH_Load(object sender, EventArgs e)
        {

        }
    }
}
