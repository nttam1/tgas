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
        private BindingSource bsKH = new BindingSource();
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
                ele.MAKH = Convert.ToInt32(comboBoxKHACH_HANG.SelectedValue.ToString());
                ele.NGAY_XUAT = dateTimePickerNGAYBAN.Value;
                ele.CREATED_AT = DateTime.Now;
                ele.SO_LUONG = Convert.ToInt32(textBoxSOLUONG.Text);
                ele.DON_GIA_BAN = Convert.ToInt32(textBoxDONGIA.Text);
                ele.TRA_TRUOC = Convert.ToInt32(textBoxDUATRUOC.Text);
                ele.LAI_SUAT = Convert.ToDouble(textBoxLAISUAT.Text);
                ele.MAHH = Convert.ToInt32(comboBoxHANGHOA.SelectedValue.ToString());
                if (ele.DON_GIA_BAN == 0 || ele.SO_LUONG == 0)
                {
                    MessageBox.Show("Chưa nhập số lượng hoặc đơn giá bán");
                }
                else
                {
                    dbContext.AddToXUAT_HANG(ele);
                    /* TRỪ SỐ LƯỢNG HÀNG ĐÃ XUẤT VÀO NHẬP HÀNG */
                    MXuatHang.Update(ele.SO_LUONG, ele);
                    dbContext.SaveChanges();
                    textBoxDONGIA.SelectAll();
                    dataGridView1.Rows.Add(comboBoxKho.Text, comboBoxKHACH_HANG.Text, comboBoxHANGHOA.Text, ele.DON_GIA_BAN, ele.SO_LUONG, ele.TRA_TRUOC, ele.LAI_SUAT, ele.NGAY_XUAT);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            comboBoxKho.DataSource = dbContext.KHOes.Where(u => u.TYPE == 0);
            comboBoxKho.DisplayMember = "NAME";
            comboBoxKho.ValueMember = "ID";

            bsKH.DataSource = dbContext.KHACH_HANG;
            comboBoxKHACH_HANG.DataSource = bsKH;
            comboBoxKHACH_HANG.DisplayMember = "NAME";
            comboBoxKHACH_HANG.ValueMember = "ID";

            comboBoxHANGHOA.DataSource = dbContext.HANG_HOA;
            comboBoxHANGHOA.DisplayMember = "NAME";
            comboBoxHANGHOA.ValueMember = "ID";

            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FKhachHang k = new FKhachHang();
            k.Show();
            k.FormClosed += new FormClosedEventHandler(AddKHClose);
        }

        private void AddKHClose(object sender, EventArgs e)
        {
            bsKH.ResetBindings(false);
        }

        private void comboBoxHANGHOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hh_id = comboBoxHANGHOA.SelectedValue.ToString();
            try
            {
                long value = long.Parse(hh_id);
                var dvt = dbContext.HANG_HOA.Where(u => u.ID == value).Select(u => u.UNIT);
                labelDVT.Text = dvt.FirstOrDefault().ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
    }
}
