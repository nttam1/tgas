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
    public partial class FConfirmEdit : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        BindingSource bs = new BindingSource();

        public FConfirmEdit()
        {
            InitializeComponent();
        }

        private void FConfirmEdit_Load(object sender, EventArgs e)
        {
            FAdminConfirmDialog admin = new FAdminConfirmDialog();
            if (admin.ShowDialog(this) != DialogResult.OK)
            {
                this.Dispose();
                return;
            }
            _loadData();
        }

        private void _loadData()
        {
            bs.DataSource = (from edit in dbContext.EDIT_XUAT_HANG
                             join xh in dbContext.XUAT_HANG on edit.XUAT_HANG_ID equals xh.ID
                             where edit.CONFIRMED == false
                             orderby xh.NGAY_XUAT
                             select new
                             {
                                 xh.MAKHO,
                                 DATE = xh.NGAY_XUAT.Value,
                                 xh.MAHH,
                                 EDIT_MAHH = edit.MAHH,
                                 xh.MAKH,
                                 EDIT_MAKH = edit.MAKH,
                                 xh.DON_GIA_BAN,
                                 EDIT_DON_GIA = edit.DON_GIA,
                                 xh.SO_LUONG,
                                 EDIT_SOLUONG = edit.SO_LUONG,
                                 xh.LAI_SUAT,
                                 EDIT_LAI_SUAT = edit.LAI_SUAT,
                                 xh.TRA_TRUOC,
                                 EDIT_TRA_TRUOC = edit.TRA_TRUOC,
                                 edit.CONFIRMED,
                                 xh.ID
                             }
                             ).ToList();
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].HeaderText = "MÃ KHO";
            dataGridView1.Columns[1].HeaderText = "NGÀY XUẤT";
            dataGridView1.Columns[2].HeaderText = "MÃ HH";
            dataGridView1.Columns[3].HeaderText = "MÃ HH MỚI";
            dataGridView1.Columns[4].HeaderText = "MÃ KH";
            dataGridView1.Columns[5].HeaderText = "MÃ KH MỚI";
            dataGridView1.Columns[6].HeaderText = "ĐƠN GIÁ";
            dataGridView1.Columns[7].HeaderText = "ĐƠN GIÁ MỚI";
            dataGridView1.Columns[8].HeaderText = "SỐ LƯỢNG";
            dataGridView1.Columns[9].HeaderText = "SỐ LƯỢNG MỚI";
            dataGridView1.Columns[10].HeaderText = "LÃI SUẤT";
            dataGridView1.Columns[11].HeaderText = "LÃI SUẤT MỚI";
            dataGridView1.Columns[12].HeaderText = "TRẢ TRƯỚC";
            dataGridView1.Columns[13].HeaderText = "TRẢ TRƯỚC MỚI";
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < 6; i++)
                {
                    int index = 2 + i * 2;
                    if (!row.Cells[index].Value.Equals(row.Cells[index + 1].Value))
                    {
                        row.Cells[index].Style.BackColor = Color.Yellow;
                        row.Cells[index + 1].Style.BackColor = Color.Green;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var needed = (from xh in dbContext.XUAT_HANG
                              where (from edit in dbContext.EDIT_XUAT_HANG select edit.XUAT_HANG_ID).Contains(xh.ID)
                              select xh);
                var update = dbContext.EDIT_XUAT_HANG.Where(u => u.CONFIRMED == false);
                foreach (XUAT_HANG xh in needed)
                {
                    foreach (EDIT_XUAT_HANG edit in update)
                    {
                        if (edit.XUAT_HANG_ID == xh.ID)
                        {
                            xh.MAHH = edit.MAHH.Value;
                            xh.MAKH = edit.MAKH.Value;
                            xh.DON_GIA_BAN = edit.DON_GIA.Value;
                            xh.SO_LUONG = edit.SO_LUONG.Value;
                            xh.LAI_SUAT = edit.LAI_SUAT.Value;
                            xh.TRA_TRUOC = edit.TRA_TRUOC.Value;
                            dbContext.EDIT_XUAT_HANG.DeleteObject(edit);
                        }
                    }
                }
                // CẬP NHẬT LẠI TOÀN BỘ NHẬP HÀNG XUẤT HÀNG
                foreach (NHAP_HANG nh in dbContext.NHAP_HANG)
                {
                    nh.SL_CON_LAI = nh.SO_LUONG;
                }
                foreach (XUAT_HANG xh in dbContext.XUAT_HANG)
                {
                    MXuatHang.Update(xh.SO_LUONG, xh);
                }
                dbContext.SaveChanges();
                _loadData();
                MessageBox.Show("CẬP NHẬT THÀNH CÔNG THAY ĐỔI XUẤT HÀNG");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                long ID = long.Parse(dataGridView1.CurrentRow.Cells[15].Value.ToString());
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var item = dbContext.EDIT_XUAT_HANG.Where(u => u.XUAT_HANG_ID == ID).First();
                    dbContext.EDIT_XUAT_HANG.DeleteObject(item);
                    dbContext.SaveChanges();
                    _loadData();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
