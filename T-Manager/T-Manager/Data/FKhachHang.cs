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
            dataGridViewKHACHHANG.Columns[0].Visible = false;
            dataGridViewKHACHHANG.Columns[1].HeaderText = "TÊN KHÁCH HÀNG";
            dataGridViewKHACHHANG.AutoResizeColumns();
            dataGridViewKHACHHANG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (textBoxKHACHHANG.Text == "")
            {
                MessageBox.Show("Chưa nhập tên khách hàng");
                return;
            }
            try
            {
                bs.Add(new KHACH_HANG() { NAME = textBoxKHACHHANG.Text });
                bs.EndEdit();
                bs.ResetBindings(false);
                dbContext.SaveChanges();
                textBoxKHACHHANG.Text = "";
                textBoxKHACHHANG.Select();
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

        private void textBoxKHACHHANG_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
