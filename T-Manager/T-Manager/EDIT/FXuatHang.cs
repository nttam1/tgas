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

        private void dateTimePickerDATE_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = dateTimePickerDATE.Value.Date;
            bs.DataSource = (from xh in dbContext.XUAT_HANG
                             join hh in dbContext.HANG_HOA on xh.MAHH equals hh.ID
                             join kho in dbContext.KHOes on xh.MAKHO equals kho.ID
                             //join kh in dbContext.KHACH_HANG on xh.MAKH equals kh.ID
                             where xh.NGAY_XUAT == now
                             select new
                             {
                                 ID = xh.ID,
                                 KHO = kho.NAME,
                                 HANGHOA = hh.NAME,
                                 KHACHHANG = xh.MAKH, //kh.NAME,
                                 SOLUONG = xh.SO_LUONG,
                                 DONGIA = xh.DON_GIA_BAN,
                                 TRATRUOC = xh.TRA_TRUOC,
                                 LAISUAT = xh.LAI_SUAT,
                                 NGAYXUAT = xh.NGAY_XUAT.Value
                             }
                                 );
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "KHO";
            dataGridView1.Columns[2].HeaderText = "HÀNG HÓA";
            dataGridView1.Columns[3].HeaderText = "KHÁCH HÀNG";
            dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
            dataGridView1.Columns[5].HeaderText = "ĐƠN GIÁ";
            dataGridView1.Columns[6].HeaderText = "TRẢ TRƯỚC";
            dataGridView1.Columns[7].HeaderText = "LÃI XUẤT";
            dataGridView1.Columns[8].HeaderText = "NGÀY XUẤT";
        }

        private void FXuatHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bs;
            dateTimePickerDATE_ValueChanged(sender, e);

            groupBox2.Enabled = false;

            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxHANGHOA.DataSource = dbContext.HANG_HOA.OrderBy(u => u.NAME);
            comboBoxHANGHOA.DisplayMember = "NAME";
            comboBoxHANGHOA.ValueMember = "ID";

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
            listBoxKHACHHANG.DataSource = ls;
            listBoxKHACHHANG.DisplayMember = "NAME";
            listBoxKHACHHANG.ValueMember = "ID";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                groupBox2.Enabled = true;
                var s = dataGridView1.Rows[e.RowIndex];
                textBoxSOLUONG.Text = s.Cells[4].Value.ToString();
                textBoxDONGIA.Text = s.Cells[5].Value.ToString();
                textBoxLAISUAT.Text = s.Cells[7].Value.ToString();
                textBoxTRATRUOC.Text = s.Cells[6].Value.ToString();
                textBoxKHACHHANG.Text = s.Cells[3].Value.ToString();
                dateTimePickerNGAYXUAT.Value = (DateTime)s.Cells[8].Value;
                foreach (HANG_HOA row in comboBoxHANGHOA.Items)
                {
                    if (row.NAME == s.Cells[2].Value.ToString())
                    {
                        comboBoxHANGHOA.SelectedIndex = comboBoxHANGHOA.Items.IndexOf(row);
                    }
                }
                foreach (KHO row in comboBoxKHO.Items)
                {
                    if (row.NAME == s.Cells[1].Value.ToString())
                    {
                        comboBoxKHO.SelectedIndex = comboBoxKHO.Items.IndexOf(row);
                    }
                }
                textBoxID.Text = s.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            long ID = long.Parse(textBoxID.Text);
            var R = dbContext.XUAT_HANG.Where(u => u.ID == ID);
            long kho = ((KHO)comboBoxKHO.SelectedItem).ID;
            long hh = ((HANG_HOA)comboBoxHANGHOA.SelectedItem).ID;
            long kh = long.Parse(textBoxKHACHHANG.Text);
            long sl = long.Parse(textBoxSOLUONG.Text);
            long dg = long.Parse(textBoxDONGIA.Text);
            long ls = long.Parse(textBoxLAISUAT.Text);
            long trt = long.Parse(textBoxTRATRUOC.Text);
            DateTime nx = dateTimePickerNGAYXUAT.Value.Date;
            try
            {
                dbContext.KHACH_HANG.Where(u => u.ID == kh).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai mã khách hàng");
                return;
            }
            foreach (XUAT_HANG r in R)
            {
                r.MAKHO = kho;
                r.MAKH = kh;
                r.MAHH = hh;
                r.NGAY_XUAT = nx;
                r.SO_LUONG = sl;
                r.DON_GIA_BAN = dg;
                r.LAI_SUAT = ls;
                r.TRA_TRUOC = trt;               
            }
            dbContext.SaveChanges();

            /**
            // CẬP NHẬT LẠI TOÀN BỘ NHẬP HÀNG XUẤT HÀNG
            foreach (NHAP_HANG nh in dbContext.NHAP_HANG.Where( u => u.MAKHO == kho && u.MAHH == hh))
            {
                nh.SL_CON_LAI = nh.SO_LUONG;
            }
            foreach (XUAT_HANG xh in dbContext.XUAT_HANG.Where(u => u.MAKHO == kho && u.MAHH == hh))
            {
                MXuatHang.Update(xh.SO_LUONG, xh);
            }
            dbContext.SaveChanges();
            */
            MessageBox.Show("ĐÃ CẬP NHẬT");
            dateTimePickerDATE_ValueChanged(sender, e);
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
