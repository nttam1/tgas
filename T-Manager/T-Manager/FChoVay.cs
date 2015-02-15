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

        tgasEntities db = DataInstance.Instance().DBContext();

        private void FChoVay_Load(object sender, EventArgs e)
        {
            if (MKho.Get(MKho.KHO_HANG).Count() == 0 || DataInstance.Instance().DBContext().KHACH_HANG.Count() == 0)
            {
                MessageBox.Show("CẦN TẠO KHO VÀ KHÁCH HÀNG TRƯỚC");
                this.Close();
                return;
            }
            var i2nKHO = new Id2Name(textBoxMAKHO, comboBoxKHO);
            var i2nKH = new Id2Name(textBoxKHACHHANG, comboBoxKHACHHANG);

            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
            comboBoxKHACHHANG.DataSource = DataInstance.Instance().DBContext().KHACH_HANG.OrderBy(u => u.NAME);
            comboBoxKHACHHANG.DisplayMember = "NAME";
            comboBoxKHACHHANG.ValueMember = "ID"; 
            dataGridViewCHOVAY.DataSource = bs;
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
            textBoxMAKHO.Select();
            textBoxMAKHO.SelectAll();
        }

        private BindingSource bs = new BindingSource();

        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                DateTime now = dateTimePickerCHOVAY.Value.Date;
                bs.DataSource = db.XUAT_HANG.Where(u => u.NGAY_XUAT == now && u.SO_LUONG == 0 && u.DON_GIA_BAN == 0 && u.THANH_TIEN > 0 && u.MAKH ==  kh && u.MAKHO == kho);

                dataGridViewCHOVAY.Columns[0].Visible = false;
                dataGridViewCHOVAY.Columns[1].Visible = false;
                dataGridViewCHOVAY.Columns[2].Visible = false;
                dataGridViewCHOVAY.Columns[3].Visible = false;
                dataGridViewCHOVAY.Columns[4].Visible = false;
                dataGridViewCHOVAY.Columns[5].Visible = false;
                dataGridViewCHOVAY.Columns[6].HeaderText = "Tổng tiền";
                dataGridViewCHOVAY.Columns[7].HeaderText = "Lãi suất";
                dataGridViewCHOVAY.Columns[8].Visible = false;
                dataGridViewCHOVAY.Columns[9].Visible = false;
                dataGridViewCHOVAY.Columns[10].HeaderText = "NGÀY CHO VAY";
                dataGridViewCHOVAY.Columns[11].Visible = false;
                dataGridViewCHOVAY.Columns[12].Visible = false;
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
            if (e.KeyChar == (char)13)
            {
                buttonADD_Click(sender, e);
            }
        }

        private void textBoxTONGTIEN_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLAISUAT_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                var lai = double.Parse(textBoxLAISUAT.Text) / 100;
                if (tien == 0)
                {
                    MessageBox.Show("Tiền xuất phải lớn hơn 0");
                    return;
                }
                bs.Add(new XUAT_HANG()
                {
                    MAKHO = kho,
                    MAKH = kh,
                    THANH_TIEN = tien,
                    LAI_SUAT = lai,
                    NGAY_XUAT = dateTimePickerCHOVAY.Value.Date,
                    SO_LUONG= 0,
                    DON_GIA_BAN = 0,
                    TRA_TRUOC = 0,
                    TRANG_THAI = MXuatHang.CHUA_TRA_XONG,
                    CHI_TIET_XUAT_HANG = "",
                    MAHH = MXuatHang.MAHH_CHO_VAY,
                    CREATED_AT = DateTime.Now,         
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxTONGTIEN.Text = "0";
                textBoxTONGTIEN.Select();
                textBoxTONGTIEN.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập liệu");
            }
        }

        private void comboBoxKHO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dateTimePickerCHOVAY_ValueChanged(object sender, EventArgs e)
        {
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }
    }
}
