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
    public partial class FThuNo : Form
    {
        public FThuNo()
        {
            InitializeComponent();
        }

        private void FThuNo_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 0);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxKHACHHANG.DataSource = DataInstance.Instance().DBContext().KHACH_HANG;
            comboBoxKHACHHANG.DisplayMember = "NAME";
            comboBoxKHACHHANG.ValueMember = "ID";

            comboBoxKHO_SelectedIndexChanged(sender, e);

            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.KeyPress +=new KeyPressEventHandler(c_KeyPress);
                }
            }
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private BindingSource bs = new BindingSource();
        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                bs.DataSource = DataInstance.Instance().DBContext().THU_NO.Where(u => u.MAKHO == kho)
                    .Where(u => u.MAKH == kh);
                dataGridViewTHUNO.DataSource = bs;
                dataGridViewTHUNO.Columns[0].Visible = false;
                dataGridViewTHUNO.Columns[1].Visible = false;
                dataGridViewTHUNO.Columns[2].Visible = false;
                dataGridViewTHUNO.Columns[3].HeaderText = "Tiền gốc";
                dataGridViewTHUNO.Columns[4].HeaderText = "Tiền lãi";
                dataGridViewTHUNO.Columns[5].HeaderText = "Ngày trả";
                dataGridViewTHUNO.ReadOnly = true;
            }
            catch (Exception ex)
            {

            }

        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                var goc = Int32.Parse(textBoxTIENGOC.Text);
                var lai = Int32.Parse(textBoxTIENLAI.Text);
                bs.Add(new THU_NO()
                {
                    MAKH = kh,
                    MAKHO = kho,
                    TIEN_GOC = goc,
                    TIEN_LAI = lai,
                    NGAY_TRA = DateTime.Now
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxTIENGOC.Text = "";
                textBoxTIENLAI.Text = "";
            }
            catch (Exception ex)
            {
            }

        }

        private void textBoxTIENLAI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonADD_Click(sender, e);
            }
        }
    }
}
