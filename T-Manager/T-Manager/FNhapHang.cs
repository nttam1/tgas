using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using T_Manager.Modal;

namespace T_Manager
{
    public partial class FNhapHang : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        DataTable table = new DataTable();
        BindingSource bs = new BindingSource();

        public FNhapHang()
        {
            InitializeComponent();
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            comboBoxKho.DataSource = T_Manager.Modal.MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);//dbContext.KHOes.Where(u => u.TYPE == 0);
            comboBoxKho.DisplayMember = "NAME";
            comboBoxKho.ValueMember = "ID";

            comboBoxNCC.DataSource = T_Manager.Modal.MNcc.Get().OrderBy(u => u.NAME);//dbContext.NHA_CUNG_CAP;
            comboBoxNCC.DisplayMember = "NAME";
            comboBoxNCC.ValueMember = "ID";

            comboBoxHANGHOA.DataSource = dbContext.HANG_HOA.OrderBy(u => u.NAME);
            comboBoxHANGHOA.DisplayMember = "NAME";
            comboBoxHANGHOA.ValueMember = "ID";
            dataGridView1.DataSource = bs;
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void dataGridViewNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSOLUONG_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                var ele = new NHAP_HANG();
                ele.MAKHO = Convert.ToInt32(comboBoxKho.SelectedValue.ToString());
                ele.MANCC = Convert.ToInt32(comboBoxNCC.SelectedValue.ToString());
                ele.NGAY_NHAP = dateTimePickerNGAYNHAP.Value.Date;
                ele.CREATED_AT = DateTime.Now;
                ele.SO_LUONG = Convert.ToInt32(textBoxSOLUONG.Text);
                ele.SL_CON_LAI = Convert.ToInt32(textBoxSOLUONG.Text);
                ele.DON_GIA_MUA = Convert.ToInt32(textBoxDONGIA.Text);
                ele.MAHH = Convert.ToInt32(comboBoxHANGHOA.SelectedValue.ToString());
                if (ele.SO_LUONG == 0 || ele.DON_GIA_MUA == 0)
                {
                    MessageBox.Show("Chưa nhập số lượng hoặc đơn giá");
                    return;
                }
                else
                {
                    bs.Add(ele);
                    bs.EndEdit();
                    bs.ResetBindings(false);
                    dbContext.SaveChanges();
                    textBoxDONGIA.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void buttonCLEAR_Click(object sender, EventArgs e)
        {
            textBoxSOLUONG.Text = "";
            textBoxDONGIA.Text = "";
        }

        private void comboBoxHANGHOA_SelectedValueChanged(object sender, EventArgs e)
        {
            string hh_id = ((ComboBox)sender).SelectedValue.ToString();
            try
            {
                long value = long.Parse(hh_id);
                var dvt = dbContext.HANG_HOA.Where(u => u.ID == value).Select(u => u.UNIT);
                labelDONVITINH.Text = dvt.FirstOrDefault().ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void textBoxDONGIA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void comboBoxHANGHOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime now = dateTimePickerNGAYNHAP.Value.Date;
                long kho = long.Parse(comboBoxKho.SelectedValue.ToString());
                long ncc = long.Parse(comboBoxNCC.SelectedValue.ToString());
                long hh = long.Parse(comboBoxHANGHOA.SelectedValue.ToString());
                bs.DataSource = dbContext.NHAP_HANG.Where(u => u.NGAY_NHAP == now && u.MAKHO == kho && u.MANCC == ncc && u.MAHH == hh);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "ĐƠN GIÁ";
                dataGridView1.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void comboBoxNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void comboBoxKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }
    }
}
