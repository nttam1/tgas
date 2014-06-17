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
    public partial class FXuatHang : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        private BindingSource bs = new BindingSource();
        public FXuatHang()
        {
            InitializeComponent();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                var ele = new XUAT_HANG();
                ele.MAKHO = Convert.ToInt32(comboBoxKho.SelectedValue.ToString());
                if (checkBoxBANMAT.Checked == true)
                {
                    ele.MAKH = MXuatHang.MAKH_XUAT_MAT;
                    ele.TRA_TRUOC = 0;
                    ele.LAI_SUAT = 0;
                }
                else
                {
                    ele.MAKH = Convert.ToInt32(comboBoxKHACH_HANG.SelectedValue.ToString());
                    ele.TRA_TRUOC = Convert.ToInt32(textBoxDUATRUOC.Text);
                    ele.LAI_SUAT = Convert.ToDouble(textBoxLAISUAT.Text) / 100;
                }
                ele.NGAY_XUAT = dateTimePickerNGAYBAN.Value.Date;
                ele.CREATED_AT = DateTime.Now;
                ele.SO_LUONG = Convert.ToInt32(textBoxSOLUONG.Text);
                ele.DON_GIA_BAN = Convert.ToInt32(textBoxDONGIA.Text);
                ele.MAHH = Convert.ToInt32(comboBoxHANGHOA.SelectedValue.ToString());
                ele.TRANG_THAI = MXuatHang.CHUA_TRA_XONG;
                ele.THANH_TIEN = ele.SO_LUONG * ele.DON_GIA_BAN;

                if (ele.DON_GIA_BAN < 0 || ele.TRA_TRUOC < 0 || ele.LAI_SUAT < 0)
                {
                    MessageBox.Show("Đơn giá, trả trước, lãi suất không được nhỏ hơn 0");
                    return;

                }
                if (ele.DON_GIA_BAN == 0 && ele.SO_LUONG == 0)
                {
                    if (ele.TRA_TRUOC == 0)
                    {
                        MessageBox.Show("Dữ liệu nhập vào không hợp lệ");
                        textBoxDUATRUOC.Select();
                        textBoxDUATRUOC.SelectAll();
                        return;
                    }
                }
                if (ele.DON_GIA_BAN < ConstClass.DON_GIA_BASE && ele.SO_LUONG > 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ"); 
                    textBoxDONGIA.Select();
                    textBoxDONGIA.SelectAll();
                    return;
                }
                long lton = MKho.Ton(ele.MAKHO, ele.MAHH);
                if (ele.SO_LUONG > lton)
                {
                    MessageBox.Show("Số lượng bán hàng lớn hơn số lượng tồn.\nCòn tồn: " + lton.ToString(), "Lỗi số lượng!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxHANGHOA.Select();
                    return;
                }

                bs.Add(ele);
                bs.EndEdit();
                bs.ResetBindings(false);
                /* TRỪ SỐ LƯỢNG HÀNG ĐÃ XUẤT VÀO NHẬP HÀNG */
                MXuatHang.Update(ele.SO_LUONG, ele);
                dbContext.SaveChanges();
                textBoxDONGIA.SelectAll();

                textBoxLAISUAT.Text = "0";
                textBoxDUATRUOC.Text = "0";
                textBoxDONGIA.Text = "0";
                textBoxSOLUONG.Text = "0";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Dữ liệu nhập vào phải là số");
            }
            comboBoxHANGHOA.Select();
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            comboBoxKho.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKho.DisplayMember = "NAME";
            comboBoxKho.ValueMember = "ID";

            comboBoxKHACH_HANG.DataSource = dbContext.KHACH_HANG.OrderBy(u => u.NAME);
            comboBoxKHACH_HANG.DisplayMember = "NAME";
            comboBoxKHACH_HANG.ValueMember = "ID";

            comboBoxHANGHOA.DataSource = dbContext.HANG_HOA.OrderBy(u => u.NAME);
            comboBoxHANGHOA.DisplayMember = "NAME";
            comboBoxHANGHOA.ValueMember = "ID";
            dataGridView1.DataSource = bs;
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void comboBoxHANGHOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                DateTime now = dateTimePickerNGAYBAN.Value.Date;
                long kho = long.Parse(comboBoxKho.SelectedValue.ToString());
                long hh = long.Parse(comboBoxHANGHOA.SelectedValue.ToString());
                long kh = long.Parse(comboBoxKHACH_HANG.SelectedValue.ToString());

                long ton = MKho.Ton(kho, hh);
                labelTON.Text = "TỒN: " + ton.ToString(); ;
                string hh_id = comboBoxHANGHOA.SelectedValue.ToString();
                long value = long.Parse(hh_id);

                var dvt = dbContext.HANG_HOA
                    .Where(u => u.ID == value)
                    .Select(u => u.UNIT);
                labelDVT.Text = dvt.FirstOrDefault().ToString();

                if (checkBoxBANMAT.Checked == true)
                {
                    kh = MXuatHang.MAKH_XUAT_MAT;
                }
                bs.DataSource = dbContext.XUAT_HANG
                    .Where(u => u.NGAY_XUAT == now && u.MAKHO == kho && u.MAKH == kh && u.MAHH == hh);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[5].HeaderText = "ĐƠN GIÁ";
                dataGridView1.Columns[7].HeaderText = "LÃI SUẤT";
                dataGridView1.Columns[8].HeaderText = "TRẢ TRƯỚC";

            }
            catch (Exception ex)
            {
               //MessageBox.Show("Dữ liệu nhập vào phải là số");
            }
        }

        private void checkBoxBANMAT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBANMAT.Checked == true)
            {
                comboBoxKHACH_HANG.Enabled = false;
                textBoxDUATRUOC.Enabled = false;
                textBoxLAISUAT.Enabled = false;
            }
            else
            {
                comboBoxKHACH_HANG.Enabled = true;
                textBoxDUATRUOC.Enabled = true;
                textBoxLAISUAT.Enabled = true;
            }
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void comboBoxKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void dateTimePickerNGAYBAN_ValueChanged(object sender, EventArgs e)
        {
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void comboBoxKHACH_HANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void comboBoxKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBoxKHACH_HANG.Select();
            }
        }

        private void comboBoxKHACH_HANG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                comboBoxHANGHOA.Select();
            }
        }

        private void dateTimePickerNGAYBAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBoxDONGIA.Select();
                textBoxDONGIA.SelectAll();
            }
        }

        private void comboBoxHANGHOA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dateTimePickerNGAYBAN.Select();
            }
        }

        private void textBoxDONGIA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBoxSOLUONG.Select();
                textBoxSOLUONG.SelectAll();
            }
        }

        private void textBoxSOLUONG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBoxDUATRUOC.Select();
                textBoxDUATRUOC.SelectAll();
            }
        }

        private void textBoxDUATRUOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBoxLAISUAT.Select();
                textBoxLAISUAT.SelectAll();
            }
        }

        private void textBoxLAISUAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonADD_Click(sender, e);
            }
        }
    }
}
