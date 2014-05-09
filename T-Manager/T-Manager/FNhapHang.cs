using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;

namespace T_Manager
{
    public partial class FNhapHang : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        DataTable table = new DataTable();

        public FNhapHang()
        {
            InitializeComponent();
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            comboBoxKho.DataSource = dbContext.KHOes.Where(u => u.TYPE == 0);
            comboBoxKho.DisplayMember = "NAME";
            comboBoxKho.ValueMember = "ID";

            comboBoxNCC.DataSource = dbContext.NHA_CUNG_CAP;
            comboBoxNCC.DisplayMember = "NAME";
            comboBoxNCC.ValueMember = "ID";

            comboBoxHANGHOA.DataSource = dbContext.HANG_HOA;
            comboBoxHANGHOA.DisplayMember = "NAME";
            comboBoxHANGHOA.ValueMember = "ID";

            dataGridView1.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "KHO";
            col1.HeaderText = "Kho";
            col1.Name = "column_KHO";
            dataGridView1.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "NCC";
            col2.HeaderText = "Nhà Cung Cấp";
            col2.Name = "column_NCC";
            dataGridView1.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "HANG_HOA";
            col3.HeaderText = "Hàng Hóa";
            col3.Name = "column_HANG_HOA";
            dataGridView1.Columns.Add(col3);

                            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.DataPropertyName = "DG_NHAP";
            col4.HeaderText = "Đơn Giá Nhập";
            col4.Name = "column_DG_NHAP";
            dataGridView1.Columns.Add(col4);

                        DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.DataPropertyName = "SO_LUONG";
            col5.HeaderText = "Số lượng";
            col5.Name = "column_SO_LUONG";
            dataGridView1.Columns.Add(col5);

                        DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.DataPropertyName = "NGAY_NHAP";
            col6.HeaderText = "Ngày Nhập";
            col6.Name = "column_NGAY_NHAP";
            dataGridView1.Columns.Add(col6);

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
                ele.NGAY_NHAP = dateTimePickerNGAYNHAP.Value;
                ele.CREATED_AT = dateTimePickerNGAYNHAP.Value;
                ele.SO_LUONG = Convert.ToInt32(textBoxSOLUONG.Text);
                ele.SL_CON_LAI = Convert.ToInt32(textBoxSOLUONG.Text);
                ele.DON_GIA_MUA = Convert.ToInt32(textBoxDONGIA.Text);
                ele.MAHH = Convert.ToInt32(comboBoxHANGHOA.SelectedValue.ToString());
                if (ele.SO_LUONG == 0 || ele.DON_GIA_MUA == 0)
                {
                    MessageBox.Show("Chưa nhập số lượng hoặc đơn giá");
                }
                else
                {
                    dbContext.AddToNHAP_HANG(ele);
                    dbContext.SaveChanges();
                    textBoxDONGIA.SelectAll();
                    dataGridView1.Rows.Add(comboBoxKho.Text, comboBoxNCC.Text, comboBoxHANGHOA.Text, ele.DON_GIA_MUA, ele.SO_LUONG, ele.NGAY_NHAP.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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
    }
}
