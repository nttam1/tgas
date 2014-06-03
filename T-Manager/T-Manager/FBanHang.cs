﻿using System;
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
    public partial class FBanHang : Form
    {
        public FBanHang()
        {
            InitializeComponent();
        }

        BindingSource bs = new BindingSource();

        private void FBanHang_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxHANGHOA.DataSource = MHangHoa.Get();
            comboBoxHANGHOA.DisplayMember = "NAME";
            comboBoxHANGHOA.ValueMember = "ID";

            DateTime now = DateTime.Now.Date;
            comboBoxKHO_SelectedIndexChanged(sender, e);
            
            textBoxDONGIABAN.Select();
            textBoxDONGIABAN.SelectAll();
        }

        private void comboBoxHANGHOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            long _kho = 0;
            try
            {
                _kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }

            long _hh = 0;
            try
            {
                T_Manager.HANG_HOA _e = (T_Manager.HANG_HOA)comboBoxHANGHOA.SelectedItem;
                labeLUNIT.Text = _e.UNIT;
                _hh = _e.ID;
            }
            catch (Exception ex)
            {

            }
            textBoxDONGIABAN.Select();
            textBoxDONGIABAN.SelectAll();

            try
            {
                textBoxKHO.Text = comboBoxKHO.Text;
                textBoxHANGHOA.Text = comboBoxHANGHOA.Text;
                textBoxDONGIA.Text = (from ton in DataInstance.Instance().DBContext().NHAP_HANG
                                      where ton.MAKHO == _kho
                                      where ton.MAHH == _hh
                                      where ton.SL_CON_LAI > 0
                                      orderby ton.NGAY_NHAP ascending
                                      select ton.DON_GIA_MUA).First().ToString();
                textBoxDONGIA.Text = Utility.StringToVND(textBoxDONGIA.Text);
                textBoxSLTON.Text = (from ton in DataInstance.Instance().DBContext().NHAP_HANG
                                     where ton.MAKHO == _kho
                                     where ton.MAHH == _hh
                                     select ton.SL_CON_LAI).Sum().ToString();
            }
            catch (Exception ex)
            {
                textBoxDONGIA.Text = Utility.StringToVND("0");
                textBoxSLTON.Text = "0";
            }
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                BAN_HANG bh = new BAN_HANG();
                bh.MAHH = long.Parse(comboBoxHANGHOA.SelectedValue.ToString());
                bh.MAKHO = long.Parse(comboBoxKHO.SelectedValue.ToString());
                bh.NGAY_BAN = DateTime.Now.Date;
                bh.SO_LUONG = long.Parse(textBoxSOLUONG.Text);
                bh.DON_GIA_BAN = long.Parse(textBoxDONGIABAN.Text);
                bh.CREATED_TIME = DateTime.Now;

                if (bh.SO_LUONG == 0 || bh.DON_GIA_BAN == 0)
                {
                    MessageBox.Show("Số lượng và đơn giá không được bằng 0", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                long lton = (from ton in DataInstance.Instance().DBContext().NHAP_HANG
                            where ton.MAKHO == bh.MAKHO
                            where ton.MAHH == bh.MAHH
                            select ton.SL_CON_LAI).Sum();
                if (bh.SO_LUONG > lton)
                {
                    MessageBox.Show("Số lượng bán hàng lớn hơn số lượng tồn. \nCòn tồn: " + lton.ToString(), "Lỗi số lượng!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MBanHang.Creat(bh.MAKHO, bh.MAHH, bh.SO_LUONG, bh.DON_GIA_BAN, bh.NGAY_BAN);
                textBoxSOLUONG.Text = "0";
                textBoxSOLUONG.Select();
                textBoxSOLUONG.SelectAll();
                comboBoxKHO_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số lượng hoặc đơn giá nhập vào không đúng. Chỉ chấp nhận số");
            }
        }

        private void textBoxDONGIABAN_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxDONGIABAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonADD_Click(sender, e);
            }
        }

        private void textBoxSOLUONG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonADD_Click(sender, e);
            }
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
                DateTime now = DateTime.Now.Date;
                bs.DataSource = (from nh in DataInstance.Instance().DBContext().BAN_HANG
                                 join hh in DataInstance.Instance().DBContext().HANG_HOA on nh.MAHH equals hh.ID
                                 where nh.NGAY_BAN == now
                                 where nh.MAKHO == kho
                                 select new
                                 {
                                     hanghoa = hh.NAME,
                                     soluong = nh.SO_LUONG,
                                     dongia = nh.DON_GIA_BAN,
                                     ngayban = nh.NGAY_BAN
                                 }
                                     );
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].HeaderText = "HÀNG HÓA";
                dataGridView1.Columns[1].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[2].HeaderText = "ĐƠN GIÁ BÁN";
                dataGridView1.Columns[3].HeaderText = "NGÀY BÁN";
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                textBoxDONGIABAN.Select();
                textBoxDONGIABAN.SelectAll();
            }
            catch (Exception ex)
            {

            }

            comboBoxHANGHOA_SelectedIndexChanged(sender, e);
        }
    }
}
