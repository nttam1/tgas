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
    public partial class FXUATHANGNEW : Form
    {
        public FXUATHANGNEW()
        {
            InitializeComponent();
        }
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        private BindingSource bs = new BindingSource();

        private void FXUATHANGNEW_Load(object sender, EventArgs e)
        {
            comboBoxKho.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKho.DisplayMember = "NAME";
            comboBoxKho.ValueMember = "ID";

            comboBoxKho_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (index != dataGridView1.Rows.Count - 1)
                    {
                        //long maKho = long.Parse(row.Cells[1].Value.ToString());
                        long maHh = long.Parse(row.Cells[2].Value.ToString());
                        long maKH = long.Parse(row.Cells[3].Value.ToString());
                        long soluong = long.Parse(row.Cells[4].Value.ToString());
                        long dongia = long.Parse(row.Cells[5].Value.ToString());
                        // var checkMAKHO = dbContext.KHOes.Where(u => u.ID == maKho).First();
                        var checkMAHH = dbContext.HANG_HOA.Where(u => u.ID == maHh).First();
                        if (maKH != -1)
                        {
                            var checkMAKH = dbContext.KHACH_HANG.Where(u => u.ID == maKH).First();
                        }
                        if (soluong <= 0)
                        {
                            MessageBox.Show("Số lượng không đúng");
                            return;
                        }

                        if (dongia < 10000)
                        {
                            MessageBox.Show("Đơn giá không đúng");
                            return;
                        }
                        if (row.Cells[12].Value == null)
                        {
                            row.Cells[1].Value = long.Parse(comboBoxKho.SelectedValue.ToString());
                            row.Cells[6].Value = soluong * dongia;
                            row.Cells[9].Value = DateTime.Now;
                            row.Cells[10].Value = dateTimePickerNGAYBAN.Value.Date;
                            row.Cells[12].Value = "empty";
                        }
                    }
                    ++index;
                }
                dbContext.SaveChanges();
                foreach (XUAT_HANG xh in dbContext.XUAT_HANG.Where(u => u.CHI_TIET_XUAT_HANG == "empty"))
                {
                    MXuatHang.Update(xh.SO_LUONG, xh);
                }
                FXUATHANGNEW_Load(sender, e);
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception exx)
            {
                MessageBox.Show("Dữ liệu nhập vào không chính xác");
            }
        }

        private void comboBoxKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime now = dateTimePickerNGAYBAN.Value.Date;
                long maKho = long.Parse(comboBoxKho.SelectedValue.ToString());

                bs.DataSource = dbContext.XUAT_HANG.Where(u => u.MAKHO == maKho).Where(u => u.NGAY_XUAT == now).OrderBy(u => u.NGAY_XUAT);
                dataGridView1.DataSource = bs;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                // dataGridView1.Columns[1].HeaderText = "MÃ KHO";
                dataGridView1.Columns[2].HeaderText = "MÃ HÀNG HÓA";
                dataGridView1.Columns[3].HeaderText = "MÃ KHÁCH HÀNG";
                dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[5].HeaderText = "ĐƠN GIÁ";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "LÃI SUẤT";
                dataGridView1.Columns[8].HeaderText = "TRẢ TRƯỚC";
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;

                int index = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (index != dataGridView1.Rows.Count)
                    {
                        row.ReadOnly = true;
                    }
                    ++index;
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void dateTimePickerNGAYBAN_ValueChanged(object sender, EventArgs e)
        {
            comboBoxKho_SelectedIndexChanged(sender, e);
        }
    }
}
