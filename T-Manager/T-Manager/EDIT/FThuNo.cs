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
    public partial class FThuNo : Form
    {
        public FThuNo()
        {
            InitializeComponent();
        }

        BindingSource bs = new BindingSource();
        tgasEntities db = DataInstance.Instance().DBContext();

        private void FThuNo_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;


            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            comboBoxKHACHHANG.DataSource = db.KHACH_HANG.OrderBy(u => u.NAME);
            comboBoxKHACHHANG.DisplayMember = "NAME";
            comboBoxKHACHHANG.ValueMember = "ID";

            dateTimePickerDATE_ValueChanged(sender, e);

        }

        private void buttonLOGIN_Click(object sender, EventArgs e)
        {
            string pass = MHeTHong.Get(MHeTHong.MATKHAU);
            string _pass = textBoxPASS.Text;
            if (pass == _pass)
            {
                dateTimePickerDATE.Enabled = true;
                textBoxPASS.Enabled = false;
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng");
            }
        }

        private void dateTimePickerDATE_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = dateTimePickerDATE.Value.Date;
            try
            {
            bs.DataSource = (from xh in db.THU_NO
                             join kho in db.KHOes on xh.MAKHO equals kho.ID
                             join kh in db.KHACH_HANG on xh.MAKH equals kh.ID
                             where xh.NGAY_TRA == now
                             select new
                             {
                                 ID = xh.ID,
                                 KHO = kho.NAME,
                                 KHACHHANG = kh.NAME,
                                 TIENGOC = xh.TIEN_GOC,
                                 TIENLAI = xh.TIEN_LAI,
                                 NGAYTRA = xh.NGAY_TRA
                             });
            dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "KHO";
                dataGridView1.Columns[2].HeaderText = "KHÁCH HÀNG";
                dataGridView1.Columns[3].HeaderText = "TIỀN GỐC";
                dataGridView1.Columns[4].HeaderText = "TIỀN LÃI";
                dataGridView1.Columns[5].HeaderText = "NGÀY TRẢ";
            }
            catch (Exception ex)
            {


            }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            groupBox2.Enabled = true;
            var s = dataGridView1.Rows[e.RowIndex];
            textBoxTIENGOC.Text = s.Cells[3].Value.ToString();
            textBoxTIENLAI.Text = s.Cells[4].Value.ToString();
            textBoxID.Text = s.Cells[0].Value.ToString();
            dateTimePickerNGAYXUAT.Value = (DateTime)s.Cells[5].Value;

            foreach (KHO row in comboBoxKHO.Items)
            {
                if (row.NAME == s.Cells[1].Value.ToString())
                {
                    comboBoxKHO.SelectedIndex = comboBoxKHO.Items.IndexOf(row);
                }
            }
            foreach (KHACH_HANG row in comboBoxKHACHHANG.Items)
            {
                if (row.NAME == s.Cells[2].Value.ToString())
                {
                    comboBoxKHACHHANG.SelectedIndex = comboBoxKHACHHANG.Items.IndexOf(row);
                }
            }
        }

        private void comboBoxKHACHHANG_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            // CẬP NHẬT DỮ LIỆU
            long ID = long.Parse(textBoxID.Text);
            long loaino = -1;
            var R = db.THU_NO.Where(u => u.ID == ID);

            long kho = ((KHO)comboBoxKHO.SelectedItem).ID;
            long kh = ((KHACH_HANG)comboBoxKHACHHANG.SelectedItem).ID;
            long tg = long.Parse(textBoxTIENGOC.Text);
            long tl = long.Parse(textBoxTIENLAI.Text);
            DateTime nt = dateTimePickerNGAYXUAT.Value.Date;
            foreach (THU_NO r in R)
            {
                r.MAKHO = kho;
                r.MAKH = kh;
                r.TIEN_LAI = tl;
                r.TIEN_GOC = tg;
                r.NGAY_TRA = nt;
                loaino = r.LOAI_NO;
            }
            db.SaveChanges();
            // XÓA TOÀN BỘ CHI TIẾT THU NƠ
            if (loaino == MThuNo.NO_VAY)
            {
                var thunoes = db.CHO_VAY.Where(u => u.MA_NGUON_NO == kh);
                foreach (CHO_VAY tn in thunoes)
                {
                    foreach (CHI_TIET_THU_NO ct in db.CHI_TIET_THU_NO.Where(u => u.NO_ID == tn.ID))
                    {
                        db.CHI_TIET_THU_NO.DeleteObject(ct);
                    }

                }
            }
            else
            {
                var thunoes = db.XUAT_HANG.Where(u => u.MAKH == kh);
                foreach (XUAT_HANG tn in thunoes)
                {
                    foreach (CHI_TIET_THU_NO ct in db.CHI_TIET_THU_NO.Where(u => u.NO_ID == tn.ID))
                    {
                        db.CHI_TIET_THU_NO.DeleteObject(ct);
                    }

                }
            }
            db.SaveChanges();
            // CẬP NHẬT CHI TIẾT THU NỢ
            foreach (THU_NO tn in db.THU_NO.Where(u => u.MAKH == kh))
            {
                MThuNo.Update(tn);
            }
            MessageBox.Show("Cập nhật xong");
        }
    }
}
