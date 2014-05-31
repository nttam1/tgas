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
    public partial class FVay : Form
    {
        public FVay()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private void FVay_Load(object sender, EventArgs e)
        {
            comboBoxNGUONVAY.DataSource = DataInstance.Instance().DBContext().NGUON_VAY;
            comboBoxNGUONVAY.DisplayMember = "NAME";
            comboBoxNGUONVAY.ValueMember = "ID";

            comboBoxNGUONVAY_SelectedIndexChanged(sender, e);

            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                }
            }
            comboBoxTHOIGIAN.DataSource = MVay.ThoiDoan();
            comboBoxTHOIGIAN.DisplayMember = "NAME";
            comboBoxTHOIGIAN.ValueMember = "VALUE";
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar)) && (!(e.KeyChar == '.'));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nguon = Int32.Parse(comboBoxNGUONVAY.SelectedValue.ToString());
            var tien = Int32.Parse(textBoxTONGTIEN.Text);
            var laisuat = double.Parse(textBoxLAISUAT.Text);
            var ngayvay = dateTimePicker1.Value;
            bs.Add(new VAY()
            {
                MA_NGUON_VAY = nguon,
                TONG_TIEN = tien,
                LAI_SUAT = laisuat / 100,
                NGAY_VAY = ngayvay,
                CREATED_AT = DateTime.Now,
                KY_HAN = long.Parse(comboBoxTHOIGIAN.SelectedValue.ToString()),
                TRANG_THAI = MVay.CHUA_TRA_XONG
            });
            bs.EndEdit();
            bs.ResetBindings(false);
            DataInstance.Instance().DBContext().SaveChanges();
        }

        private void comboBoxNGUONVAY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var nguon = Int32.Parse(comboBoxNGUONVAY.SelectedValue.ToString());
                bs.DataSource = DataInstance.Instance().DBContext().VAYs.Where(u => u.MA_NGUON_VAY == nguon);
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Tổng tiền";
                dataGridView1.Columns[3].HeaderText = "Lãi suất";
                dataGridView1.Columns[4].HeaderText = "Ngày vay";
            }
            catch(Exception ex)
            {
            }
        }
    }
}
