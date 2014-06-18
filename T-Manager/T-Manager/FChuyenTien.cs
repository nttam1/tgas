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
    public partial class FChuyenTien : Form
    {
        public FChuyenTien()
        {
            InitializeComponent();
        }

        private void FChuyenTien_Load(object sender, EventArgs e)
        {
            listBoxTAIKHOAN.DataSource = MKho.Get(MKho.KHO_TK_NGANHANG);
            listBoxTAIKHOAN.DisplayMember = "NAME";
            listBoxTAIKHOAN.ValueMember = "ID";

            textBoxTIENTON.Text = Utility.StringToVND(MKho.Tong_Tien_Hien_Tai(DateTime.Now).ToString());
            dateTimePickerNGAY.Select();
        }

        private void textBoxTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void buttonCHUYEN_Click(object sender, EventArgs e)
        {
            long tien = 0;
            long taikhoan = 0;
            long ton = MKho.Tong_Tien_Hien_Tai(DateTime.Now);
            try
            {
                tien = long.Parse(textBoxTONGTIEN.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập tiền");
                return;
            }
            try
            {
                taikhoan = long.Parse(listBoxTAIKHOAN.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn tài khoản");
                return;
            }
            if (tien == 0 || taikhoan == 0)
            {
                MessageBox.Show("Số tiền chuyển phải lớn hơn 0");
                return;
            }
            if (tien > ton)
            {
                MessageBox.Show("Số tiền chuyển không được lớn hơn tiền đang có");
                return;
            }
            DateTime now = dateTimePickerNGAY.Value.Date;
            CHUYEN_TIEN c = new CHUYEN_TIEN();
            c.TONG_TIEN = tien;
            c.NGAY_CHUYEN = now;
            c.ID_TAI_KHOAN = taikhoan;
            c.CREATED_AT = DateTime.Now;
            DataInstance.Instance().DBContext().AddToCHUYEN_TIEN(c);
            DataInstance.Instance().DBContext().SaveChanges();
            textBoxTIENTON.Text = Utility.StringToVND(MKho.Tong_Tien_Hien_Tai(DateTime.Now).ToString());
            textBoxTONGTIEN.Text = "0";
            textBoxTONGTIEN.Select();
            textBoxTONGTIEN.SelectAll();
        }

        private void dateTimePickerNGAY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void listBoxTAIKHOAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonCHUYEN_Click(sender, e);
            }
        }
    }
}
