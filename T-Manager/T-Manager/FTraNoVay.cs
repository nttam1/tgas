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
    public partial class FTraNoVay : Form
    {
        public FTraNoVay()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();

        private void FTraNoVay_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 1);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

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
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void comboBoxNGUONVAY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kho = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var nguonvay = Convert.ToInt32(comboBoxNGUONVAY.SelectedValue.ToString());

                bs.DataSource = DataInstance.Instance().DBContext().TRA_NO_VAY.Where(u => u.MA_NGUON_VAY == nguonvay)
                    .Where(u => u.MAKHO == kho);
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[3].HeaderText = "TIỀN GỐC";
                dataGridView1.Columns[4].HeaderText = "TIỀN LÃI";
                dataGridView1.Columns[5].HeaderText = "NGÀY TRẢ";
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
                var nguonvay = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var goc = Convert.ToInt32(textBoxTONGTIEN.Text);
                var lai = Convert.ToInt32(textBoxTIENLAI.Text);
                var ngay = dateTimePicker1.Value;
                bs.Add(new TRA_NO_VAY()
                {
                    MAKHO = kho,
                    MA_NGUON_VAY = nguonvay,
                    TIEN_GOC = goc,
                    TIEN_LAI = lai,
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
            comboBoxNGUONVAY_SelectedIndexChanged(sender, e);
        }
    }
}
