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
    public partial class FTongHopCongNo : Form
    {
        public FTongHopCongNo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CTongHopCongNo> _datasource = new List<CTongHopCongNo>();
            var include_THUNO = checkBoxTHUNO.Checked;
            string note = "";
            var kho = long.Parse(comboBoxKHO.SelectedValue.ToString());
            var _from = dateTimePicker1.Value.Date;
            var _to = dateTimePicker2.Value.Date;

            BindingSource bs = new BindingSource();

            /* Tính tổng tiền, trả trước group theo MAKH */
            var _xh = (from xh in DataInstance.Instance().DBContext().XUAT_HANG
                       join kh in DataInstance.Instance().DBContext().KHACH_HANG on xh.MAKH equals kh.ID
                       where xh.MAKHO == kho
                       where xh.NGAY_XUAT >= _from && xh.NGAY_XUAT <= _to
                       group xh by new { xh.MAKH, kh.NAME } into g
                       select new CTongHopCongNo()
                       {
                           STT = g.Key.MAKH,
                           MAKH = g.Key.MAKH,
                           KHACHHANG = g.Key.NAME,
                           TRATRUOC = g.Sum(u => u.TRA_TRUOC),
                           THANHTIEN = g.Sum(u => u.THANH_TIEN),
                           DATRA = 0,
                           CONNO = g.Sum(u => u.THANH_TIEN - u.TRA_TRUOC)
                       }
                       );

            int STT = 1;
            if (include_THUNO == false)
            {
                note = "KHÔNG TÍNH TIỀN LÃI";
                /* Có sử dụng dữ liệu thu nợ */
                /* Tính tổng lãi cho từng KH */
                foreach (CTongHopCongNo row in _xh)
                {
                    //double lai = 0;
                    double datra = 0;
                    /* Tính lãi cho tất cả những lần xuất hàng cho KH */
                    foreach (XUAT_HANG _row in (from _xh_ in DataInstance.Instance().DBContext().XUAT_HANG
                                                where _xh_.MAKHO == kho
                                                where _xh_.MAKH == row.MAKH
                                                select _xh_))
                    {
                        /* Không sử dụng dữ liệu từ thu nợ */
                        //lai += MXuatHang.GetLaiPhatSinh((int)_row.ID, _to);
                        datra += MChiTietThuNo.TraGocHH((int)_row.ID);
                    }
                    _datasource.Add(new CTongHopCongNo()
                    {
                        STT = STT++,
                        KHACHHANG = row.KHACHHANG,
                        TRATRUOC = row.TRATRUOC,
                        THANHTIEN = row.THANHTIEN ,
                        DATRA = (long)datra,
                        CONNO = row.THANHTIEN- (long)datra - row.TRATRUOC
                    });
                }
            }
            else
            {
                note = "BAO GỒM TIỀN LÃI";
                /* Không sử dụng dữ liệu thu nợ*/
                /* Tính tổng lãi cho từng KH */
                foreach (CTongHopCongNo row in _xh)
                {
                    double lai = 0;
                    double datra = 0;
                    foreach (XUAT_HANG _row in (from _xh_ in DataInstance.Instance().DBContext().XUAT_HANG
                                                where _xh_.MAKHO == kho
                                                where _xh_.MAKH == row.MAKH
                                                select _xh_))
                    {
                        lai += MXuatHang.GetLai((int)_row.ID, _to);
                        datra += MChiTietThuNo.DaTraHH((int)_row.ID);
                    }
                    _datasource.Add(new CTongHopCongNo()
                    {
                        STT = STT++,
                        KHACHHANG = row.KHACHHANG,
                        TRATRUOC = row.TRATRUOC,
                        THANHTIEN = row.THANHTIEN + (long)lai,
                        DATRA = (long)datra,
                        CONNO = row.THANHTIEN - (long)datra - row.TRATRUOC + (long)lai
                    });
                }
            }
            bs.DataSource = _datasource;
            CrystalReportTONGHOPCONGNO rpt = new CrystalReportTONGHOPCONGNO();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KHO", comboBoxKHO.Text);
            rpt.SetParameterValue("FROM", _from);
            rpt.SetParameterValue("TO", _to);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            rpt.SetParameterValue("NOTE", note);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }

        private void FTongHopCongNo_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = MKho.Get(MKho.KHO_HANG).OrderBy(u => u.NAME);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";

            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    class CTongHopCongNo
    {
        public long STT;
        public long MAKH;
        public string KHACHHANG;
        public Int64 TRATRUOC;
        public Int64 THANHTIEN;
        public Int64 DATRA;
        public Int64 CONNO;
    }

}
