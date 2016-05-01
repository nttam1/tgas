using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager;

namespace T_Manager_Confirm_Edit
{
    public partial class Admin : Form
    {
        private tgasEntities dbContext = DataInstance.Instance().DBContext();
        BindingSource bs = new BindingSource();
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            bs.DataSource = (from edit in dbContext.EDIT_XUAT_HANG
                             join xh in dbContext.XUAT_HANG on edit.XUAT_HANG_ID equals xh.ID
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
    }
}
