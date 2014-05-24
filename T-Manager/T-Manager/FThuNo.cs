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

        Int32 NoHH = 0;
        Int32 LaiHH = 0;
        Int32 NoVay = 0;
        Int32 LaiVay = 0;

        private void FThuNo_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes;
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxKHACHHANG.DataSource = DataInstance.Instance().DBContext().KHACH_HANG;
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
            Int32 kho = -1;
            Int32 kh = -1;
            try
            {
                kh = Int32.Parse(comboBoxKHACHHANG.SelectedValue.ToString());
                kho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
                MKhachHang mKH = new MKhachHang(kh, kho);
                // Hien thi tong no, tong la
                try
                {
                    textBoxNOVAY.Text = Utility.StringToVND(mKH.NoVayHienTai().ToString());
                    textBoxLAIVAY.Text = Utility.StringToVND(mKH.LaiVayHienTai().ToString());
                }
                catch (Exception ex)
                {
                    textBoxNOVAY.Text = "0 VND";
                    textBoxLAIVAY.Text = "0 VND";
                }
                try
                {
                    TONGNO_LB.Text = Utility.StringToVND(mKH.NoHHHienTai().ToString());
                    TONGLAI_LB.Text = Utility.StringToVND(mKH.LaiHHHienTai().ToString());
                }
                catch (Exception ex)
                {
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
                var loai_no = radioButtonNOHH.Checked == true ? MThuNo.THU_NO_HH : MThuNo.THU_NO_VAY;
                var cur_lai = LaiVay + LaiHH;
                var cur_no = NoHH + NoVay;
                try
                {
                    THU_NO ele = new THU_NO()
                    {
                        MAKH = kh,
                        MAKHO = kho,
                        TIEN_GOC = goc,
                        TIEN_LAI = lai,
                        LOAI_NO = loai_no,
                        NGAY_TRA = DateTime.Now,
                        CREATED_AT = DateTime.Now
                    };
                    bs.Add(ele);
                    bs.EndEdit();
                    bs.ResetBindings(false);
                    DataInstance.Instance().DBContext().AddToTHU_NO(ele);
                    DataInstance.Instance().DBContext().SaveChanges();
                    // Cap nhat tien no
                    MKhachHang mKH = new MKhachHang(kh);
                    mKH.CapNhatNo(goc, lai, ele);

                    textBoxTIENGOC.Text = "";
                    textBoxTIENLAI.Text = "";
                    comboBoxKHACHHANG_SelectedIndexChanged(sender, e);
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
                DataInstance.Instance().DBContext().AddToTHU_NO(new THU_NO()
               {
                   MAKHO = kho,
                   TIEN_GOC = tongtien,
                   NOI_DUNG = noidung,
                   NGAY_TRA = DateTime.Now,
                   CREATED_AT = DateTime.Now
               });
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxTONGTIEN.Text = "";
                richTextBoxNOIDUNG.Text = "";
                textBoxTONGTIEN.Select();
            }
            catch (Exception ex)
            {
            }
        }

        private void radioButtonNOHH_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.BackColor = Color.Aquamarine;
            groupBox3.BackColor = Color.Azure;
        }

        private void radioButtonNOVAY_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.BackColor = Color.Aquamarine;
            groupBox2.BackColor = Color.Azure;
        }
    }
}
