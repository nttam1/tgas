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
        }

        private void textBoxTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void buttonCHUYEN_Click(object sender, EventArgs e)
        {
            long tien = 0;
            long taikhoan = 0;
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
            CHUYEN_TIEN c = new CHUYEN_TIEN();
            c.TONG_TIEN = tien;
            c.NGAY_CHUYEN = DateTime.Now.Date;
            c.ID_TAI_KHOAN = taikhoan;
            c.CREATED_AT = DateTime.Now;
            DataInstance.Instance().DBContext().AddToCHUYEN_TIEN(c);
            DataInstance.Instance().DBContext().SaveChanges();
            textBoxTIENTON.Text = Utility.StringToVND(MKho.Tong_Tien_Hien_Tai(DateTime.Now).ToString());
            textBoxTONGTIEN.Text = "";
            textBoxTONGTIEN.Select();
        }
    }
}
