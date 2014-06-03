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
    public partial class FTraNoVay : Form
    {
        public FTraNoVay()
        {
            InitializeComponent();
        }

        private int _SelectedRow = 0;
        private BindingSource bs = new BindingSource();

        private void FTraNoVay_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = DataInstance.Instance().DBContext().KHOes.Where(u => u.TYPE == 1);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxNGUONVAY.DataSource = DataInstance.Instance().DBContext().NGUON_VAY;
            comboBoxNGUONVAY.DisplayMember = "NAME";
            comboBoxNGUONVAY.ValueMember = "ID";

            comboBoxNGUONVAY_SelectedIndexChanged(sender, e);

            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.KeyPress += new KeyPressEventHandler(c_KeyPress);
                }
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void comboBoxNGUONVAY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var kho = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var nguonvay = Convert.ToInt32(comboBoxNGUONVAY.SelectedValue.ToString());
                var nos = (from _nos in DataInstance.Instance().DBContext().VAYs
                           where _nos.MA_NGUON_VAY == nguonvay
                           where _nos.TRANG_THAI == MVay.CHUA_TRA_XONG
                           orderby _nos.NGAY_VAY ascending
                           select _nos);
                bs.DataSource = nos;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[2].HeaderText = "TỔNG TIỀN";
                dataGridView1.Columns[3].HeaderText = "LÃI SUẤT";
                dataGridView1.Columns[4].HeaderText = "KÌ HẠN";
                dataGridView1.Columns[5].HeaderText = "NGÀY VAY";
                dataGridView1.Select();
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var kho = Convert.ToInt32(comboBoxKHO.SelectedValue.ToString());
                var nguonvay = Convert.ToInt32(comboBoxNGUONVAY.SelectedValue.ToString());
                var goc = Convert.ToInt32(textBoxTONGTIEN.Text);
                var lai = Convert.ToInt32(textBoxTIENLAI.Text);
                var ngay = dateTimePicker1.Value.Date;
                bool traxong = checkBoxTRAXONG.Checked == true;
                /*LAYT VAY_ID */    
                VAY _v = (VAY)bs.List[_SelectedRow];
                DataInstance.Instance().DBContext().AddToTRA_NO_VAY(new TRA_NO_VAY()
                {
                    MAKHO = kho,
                    MA_NGUON_VAY = nguonvay,
                    TIEN_GOC = goc,
                    TIEN_LAI = lai,
                    NGAY_TRA = ngay,
                    CREATED_AT = DateTime.Now,
                    VAY_ID = _v.ID,
                });
                /* Cập nhật trạng thái cho vay */
                if (traxong == true)
                {
                    foreach (VAY __v in (from _vayy in DataInstance.Instance().DBContext().VAYs
                        where _vayy.ID == _v.ID select _vayy))
                    {
                        __v.TRANG_THAI = MVay.DA_TRA_XONG;
                    }
                }
                DataInstance.Instance().DBContext().SaveChanges();
                comboBoxNGUONVAY_SelectedIndexChanged(sender, e);
                textBoxTONGTIEN.Text = "0";
                textBoxTIENLAI.Text = "0";
                textBoxTONGTIEN.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNGUONVAY_SelectedIndexChanged(sender, e);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _SelectedRow = e.RowIndex;
            long vay = long.Parse(comboBoxNGUONVAY.SelectedValue.ToString());
            VAY _v = (VAY)bs.List[e.RowIndex];
            textBoxNGAYVAY.Text = _v.NGAY_VAY.Date.ToShortDateString();
            textBoxTIENGOC.Text = Utility.StringToVND(_v.TONG_TIEN.ToString());
            textBoxLAISUAT.Text = (_v.LAI_SUAT * 100).ToString() + " %";
            textBoxKYHAN.Text = (_v.KY_HAN.ToString()) + " Tháng";
            try
            {
                textBoxLAIDATRA.Text = Utility.StringToVND(
                    (from tn in DataInstance.Instance().DBContext().TRA_NO_VAY
                     where tn.VAY_ID == _v.ID
                     select tn.TIEN_LAI).Sum().ToString());
            }
            catch (Exception ex)
            {
                textBoxLAIDATRA.Text = Utility.StringToVND("0");
            }
            try
            {
                textBoxGOCDATRA.Text = Utility.StringToVND(
                    (from tn in DataInstance.Instance().DBContext().TRA_NO_VAY
                     where tn.VAY_ID == _v.ID
                     select tn.TIEN_GOC).Sum().ToString());
            }
            catch (Exception ex)
            {
                textBoxGOCDATRA.Text = Utility.StringToVND("0");
            }
        }

        private void checkBoxTRAXONG_CheckedChanged(object sender, EventArgs e)
        {
            long tongno = long.Parse(textBoxTONGTIEN.ToString());
        }
    }
}
