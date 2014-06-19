using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager.Modal;

namespace T_Manager.Data
{
    public partial class FTaiKhoan : Form
    {
        public FTaiKhoan()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private void FTaiKhoan_Load(object sender, EventArgs e)
        {
            bs.DataSource = MKho.Get(MKho.KHO_TK_NGANHANG);
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].HeaderText = "MÃ";
            dataGridView1.Columns[1].HeaderText = "TÊN";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "SỐ TÀI KHOẢN";
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBoxTEN.Select();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSO.Text == "" || textBoxTEN.Text == "")
                {
                    MessageBox.Show("Chưa nhập số tài khoản hoặc tên");
                    return;
                }
                bs.Add(new KHO()
                {
                    NAME = textBoxTEN.Text,
                    TYPE = MKho.KHO_TK_NGANHANG,
                    CODE = textBoxSO.Text
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxSO.Text = "";
                textBoxTEN.Text = "";
                textBoxTEN.Select();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxTEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxSO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonADD_Click(sender, e);
            }
        }
    }
}
