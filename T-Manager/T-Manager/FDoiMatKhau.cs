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
    public partial class FDoiMatKhau : Form
    {
        public FDoiMatKhau()
        {
            InitializeComponent();
        }

        private void buttonCHANGE_Click(object sender, EventArgs e)
        {
            if (MHeTHong.Get(MHeTHong.MATKHAU) != textBoxOLDPASS.Text)
            {
                MessageBox.Show("MẬT KHẨU CŨ KHÔNG ĐÚNG");
                return;
            }
            if (textBoxNEWPASS.Text != textBoxRENEWPASS.Text)
            {
                MessageBox.Show("MẬT KHẨU MỚI KHÔNG GIỐNG NHAU");
                return;
            }
            MHeTHong.Set(MHeTHong.MATKHAU, textBoxNEWPASS.Text);
            MessageBox.Show("ĐỔI MẬT KHẨU MỚI THÀNH CÔNG");
        }
    }
}
