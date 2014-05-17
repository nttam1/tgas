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
    public partial class FTraNoNCC : Form
    {
        private BindingSource bs = new BindingSource();

        public FTraNoNCC()
        {
            InitializeComponent();
        }

        private void FTraNoNCC_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 1);
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
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void comboBoxNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kho = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var ncc = Convert.ToInt32(comboBoxNCC.SelectedValue.ToString());

                bs.DataSource = DataInstance.Instance().DBContext().TRA_NO_NCC.Where(u => u.MANCC == ncc)
                    .Where(u => u.MAKHO == kho);
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
                var ngay = dateTimePicker1.Value;
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
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNCC_SelectedIndexChanged(sender, e);
        }
    }
}
