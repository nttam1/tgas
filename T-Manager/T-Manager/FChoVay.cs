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
    public partial class FChoVay : Form
    {
        public FChoVay()
        {
            InitializeComponent();
        }

        private void FChoVay_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 0);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
            comboBoxKHACHHANG.DataSource = DataInstance.Instance().DBContext().KHACH_HANG;
            comboBoxKHACHHANG.DisplayMember = "NAME";
            comboBoxKHACHHANG.ValueMember = "ID";
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }

        private BindingSource bs = new BindingSource();

        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                bs.DataSource = DataInstance.Instance().DBContext().CHO_VAY.Where(u => u.MAKHO == kho)
                    .Where(u => u.MA_NGUON_NO == kh);
                dataGridViewCHOVAY.DataSource = bs;
                dataGridViewCHOVAY.Columns[0].Visible = false;
                dataGridViewCHOVAY.Columns[1].Visible = false;
                dataGridViewCHOVAY.Columns[2].Visible = false;
                dataGridViewCHOVAY.Columns[6].Visible = false;
                dataGridViewCHOVAY.Columns[7].Visible = false;
                dataGridViewCHOVAY.Columns[8].Visible = false;
                dataGridViewCHOVAY.Columns[9].Visible = false;
                dataGridViewCHOVAY.Columns[3].HeaderText = "Tổng tiền";
                dataGridViewCHOVAY.Columns[4].HeaderText = "Lãi suất";
                dataGridViewCHOVAY.Columns[5].HeaderText = "Ngày cho vay";
            }
            catch (Exception ex)
            {
            }
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }

        private void textBoxTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void textBoxTONGTIEN_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLAISUAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar)) && (!(e.KeyChar == '.'));
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (textBoxTONGTIEN.Text == "" || textBoxTONGTIEN.Text == "")
            {
                MessageBox.Show("Chưa nhập tiền cho vay hoặc lãi suất");
                return;
            }
            try
            {
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                var kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                var tien = Int32.Parse(textBoxTONGTIEN.Text);
                var lai = double.Parse(textBoxLAISUAT.Text);
                bs.Add(new CHO_VAY()
                {
                    MAKHO = kho,
                    MA_NGUON_NO = kh,
                    TONG_TIEN = tien,
                    LAI_SUAT = lai,
                    NGAY_CHO_VAY = DateTime.Now,
                    CREATED_AT = DateTime.Now,
                    DA_TRA = 0,
                    TRA_XONG = MChoVay.CHUA_TRA_XONG,                
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập liệu");
            }
        }
    }
}
