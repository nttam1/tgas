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
    public partial class FConfirm : Form
    {
        public FConfirm()
        {
            InitializeComponent();
        }

        private void buttonCONFIRM_Click(object sender, EventArgs e)
        {
            String eee = MHeTHong.Get(MHeTHong.MATKHAU);
            if (MHeTHong.Get(MHeTHong.MATKHAU) == textBox1.Text)
            {
                MHeTHong.Set(MHeTHong.DATE, DateTime.Now.ToShortDateString());
                MessageBox.Show("ĐÃ CẬP NHẬT NGÀY THÁNG CỦA CHƯƠNG TRÌNH");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("MẬT KHẨU KHÔNG ĐÚNG");
            }
        }

        private void FConfirm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
