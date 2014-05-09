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
    public partial class FKhachHang : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        private BindingSource bs = new BindingSource();
        public FKhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            bs.DataSource = dbContext.KHACH_HANG;
            dataGridViewKHACHHANG.DataSource = bs;
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                bs.Add(new KHACH_HANG() { NAME = textBoxKHACHHANG.Text });
                bs.EndEdit();
                bs.ResetBindings(false);
                textBoxKHACHHANG.Text = "";
                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxKHACHHANG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonADD_Click(sender, e);
            }
        }
    }
}
