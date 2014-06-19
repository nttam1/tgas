using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_Manager.Data
{
    public partial class FNguonVay : Form
    {
        public FNguonVay()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private void FNguonVay_Load(object sender, EventArgs e)
        {
            bs.DataSource = DataInstance.Instance().DBContext().NGUON_VAY;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].HeaderText = "MÃ";
            dataGridView1.Columns[1].HeaderText = "TÊN";
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNGUONVAY.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên nguồn cung cấp");
                    return;
                }
                bs.Add(new NGUON_VAY()
                {
                    NAME = textBoxNGUONVAY.Text
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxNGUONVAY.Text = "";
                textBoxNGUONVAY.Select();
            }
            catch (Exception ex)
            {

            }
        }

        private void textBoxNGUONVAY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonADD_Click(sender, e);
            }
        }
    }
}
