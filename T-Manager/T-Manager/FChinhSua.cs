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
    public partial class FChinhSua : Form
    {
        public FChinhSua()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        tgasEntities db = DataInstance.Instance().DBContext();

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = MHeTHong.Get(MHeTHong.MATKHAU);
            string _pass = textBoxPASSWORD.Text;
            if (pass == _pass)
            {
                dateTimePickerDATE.Enabled = true;
                textBoxPASSWORD.Enabled = false;
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng");
            }
        }

        private void radioButtonVAY_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVAY.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.VAYs.Where(u => u.NGAY_VAY == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Tổng tiền";
                dataGridView1.Columns[3].HeaderText = "Lãi suất";
                dataGridView1.Columns[4].HeaderText = "Kì hạn";
                dataGridView1.Columns[5].HeaderText = "Ngày vay";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
            }
        }

        private void FChinhSua_Load(object sender, EventArgs e)
        {
            List<object> ids = new List<object>();
            ids.Add(new {ID = 0, NAME = "KHO" });
            ids.Add(new { ID = 1, NAME = "TÀI KHOẢN NGÂN HÀNG" });
            ids.Add(new { ID = 2, NAME = "HÀNG HÓA" });
            ids.Add(new { ID = 3, NAME = "NHÀ CUNG CẤP" });
            ids.Add(new { ID = 4, NAME = "NHÂN VIÊN" });
            ids.Add(new { ID = 5, NAME = "XE" });
            ids.Add(new { ID = 6, NAME = "NGUỒN VAY" });
            ids.Add(new { ID = 7, NAME = "KHÁCH HÀNG | NGUỒN NỢ" });
            comboBoxDULIEU.DataSource = ids;
            comboBoxDULIEU.DisplayMember = "NAME";
            comboBoxDULIEU.ValueMember = "ID";
            dataGridView1.DataSource = bs;
            comboBoxDULIEU_SelectedIndexChanged(sender, e);
            radioButtonVAY_CheckedChanged(sender, e);
        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            bs.ResetBindings(false);
            db.SaveChanges();
        }

        private void comboBoxDULIEU_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long l = long.Parse(comboBoxDULIEU.SelectedValue.ToString());
                List<object> ls = new List<object>();
                IQueryable lst;
                switch (l)
                {
                    case 0:
                        lst = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.ID);
                        foreach (KHO k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                    case 1:
                        lst = MKho.Get(MKho.KHO_TK_NGANHANG);
                        foreach (KHO k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                    case 2:
                        lst = MHangHoa.Get();
                        foreach (HANG_HOA k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                    case 3:
                        lst = MNcc.Get();
                        foreach (NHA_CUNG_CAP k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                    case 4:
                        lst = db.NHAN_VIEN;
                        foreach (NHAN_VIEN k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                    case 5:
                        lst = db.XEs;
                        foreach (XE k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.BIEN_SO
                            });
                        }
                        break;
                    case 6:
                        lst = db.NGUON_VAY;
                        foreach (NGUON_VAY k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                    case 7:
                        lst = db.KHACH_HANG;
                        foreach (KHACH_HANG k in lst)
                        {
                            ls.Add(new
                            {
                                ID = k.ID,
                                NAME = k.ID.ToString() + " - " + k.NAME
                            });
                        }
                        break;
                }
                listBoxKHO.DataSource = ls;
                listBoxKHO.DisplayMember = "NAME";
                listBoxKHO.ValueMember = "ID";
            }
            catch(Exception ex)
            {

            }
        }

        private void radioButtonCHOVAY_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCHOVAY.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.CHO_VAY.Where(u => u.NGAY_CHO_VAY == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[3].HeaderText = "Tổng tiền";
                dataGridView1.Columns[4].HeaderText = "Lãi suất";
                dataGridView1.Columns[5].HeaderText = "Ngày cho vay";
            }
        }

        private void radioButtonNHAPHANG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNHAPHANG.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.NHAP_HANG.Where(u => u.NGAY_NHAP == now && u.SL_CON_LAI > 0);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "ĐƠN GIÁ";
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void radioButtonCHUYENTIEN_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCHUYENTIEN.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.CHUYEN_TIEN.Where(u => u.NGAY_CHUYEN == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "TÀI KHOẢN";
                dataGridView1.Columns[2].HeaderText = "TỔNG TIỀN";
                dataGridView1.Columns[3].HeaderText = "NGÀY CHUYỂN";
                dataGridView1.Columns[4].Visible = false;
            }
        }

        private void radioButtonTRANOVAY_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTRANOVAY.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.TRA_NO_VAY.Where(u => u.NGAY_TRA == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "NGUỒN VAY";
                dataGridView1.Columns[2].HeaderText = "MÃ KHO";
                dataGridView1.Columns[3].HeaderText = "TIỀN GỐC";
                dataGridView1.Columns[4].HeaderText = "TIỀN LÃI";
                dataGridView1.Columns[5].HeaderText = "NGÀY TRẢ";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void radioButtonTRANONCC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTRANONCC.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.TRA_NO_NCC.Where(u => u.NGAY_TRA == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "NHÀ CUNG CẤP";
                dataGridView1.Columns[2].HeaderText = "TỔNG TIỀN";
                dataGridView1.Columns[3].HeaderText = "NGÀY TRẢ";
                dataGridView1.Columns[4].HeaderText = "MÃ KHO";
                dataGridView1.Columns[5].Visible = false;
            }
        }

        private void radioButtonCHILUONG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCHILUONG.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.CHI_LUONG.Where(u => u.NGAY_CHI == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "MÃ KHO";
                dataGridView1.Columns[2].HeaderText = "MÃ NHÂN VIÊN";
                dataGridView1.Columns[3].HeaderText = "LƯƠNG THÁNG";
                dataGridView1.Columns[4].HeaderText = "NGÀY CHI";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "TỔNG TIỀN";
            }
        }

        private void radioButtonCHINOIBO_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCHINOIBO.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.CHI_TIEU_DUNG_NOI_BO.Where(u => u.NGAY_CHI == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "MÃ KHO";
                dataGridView1.Columns[2].HeaderText = "MÃ HÀNG HÓA";
                dataGridView1.Columns[3].HeaderText = "MÃ XE";
                dataGridView1.Columns[4].HeaderText = "SỐ LƯỢNG";
                dataGridView1.Columns[5].HeaderText = "ĐƠN GIÁ";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "NGÀY CHI";
            }
        }

        private void radioButtonCHIKHAC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCHIKHAC.Checked == true)
            {
                DateTime now = dateTimePickerDATE.Value.Date;
                bs.DataSource = db.CHI_KHAC.Where(u => u.NGAY_CHI == now);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "MÃ KHO";
                dataGridView1.Columns[2].HeaderText = "NỘI DUNG";
                dataGridView1.Columns[3].HeaderText = "TỔNG TIỀN";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "NGÀY CHI";
            }
        }
    }
}
