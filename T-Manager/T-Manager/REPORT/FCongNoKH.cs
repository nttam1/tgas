using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager.Modal;

namespace T_Manager.REPORT
{
    public partial class FCongNoKH : Form
    {
        public FCongNoKH()
        {
            InitializeComponent();
        }

        tgasEntities db = DataInstance.Instance().DBContext();

        private void FCongNoKH_Load(object sender, EventArgs e)
        {
            var i2nKH = new Id2Name(textBoxKHACHHANG, comboBox1); 
            comboBox1.DataSource = DataInstance.Instance().DBContext().KHACH_HANG.OrderBy(u => u.NAME);
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "ID";

            dateTimePickerFROM.Value = dateTimePickerFROM.Value.AddMonths(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CCongNoNew> _datasource = new List<CCongNoNew>();
            string note = "";
            BindingSource bs = new BindingSource();
            long MAKH = long.Parse(comboBox1.SelectedValue.ToString());
            DateTime FROM = dateTimePickerFROM.Value.Date;
            DateTime TO = dateTimePickerTO.Value.Date;
            var xuat_hang = db.XUAT_HANG.Where(u => u.MAKH == MAKH && u.NGAY_XUAT >= FROM && u.NGAY_XUAT <= TO);
            var thu_no = db.THU_NO.Where(u => u.MAKH == MAKH && u.NGAY_TRA >= FROM && u.NGAY_TRA <= TO);
            foreach (XUAT_HANG xh in xuat_hang)
            {
                HANG_HOA _hh = MHangHoa.GetByID(xh.MAHH);
                string unit = _hh == null ? "" : _hh.UNIT;
                long dongia = _hh == null ? 0 : xh.DON_GIA_BAN;
                long soluong = _hh == null ? 0 : xh.SO_LUONG;
                _datasource.Add(new CCongNoNew
                {
                    NGAY = xh.NGAY_XUAT.Value,
                    TRANO = soluong < 0 ? "Nhập bù" : "",
                    TRATRUOC = xh.TRA_TRUOC,
                    HANGHOA = MHangHoa.GetNameByID(xh.MAHH),
                    SOLUONG = soluong,
                    DONVITINH = unit,
                    DONGIA = dongia,
                    THANHTIEN = xh.THANH_TIEN,
                    TRAGOC = 0,
                    TRALAI = 0,
                    CONNO = 0
                });
            }

            foreach (THU_NO xh in thu_no)
            {
                _datasource.Add(new CCongNoNew
                {
                    NGAY = xh.NGAY_TRA,
                    TRATRUOC = 0,
                    TRANO = "Trả nợ",
                    HANGHOA = "",
                    SOLUONG = 0,
                    DONVITINH = "",
                    DONGIA = 0,
                    THANHTIEN = 0,
                    TRAGOC = xh.TIEN_GOC,
                    TRALAI = xh.TIEN_LAI,
                    CONNO = 0
                });
            }
            var datasource = _datasource.OrderBy(u => u.NGAY);
            long no = checkBoxNODAUKI.Checked == true ? MXuatHang.TongNoDauKi(MAKH, FROM) - MThuNo.TongGocDauKi(MAKH, FROM) : 0;
            long nodauki = no;
            foreach (CCongNoNew c in datasource)
            {
                c.CONNO = no + c.THANHTIEN - c.TRATRUOC - c.TRAGOC;
                no = c.CONNO;
            }

            bs.DataSource = datasource;
            CrystalReportCONGNOKHACHHANG rpt = new CrystalReportCONGNOKHACHHANG();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KH", comboBox1.Text);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            rpt.SetParameterValue("NODAUKI", nodauki);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }

        private void textBoxKHACHHANG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
            }
        }
    }

    class CCongNoNew
    {
        public DateTime NGAY;
        public string TRANO;
        public long HANGHOAID;
        public string HANGHOA;
        public long SOLUONG;
        public long DONGIA;
        public long THANHTIEN;
        public long TRATRUOC;
        public long TRAGOC;
        public long TRALAI;
        public long CONNO;
        public string DONVITINH;
    }
}
