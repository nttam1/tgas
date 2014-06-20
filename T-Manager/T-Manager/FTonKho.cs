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
    public partial class FTonKho : Form
    {
        public FTonKho()
        {
            InitializeComponent();
        }

        private tgasEntities db = DataInstance.Instance().DBContext();

        private void FTonKho_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            List<long> KHOes = db.KHOes.OrderBy(u => u.NAME).Select(u => u.ID).ToList();
            bool wrong_input = false;
            foreach (DataGridViewRow row in dataGridViewIMPORT.Rows)
            {
                long MAHH = MHangHoa.GetIDbyName(row.Cells[0].Value.ToString());
                for (int i = 1; i < row.Cells.Count - 1; i += 2)
                {
                    long soluong = long.Parse(row.Cells[i].Value.ToString());
                    long dongia = long.Parse(row.Cells[i+1].Value.ToString());
                    long MAKHO = KHOes[i / 2];
                    if (soluong > 0 && dongia > 0)
                    {
                        db.AddToNHAP_HANG(new NHAP_HANG
                        {
                            MAKHO = MAKHO,
                            MANCC = -1,
                            MAHH = MAHH,
                            SO_LUONG = soluong,
                            SL_CON_LAI = soluong,
                            DON_GIA_MUA = dongia,
                            NGAY_NHAP = DateTime.Now.Date,
                            CREATED_AT = DateTime.Now
                        });
                    }
                    else
                    {
                        if (!(soluong == 0 && dongia == 0))
                        {
                            wrong_input = true;
                        }
                    }
                }
            }
            if (wrong_input == false)
            {
                db.SaveChanges();
                MessageBox.Show("ĐÃ NHẬP TỒN KHO");
                Reload();
            }
            else
            {
                MessageBox.Show("DỮ LIỆU NHẬP KHÔNG PHÙ HỢP\nNẾU CÓ SỐ LƯỢNG, PHẢI CÓ ĐƠN GIÁ");
            }
        }

        private void Reload()
        {
                var khoes = db.KHOes.OrderBy(u => u.NAME);
                var hanghoas = db.HANG_HOA.OrderBy(u => u.NAME);

                if (dataGridViewIMPORT.Columns.Count == 0)
                {
                    dataGridViewIMPORT.Columns.Add("HANG_HOA", "");
                    foreach (KHO kho in khoes)
                    {
                        dataGridViewIMPORT.Columns.Add("SL" + kho.ID.ToString(), "SỐ LƯỢNG: " + kho.NAME);
                        dataGridViewIMPORT.Columns.Add("DG" + kho.ID.ToString(), "ĐƠN GIÁ: " + kho.NAME);
                    }
                    for (int i = 0; i < dataGridViewIMPORT.Columns.Count; i++)
                    {

                        dataGridViewIMPORT.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                if (dataGridViewIMPORT.Rows.Count > 1)
                {
                    dataGridViewIMPORT.Rows.Clear();
                    dataGridViewIMPORT.AllowUserToAddRows = true;
                }
                foreach (HANG_HOA hh in hanghoas)
                {
                    dataGridViewIMPORT.Rows.Add();
                    DataGridViewRow row = (DataGridViewRow)dataGridViewIMPORT.Rows[dataGridViewIMPORT.Rows.GetLastRow(DataGridViewElementStates.Displayed) - 1];
                    row.Cells[0].Value = hh.NAME;
                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Value = 0;
                    }
                }
                dataGridViewIMPORT.Columns[0].ReadOnly = true;
                dataGridViewIMPORT.AllowUserToAddRows = false;
                dataGridViewIMPORT.CurrentCell = dataGridViewIMPORT.Rows[0].Cells[1];
        }


        private void dataGridViewIMPORT_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Chỉ được phép nhập số");
                }
                else
                {
                }
            }
        }
    }
}
