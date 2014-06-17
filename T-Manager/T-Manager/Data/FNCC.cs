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
    public partial class FNCC : Form
    {
        public FNCC()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private void FNCC_Load(object sender, EventArgs e)
        {
            bs.DataSource = DataInstance.Instance().DBContext().NHA_CUNG_CAP;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
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
                    MessageBox.Show("Chưa nhập tên nhà cung cấp");
                }
                bs.Add(new NHA_CUNG_CAP()
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
                MessageBox.Show(ex.Message);
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
