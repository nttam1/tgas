using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;
using T_Manager.Modal;
using System.IO;

namespace T_Manager
{
    public partial class FImport : Form
    {
        public FImport()
        {
            InitializeComponent();
        }

        private void buttonFILE_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xls;";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        private Excel.Workbook MyBook = null;
        private Excel.Application MyApp = null;
        private Excel.Worksheet hhSheet = null;
        private Excel.Worksheet tonSheet = null;

        private void buttonIMPORT_Click(object sender, EventArgs e)
        {
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(textBox1.Text);
            hhSheet = (Excel.Worksheet)MyBook.Sheets[1];
            tonSheet = (Excel.Worksheet)MyBook.Sheets[2];
            long hhCount = hhSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            long khoCount = tonSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
            DataInstance.Instance().DBContext();

            // HANG HOA
            for (int index = 2; index <= hhCount; index++)
            {
                System.Array MyValues = (System.Array)hhSheet.get_Range("A" +
                   index.ToString(), "B" + index.ToString()).Cells.Value;
                DataInstance.Instance().DBContext().AddToHANG_HOA(new HANG_HOA
                {
                    NAME = MyValues.GetValue(1, 1).ToString(),
                    UNIT = MyValues.GetValue(1, 2).ToString(),
                });
            }

            // KHO
            for (int index = 2; index <= khoCount; index++)
            {
                string MyValues = tonSheet.Cells[1, index].Value;
                DataInstance.Instance().DBContext().AddToKHOes(new KHO
                {
                    NAME = MyValues,
                    TYPE = MKho.KHO_HANG
                });

                DataInstance.Instance().DBContext().SaveChanges();
                for (int i = 2; i <= hhCount; i++)
                {
                    long sl = long.Parse(tonSheet.Cells[i, index].Value.ToString());
                    long dongia = long.Parse(hhSheet.Cells[i, 3].Value.ToString());
                    DataInstance.Instance().DBContext().AddToNHAP_HANG(new NHAP_HANG
                    {
                        MAKHO = MKho.GetIDbyName(tonSheet.Cells[1, index].Value.ToString()),
                        MANCC = -1,
                        MAHH = MHangHoa.GetIDbyName(hhSheet.Cells[i, 1].Value.ToString()),
                        SO_LUONG = sl,
                        SL_CON_LAI = sl,
                        DON_GIA_MUA = dongia,
                        NGAY_NHAP = DateTime.Now.Date,
                        CREATED_AT = DateTime.Now
                    });
                }
            }
            DataInstance.Instance().DBContext().SaveChanges();
            MessageBox.Show("Cập nhật dữ liệu thành công\nVui lòng khởi động lại chương trình");
            MyBook.Close();
            MyApp.Quit();

            MHeTHong.Set(MHeTHong.DATE, DateTime.Now.ToLongDateString());
            Application.Exit();
        }

        private void FImport_Load(object sender, EventArgs e)
        {
            //DateTime now = DateTime.Now;
            //string originName = "tgas_origin";
            //string Name = "tgas";
            //string tmpName = "tgas_" + now.Date.Day.ToString() +  now.Date.Month.ToString() +now.Date.Year.ToString();
            //File.Copy(Name, tmpName, true);
            //File.Copy(originName, Name, true);
        }
    }
}