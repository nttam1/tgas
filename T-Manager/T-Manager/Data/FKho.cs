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
    public partial class FKho : Form
    {
        public FKho()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private void FKho_Load(object sender, EventArgs e)
        {
            bs.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 0);
            dataGridViewKHACHHANG.DataSource = bs;
            dataGridViewKHACHHANG.Columns[0].HeaderText = "MÃ KHO";
            dataGridViewKHACHHANG.Columns[2].Visible = false;
            dataGridViewKHACHHANG.Columns[3].Visible = false;
            dataGridViewKHACHHANG.Columns[1].HeaderText = "TÊN KHO";
            dataGridViewKHACHHANG.AutoResizeColumns();
            dataGridViewKHACHHANG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (textBoxKHACHHANG.Text == "")
            {
                MessageBox.Show("Chưa nhập tên kho mới");
                return;
            }
            bs.Add(new KHO()
            {
                NAME = textBoxKHACHHANG.Text,
                CODE = "",
                TYPE = 0
            }
            );
            bs.EndEdit();
            bs.ResetBindings(false);
            DataInstance.Instance().DBContext().SaveChanges();
            textBoxKHACHHANG.Text = "";
            textBoxKHACHHANG.Select();
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
