using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager.Modal;

namespace T_Manager.EDIT
{
    public partial class FXuatHang : Form
    {
        public FXuatHang()
        {
            InitializeComponent();
        }

        BindingSource bs = new BindingSource();
        tgasEntities dbContext = DataInstance.Instance().DBContext();
        long oldSoluong = 0;

        private void dateTimePickerDATE_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                long maKho = long.Parse(comboBox_kho.SelectedValue.ToString());
                var ids = (from edit in dbContext.EDIT_XUAT_HANG select edit.XUAT_HANG_ID).ToList();
                bs.DataSource = (from xh in dbContext.XUAT_HANG
                                 join hh in dbContext.HANG_HOA on xh.MAHH equals hh.ID
                                 join kho in dbContext.KHOes on xh.MAKHO equals kho.ID
                                 where xh.NGAY_XUAT == now && xh.MAKHO == maKho && !(from edit in dbContext.EDIT_XUAT_HANG select edit.XUAT_HANG_ID).Contains(xh.ID)
                                 select new
                                 {
                                     ID = xh.ID,
                                     KHO = kho.ID,
                                     HANGHOA = hh.ID,
                                     KHACHHANG = xh.MAKH, //kh.NAME,
                                     SOLUONG = xh.SO_LUONG,
                                     DONGIA = xh.DON_GIA_BAN,
                                     TRATRUOC = xh.TRA_TRUOC,
                                     LAISUAT = xh.LAI_SUAT,
                                     NGAYXUAT = xh.NGAY_XUAT.Value                               
                                 });
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "KHO";
                dataGridView1.Columns[2].HeaderText = "HÀNG HÓA";
                dataGridView1.Columns[3].HeaderText = "KHÁCH HÀNG";
                dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[5].HeaderText = "ĐƠN GIÁ";
                dataGridView1.Columns[6].HeaderText = "TRẢ TRƯỚC";
                dataGridView1.Columns[7].HeaderText = "LÃI XUẤT";
                dataGridView1.Columns[8].Visible = false;

                // Load ton dau ngay
                long tonDauNgay = MKho.TON_DAU(maKho, now);
                label_ton_dau_ngay.Text = tonDauNgay.ToString();
                // Load ton cuoi ngay
                long tonCuoiNgay = MKho.TON_CUOI(maKho, now);
                label_ton_cuoi_ngay.Text = tonCuoiNgay.ToString();

                // Disable group
                groupBoxEdit.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void FXuatHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bs;
            dateTimePickerDATE_ValueChanged(sender, e);

            groupBoxEdit.Enabled = false;

            var lst = dbContext.KHACH_HANG.OrderBy(u => u.ID);
            List<object> ls = new List<object>();
            ls.Add(new
            {
                ID = (long)-1,
                NAME = "-1 - BÁN MẶT"
            });
            foreach (KHACH_HANG k in lst)
            {
                ls.Add(new
                {
                    ID = k.ID,
                    NAME = k.ID.ToString() + " - " + k.NAME
                });
            }
            comboBox_kho.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBox_kho.DisplayMember = "NAME";
            comboBox_kho.ValueMember = "ID";

            dateTimePickerDATE_ValueChanged(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                groupBoxEdit.Enabled = true;
                var s = dataGridView1.Rows[e.RowIndex];
                textBoxSOLUONG.Text = s.Cells[4].Value.ToString();
                textBoxDONGIA.Text = s.Cells[5].Value.ToString();
                textBoxLAISUAT.Text = s.Cells[7].Value.ToString();
                textBoxTRATRUOC.Text = s.Cells[6].Value.ToString();
                textBoxKHACHHANG.Text = s.Cells[3].Value.ToString();
                //textBoxKHO.Text = s.Cells[1].Value.ToString();
                textBoxHH.Text = s.Cells[2].Value.ToString();
                //dateTimePickerNGAYXUAT.Value = (DateTime)s.Cells[8].Value;
                textBoxID.Text = s.Cells[0].Value.ToString();
                oldSoluong = long.Parse(textBoxSOLUONG.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            long ID = long.Parse(textBoxID.Text);
            var R = dbContext.XUAT_HANG.Where(u => u.ID == ID);
            long kho = long.Parse(comboBox_kho.SelectedValue.ToString());
            long hh = long.Parse(textBoxHH.Text);
            long kh = long.Parse(textBoxKHACHHANG.Text);
            long sl = long.Parse(textBoxSOLUONG.Text);
            long dg = long.Parse(textBoxDONGIA.Text);
            double ls = double.Parse(textBoxLAISUAT.Text);
            long trt = long.Parse(textBoxTRATRUOC.Text);
            DateTime nx = dateTimePickerDATE.Value.Date;
            BindingSource bs = new BindingSource();
            bs.DataSource = dbContext.EDIT_XUAT_HANG;
            try
            {
                if (kh != -1)
                {
                    dbContext.KHACH_HANG.Where(u => u.ID == kh).First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai mã khách hàng");
                return;
            }
            try
            {
                dbContext.HANG_HOA.Where(u => u.ID == hh).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai mã hàng");
                return;
            }
            try
            {
                dbContext.KHOes.Where(u => u.ID == kho).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai mã KHO");
                return;
            }

            // Kiem tra so luong ton
            long ton = MKho.Ton(kho, hh);
            if (sl - oldSoluong > ton)
            {
                MessageBox.Show("Số lượng tồn không đủ. Tồn: " + ton.ToString());
                return;
            }

            // Create new EDIT_XUAT_HANG
            var now = DateTime.Now;
            bs.Add(new EDIT_XUAT_HANG
            {
                MAKH = kh,
                MAHH = hh,
                SO_LUONG = sl,
                DON_GIA = dg,
                LAI_SUAT = ls,
                TRA_TRUOC = trt,
                XUAT_HANG_ID = ID,
                CONFIRMED = false,
                CREATED_AT = now
            });
            bs.EndEdit();
            bs.ResetBindings(false);
            DataInstance.Instance().DBContext().SaveChanges();
            MessageBox.Show("ĐÃ CẬP NHẬT CHỈNH SỬA. VUI LÒNG CHỜ XÁC NHẬN TỪ QUẢN LÝ");
            dateTimePickerDATE_ValueChanged(sender, e);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox_kho_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerDATE_ValueChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long ID = long.Parse(textBoxID.Text);
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var item = dbContext.EDIT_XUAT_HANG.Where(u => u.XUAT_HANG_ID == ID).First();
                dbContext.EDIT_XUAT_HANG.DeleteObject(item);
                dbContext.SaveChanges();
                dateTimePickerDATE_ValueChanged(sender, e);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }

    class CXUATHANG
    {
        public Int64 ID;
        public string KHO;
        public string HANGHOA;
        public string KHACHHANG;
        public Int64 SOLUONG;
        public Int64 DONGIA;
        public Int64 TRATRUOC;
        public double LAISUAT;
        public DateTime NGAYXUAT;
    }
}
