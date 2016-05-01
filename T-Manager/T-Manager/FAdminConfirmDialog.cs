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
    public partial class FAdminConfirmDialog : Form
    {
        public FAdminConfirmDialog()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)   
            {
                if (textBoxPwd.Text == MHeTHong.Get(MHeTHong.MATKHAU))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng!!!!");
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
                this.Dispose();
            }
        }

        private void textBoxPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
