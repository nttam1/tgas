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
    public partial class FInit : Form
    {
        public FInit()
        {
            InitializeComponent();
        }

        private void buttonPASS_Click(object sender, EventArgs e)
        {
            string pass = textBoxPASS.Text;
            string repass = textBoxREPASS.Text;
            if (pass != repass)
            {
                MessageBox.Show("Mật khẩu không trùng nhau");
                return;
            }
            MHeTHong.Set(MHeTHong.MATKHAU, pass);
        }
    }
}
