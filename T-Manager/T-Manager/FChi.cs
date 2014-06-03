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
    public partial class FChi : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        private BindingSource bs_nv = new BindingSource();
        public FChi()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FChi_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = dbContext.KHOes.Where(u => u.TYPE == 0);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxNHANVIEN.DataSource = dbContext.NHAN_VIEN;
            comboBoxNHANVIEN.DisplayMember = "NAME";
            comboBoxNHANVIEN.ValueMember = "ID";

            comboBoxNBXE.DataSource = dbContext.XEs;
            comboBoxNBXE.DisplayMember = "BIEN_SO";
            comboBoxNBXE.ValueMember = "ID";

            comboBoxNBXANGDAU.DataSource = dbContext.HANG_HOA;
            comboBoxNBXANGDAU.DisplayMember = "NAME";
            comboBoxNBXANGDAU.ValueMember = "ID";

            var nv_id = Int32.Parse(comboBoxNHANVIEN.SelectedValue.ToString());
            var kho_id = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
            comboBoxKHO_SelectedIndexChanged(sender, e);
            comboBoxNHANVIEN_SelectedIndexChanged(sender, e);

        }

        private void comboBoxNHANVIEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var nv_id = Int32.Parse(comboBoxNHANVIEN.SelectedValue.ToString());
                var kho_id = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                bs_nv.DataSource = dbContext.CHI_LUONG.Where(u => u.MANV == nv_id)
                 .Where(u => u.MAKHO == kho_id);
                dataGridViewLuong.DataSource = bs_nv;

                dataGridViewLuong.Columns[0].Visible = false;
                dataGridViewLuong.Columns[1].Visible = false;
                dataGridViewLuong.Columns[2].Visible = false;
                dataGridViewLuong.Columns[4].Visible = false;
                dataGridViewLuong.Columns[5].HeaderText = "Ngày chi";
                dataGridViewLuong.Columns[3].HeaderText = "Lương tháng";
                dataGridViewLuong.Columns[6].HeaderText = "Tổng Tiền";
            }
            catch(Exception ex)
            {

            }
        }

        private void buttonNHAP_Click(object sender, EventArgs e)
        {
            if (textBoxTONGTIEN.Text != "")
            {
                int tien = Int32.Parse(textBoxTONGTIEN.Text);
                if (tien == 0)
                {
                    MessageBox.Show("Chưa nhập tiền lương nhân viên");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    bs_nv.Add(new CHI_LUONG()
                    {
                        MAKHO = Int32.Parse(comboBoxKHO.SelectedValue.ToString()),
                        MANV = Int32.Parse(comboBoxNHANVIEN.SelectedValue.ToString()),
                        LUONG_THANG = Int32.Parse(dateTimePickerTHANG.Value.Month.ToString()),
                        NGAY_CHI = now.Date,
                        CREATED_AT = now,
                        TONG_TIEN = Int32.Parse(textBoxTONGTIEN.Text),
                    });
                    bs_nv.EndEdit();
                    bs_nv.ResetBindings(false);
                    dbContext.SaveChanges();
                    textBoxTONGTIEN.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập tiền lương nhân viên");
            }
        }

        private void textBoxTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private BindingSource bs_ck = new BindingSource();
        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /* Load NHANVIEN COMBOBOX */
                var makho = long.Parse(comboBoxKHO.SelectedValue.ToString());
                comboBoxNHANVIEN.DataSource = dbContext.NHAN_VIEN.Where(u => u.MAKHO == makho);
                comboBoxNHANVIEN.DisplayMember = "NAME";
                comboBoxNHANVIEN.ValueMember = "ID";
                /* Change XE belogn to KHO */
                comboBoxNBXE_SelectedIndexChanged(sender, e);
                /* LOAD CHI KHAC belong to KHO */
                bs_ck.DataSource = dbContext.CHI_KHAC.Where(u => u.MAKHO == makho);
                dataGridViewCHIKHAC.DataSource = bs_ck;
                dataGridViewCHIKHAC.Columns[0].Visible = false;
                dataGridViewCHIKHAC.Columns[1].Visible = false;
                dataGridViewCHIKHAC.Columns[4].Visible = false;
                dataGridViewCHIKHAC.Columns[2].HeaderText = "Nội dung chi";
                dataGridViewCHIKHAC.Columns[3].HeaderText = "Tổng tiền chi";
                dataGridViewCHIKHAC.Columns[5].HeaderText = "Ngày chi";
            }
            catch (Exception ex)
            {

            }
        }

        private void textBoxNBDONGIABAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void textBoxNBSOLUONG_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void buttonNBNHAP_Click(object sender, EventArgs e)
        {
            if (textBoxNBDONGIABAN.Text == "" || textBoxNBSOLUONG.Text == "")
            {
                MessageBox.Show("Chưa nhập đơn giá hoặc số lượng");
            }
            else
            {
                var dongia = Int32.Parse(textBoxNBDONGIABAN.Text);
                var soluong = Int32.Parse(textBoxNBSOLUONG.Text);
                if (dongia == 0 || soluong == 0)
                {
                    MessageBox.Show("Chưa nhập đơn giá hoặc số lượng");
                    return;
                }
                var xe = Int32.Parse(comboBoxNBXE.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                var hh = Int32.Parse(comboBoxNBXANGDAU.SelectedValue.ToString());
                dbContext.AddToCHI_TIEU_DUNG_NOI_BO(new CHI_TIEU_DUNG_NOI_BO()
                { 
                    MAKHO = kho,
                    MAXE = xe,
                    MAHH = hh,
                    SO_LUONG = soluong,
                    DON_GIA_BAN = dongia,
                    NGAY_CHI = DateTime.Now.Date,
                    CREATED_AT = DateTime.Now
                });
                dbContext.SaveChanges();
                comboBoxNBXE_SelectedIndexChanged(sender, e);
                textBoxNBDONGIABAN.Text = "0";
                textBoxNBSOLUONG.Text = "0";
            }
        }

        private BindingSource bs_noibo = new BindingSource();
        private void comboBoxNBXE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var xe = Int32.Parse(comboBoxNBXE.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                bs_noibo.DataSource = dbContext.CHI_TIEU_DUNG_NOI_BO.Where(u => u.MAXE == xe)
                    .Where(u => u.MAKHO == kho)
                    .Join(dbContext.HANG_HOA, c => c.MAHH, h => h.ID, (c, h) => new {h.NAME, c.SO_LUONG, c.DON_GIA_BAN, c.CREATED_AT });
                dataGridViewXE.DataSource = bs_noibo;
                dataGridViewXE.Columns[0].HeaderText = "HÀNG HÓA";
                dataGridViewXE.Columns[1].HeaderText = "SỐ LƯỢNG";
                dataGridViewXE.Columns[2].HeaderText = "ĐƠN GIÁ BÁN";
                dataGridViewXE.Columns[3].HeaderText = "NGÀY NHẬP";
            }
            catch (Exception ex)
            {
            }
        }

        private void textBoxNDCHI_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxCKTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void buttonCKNHAP_Click(object sender, EventArgs e)
        {
            var chikhac = textBoxNDCHI.Text;
            var chitien = Int32.Parse(textBoxCKTONGTIEN.Text);
            bs_ck.Add(new CHI_KHAC()
            {
                NOI_DUNG = chikhac,
                TONG_TIEN = chitien,
                CREATED_AT = DateTime.Now,
                NGAY_CHI = DateTime.Now.Date,
                MAKHO = Int32.Parse(comboBoxKHO.SelectedValue.ToString())
            });
            bs_ck.EndEdit();
            bs_ck.ResetBindings(false);
            dbContext.SaveChanges();
        }
    }
}
