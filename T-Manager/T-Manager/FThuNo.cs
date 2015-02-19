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
    public partial class FThuNo : Form
    {
        public FThuNo()
        {
            InitializeComponent();
        }

        private long _LAI = 0;
        private long _GOC = 0;
        private void FThuNo_Load(object sender, EventArgs e)
        {
            if (MKho.Get(MKho.KHO_HANG).Count() == 0)
            {
                MessageBox.Show("CẦN TẠO KHO TRƯỚC");
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

            comboBoxKHO_SelectedIndexChanged(sender, e);

            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.KeyPress +=new KeyPressEventHandler(c_KeyPress);
                }
            }
            radioButtonNOHH_CheckedChanged(sender, e);
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private BindingSource bs = new BindingSource();
        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 kh = -1;
            try
            {
                kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                MKhachHang mKH = new MKhachHang(kh);
                try
                {
                    _LAI = (long)mKH.LaiHHHienTai(dateTimePickerDATE.Value);
                    _GOC = (long)mKH.NoHHHienTai();
                    TONGNO_LB.Text = Utility.StringToVND(_GOC.ToString());
                    TONGLAI_LB.Text = Utility.StringToVND(_LAI.ToString());
                }
                catch (Exception ex)
                {
                    _LAI = 0;
                    _GOC = 0;
                    TONGNO_LB.Text = "0 VND";
                    TONGLAI_LB.Text = "0 VND";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                var goc = Int64.Parse(textBoxTIENGOC.Text);
                var lai = Int64.Parse(textBoxTIENLAI.Text);
                var loai_no = MThuNo.NO_HANG_HOA;
                var cur_lai = _LAI ;
                var cur_no = _GOC;
                if (lai == 0 && goc == 0)
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                    return;
                }
                if (lai > cur_lai)
                {
                    MessageBox.Show("Lãi trả không được lớn hơn lãi nợ");
                    return;
                }
                if (goc > cur_no)
                {
                    MessageBox.Show("Tiền trả không được lớn hơn tiền nợ");
                    return;
                }
                DateTime date = dateTimePickerDATE.Value.Date;
                try
                {
                    MThuNo.Create(loai_no, kho, kh, goc, lai, date);
                    comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
                    textBoxTIENGOC.Text = "0";
                    textBoxTIENLAI.Text = "0";
                    textBoxTIENGOC.Select();
                    textBoxTIENGOC.SelectAll();
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng, Vui lòng kiểm tra lại");
            }
        }

        private void textBoxTIENLAI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonADD_Click(sender, e);
            }
        }

        private void textBoxTIENLAI_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTIENGOC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TONGNO_LB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                var tongtien = Int32.Parse(textBoxTONGTIEN.Text);
                var noidung = richTextBoxNOIDUNG.Text;
                DateTime date = dateTimePickerNGAYKHAC.Value.Date;
                DataInstance.Instance().DBContext().AddToTHU_NO(new THU_NO()
               {
                   MAKHO = kho,
                   TIEN_GOC = tongtien,
                   NOI_DUNG = noidung,
                   NGAY_TRA = date,
                   CREATED_AT = DateTime.Now
               });
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxTONGTIEN.Text = "0";
                richTextBoxNOIDUNG.Text = "";
                richTextBoxNOIDUNG.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không phù hợp");
            }
        }

        private void radioButtonNOHH_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }

        private void radioButtonNOVAY_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxKHO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxTIENLAI_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonADD_Click(sender, e);
            }
        }

        private void textBoxTONGTIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }
        }

        private void dateTimePickerDATE_ValueChanged(object sender, EventArgs e)
        {
            Int32 kh = -1;
            try
            {
                kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                MKhachHang mKH = new MKhachHang(kh);
                try
                {
                    _LAI = (long)mKH.LaiHHHienTai(dateTimePickerDATE.Value);
                    TONGLAI_LB.Text = Utility.StringToVND(_LAI.ToString());
                }
                catch (Exception ex)
                {
                    _LAI = 0;
                    _GOC = 0;
                    TONGNO_LB.Text = "0 VND";
                    TONGLAI_LB.Text = "0 VND";
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
