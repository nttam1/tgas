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
    public partial class FTraNoNCC : Form
    {
        private BindingSource bs = new BindingSource();

        public FTraNoNCC()
        {
            InitializeComponent();
        }

        private void FTraNoNCC_Load(object sender, EventArgs e)
        {
            if (MKho.Get(MKho.KHO_HANG).Count() == 0 || MNcc.Get().Count() == 0)
            {
                MessageBox.Show("CẦN TẠO KHO VÀ NHÀ CUNG CẤP TRƯỚC");
                this.Close();
                return;
            }
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE <= 1).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxNCC.DataSource = T_Manager.Modal.MNcc.Get() ;//DataInstance.Instance().DBContext().NHA_CUNG_CAP;
            comboBoxNCC.DisplayMember = "NAME";
            comboBoxNCC.ValueMember = "ID";

            comboBoxNCC_SelectedIndexChanged(sender, e);

            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                }
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void comboBoxNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kho = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var ncc = Convert.ToInt32(comboBoxNCC.SelectedValue.ToString());
                DateTime now = dateTimePicker1.Value.Date;
                bs.DataSource = DataInstance.Instance().DBContext().TRA_NO_NCC.Where(u => u.MANCC == ncc)
                    .Where(u => u.MAKHO == kho)
                    .Where(u => u.NGAY_TRA == now);
                dataGridView1.DataSource = bs;
                
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[2].HeaderText = "TỔNG TIỀN";
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].HeaderText = "NGÀY TRẢ";
                
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var kho = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var ncc = Convert.ToInt32(comboBoxNCC.SelectedValue.ToString());
                var tien = Int32.Parse(textBoxTONGTIEN.Text);
                var ngay = dateTimePicker1.Value.Date;
                if (tien == 0)
                {
                    MessageBox.Show("TIỀN TRẢ KHÔNG ĐƯỢC BẰNG 0");
                    return;
                }
                bs.Add(new TRA_NO_NCC()
                {
                    MANCC = ncc,
                    MAKHO = kho,
                    TONG_TIEN = tien,
                    NGAY_TRA = ngay,
                    CREATED_AT = DateTime.Now
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxTONGTIEN.Text = "0";
                comboBoxKHO.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không phù hợp");
            }
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNCC_SelectedIndexChanged(sender, e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBoxKHO_SelectedIndexChanged(sender, e);
        }

        private void comboBoxKHO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }
        }
    }
}
