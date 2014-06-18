using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager.Modal;

namespace T_Manager
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void buttonNhapHang_Click(object sender, EventArgs e)
        {
            FNhapHang f = new FNhapHang();
            f.ShowDialog();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            DataInstance.Instance().DBContext();
            DateTime now = DateTime.Now;
            DateTime last = Convert.ToDateTime(MHeTHong.Get(MHeTHong.DATE));
            if (last.Date > now.Date)
            {
                FConfirm F = new FConfirm();
                F.ShowDialog();
            }
            else
            {
                MHeTHong.Set(MHeTHong.DATE, DateTime.Now.ToShortDateString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FXuatHang f = new FXuatHang();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FChi f = new FChi();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FChoVay f = new FChoVay();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FThuNo f = new FThuNo();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FVay f = new FVay();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FTraNoVay f = new FTraNoVay();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FTraNoNCC f = new FTraNoNCC();
            f.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            FKhachHang f = new FKhachHang();
            f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Data.FKho f = new Data.FKho();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FNhanVien f = new FNhanVien();
            f.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Data.FNguonVay f = new Data.FNguonVay();
            f.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Data.FXe f = new Data.FXe();
            f.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Data.FNCC f = new Data.FNCC();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Data.FTaiKhoan f = new Data.FTaiKhoan();
            f.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Data.FHangHoa f = new Data.FHangHoa();
            f.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            REPORT.FChiTietLaiKH f = new REPORT.FChiTietLaiKH();
            f.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            REPORT.FTongHopCongNo f = new REPORT.FTongHopCongNo();
            f.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            REPORT.FChiTietNoNCC f = new REPORT.FChiTietNoNCC();
            f.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            REPORT.FTongHopNoNCC f = new REPORT.FTongHopNoNCC();
            f.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            REPORT.FChiTietNoVay f = new REPORT.FChiTietNoVay();
            f.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            FBanHang f = new FBanHang();
            f.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            REPORT.FTongHopNoVay f = new REPORT.FTongHopNoVay();
            f.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            REPORT.FNhapXuatTungKho f = new REPORT.FNhapXuatTungKho();
            f.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            REPORT.FChiTungKho f = new REPORT.FChiTungKho();
            f.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            REPORT.FLaiLoTungKho f = new REPORT.FLaiLoTungKho();
            f.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            REPORT.FChiTietThanhToanNCC f = new REPORT.FChiTietThanhToanNCC();
            f.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            REPORT.FXemKhoQuy f = new REPORT.FXemKhoQuy();
            f.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            REPORT.FCongSoHangNgay f = new REPORT.FCongSoHangNgay();
            f.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FChuyenTien f = new FChuyenTien();
            f.ShowDialog();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            REPORT.FChiTietChuyenTien f = new REPORT.FChiTietChuyenTien();
            f.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            FChinhSua f = new FChinhSua();
            f.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            EDIT.FXuatHang f = new EDIT.FXuatHang();
            f.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            EDIT.FThuNo f = new EDIT.FThuNo();
            f.ShowDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            FDoiMatKhau f = new FDoiMatKhau();
            f.ShowDialog();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button34_Click(object sender, EventArgs e)
        {
            REPORT.FCongNoKH f = new REPORT.FCongNoKH();
            f.ShowDialog();
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            REPORT.FChiXe f = new REPORT.FChiXe();
            f.ShowDialog();
        }
    }
}
