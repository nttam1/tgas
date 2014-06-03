using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T_Manager.Modal;
using Newtonsoft.Json;

namespace T_Manager.REPORT
{
    public partial class FLaiLoTungKho : Form
    {
        public FLaiLoTungKho()
        {
            InitializeComponent();
        }

        private void FLaiLoTungKho_Load(object sender, EventArgs e)
        {
            dateTimePickerFROM.Value = DateTime.Now.AddMonths(-1);
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
        }

        private void buttonVIEW_Click(object sender, EventArgs e)
        {
            long _kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            DateTime _from = dateTimePickerFROM.Value.Date;
            DateTime _to = dateTimePickerTO.Value.Date;
            BindingSource bs = new BindingSource();
            List<CLaiLoTungKho> list = new List<CLaiLoTungKho>();
            var hanghoa = (from _hh in DataInstance.Instance().DBContext().HANG_HOA select _hh);
            var khachhang = (from _hh in DataInstance.Instance().DBContext().KHACH_HANG select _hh);
            var banhang = (from _bh in DataInstance.Instance().DBContext().BAN_HANG
                           where _bh.MAKHO == _kho
                           where _bh.NGAY_BAN >= _from && _bh.NGAY_BAN <= _to
                           select _bh);
            var xuathang = (from _bh in DataInstance.Instance().DBContext().XUAT_HANG
                           where _bh.MAKHO == _kho
                            where _bh.NGAY_XUAT >= _from && _bh.NGAY_XUAT <= _to
                           select _bh);

            foreach (BAN_HANG b in banhang)
            {
                List<CXuatHangChiTiet> bchitiet = JsonConvert.DeserializeObject<List<CXuatHangChiTiet>>(b.CHI_TIET_BAN_HANG);
                foreach (CXuatHangChiTiet row in bchitiet)
                {
                    CLaiLoTungKho c = new CLaiLoTungKho();
                    c.NGAY = b.NGAY_BAN;
                    c.HANGHOA = hanghoa.Where(u => u.ID == b.MAHH).First().NAME;
                    c.GHICHU = "Bán hàng";
                    c.SOLUONG = row.SOLUONG;
                    c.DONGIAMUA = row.DONGIA;
                    c.DONGIABAN = b.DON_GIA_BAN;
                    c.TONGLAI = row.SOLUONG * (b.DON_GIA_BAN - row.DONGIA);
                    list.Add(c);
                }
            }

            foreach (XUAT_HANG b in xuathang)
            {
                List<CXuatHangChiTiet> bchitiet = JsonConvert.DeserializeObject<List<CXuatHangChiTiet>>(b.CHI_TIET_XUAT_HANG);
                foreach (CXuatHangChiTiet row in bchitiet)
                {
                    CLaiLoTungKho c = new CLaiLoTungKho();
                    c.NGAY = b.NGAY_XUAT.Value;
                    c.HANGHOA = hanghoa.Where(u => u.ID == b.MAHH).First().NAME;
                    c.GHICHU = "Xuất hàng: " + khachhang.Where(u => u.ID == b.MAKH).First().NAME;
                    c.SOLUONG = row.SOLUONG;
                    c.DONGIAMUA = row.DONGIA;
                    c.DONGIABAN = b.DON_GIA_BAN;
                    c.TONGLAI = row.SOLUONG * (b.DON_GIA_BAN - row.DONGIA);
                    list.Add(c);
                }
            }

            list = list.OrderBy(u => u.NGAY).ToList();
            bs.DataSource = list;
            CrystalReportLAILOTUNGKHO rpt = new CrystalReportLAILOTUNGKHO();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KHO", comboBoxKHO.Text);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            rpt.SetParameterValue("TONGCHI", MKho.Total_Chi(_kho, _from, _to));
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }
    }
    class CLaiLoTungKho
    {
        public DateTime NGAY;
        public string HANGHOA;
        public string GHICHU;
        public long SOLUONG;
        public long DONGIAMUA;
        public long DONGIABAN;
        public long TONGLAI;

    }
}
