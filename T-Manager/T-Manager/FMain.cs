using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            REPORT.FCongNoKH f = new REPORT.FCongNoKH();
            f.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            REPORT.FTongHopCongNo f = new REPORT.FTongHopCongNo();
            f.ShowDialog();
        }
    }
}
