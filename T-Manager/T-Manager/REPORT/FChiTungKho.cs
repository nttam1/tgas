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
    public partial class FChiTungKho : Form
    {
        public FChiTungKho()
        {
            InitializeComponent();
        }

        private void FChiTungKho_Load(object sender, EventArgs e)
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
            List<CChiTungKho> list = new List<CChiTungKho>();
            var luong = (from _luong in DataInstance.Instance().DBContext().CHI_LUONG
                         join _nv in DataInstance.Instance().DBContext().NHAN_VIEN on _luong.MANV equals _nv.ID
                         where _luong.MAKHO == _kho
                         where _luong.NGAY_CHI >= _from && _luong.NGAY_CHI <= _to
                         select new CChiTungKho
                         {
                             NGAYCHI = _luong.NGAY_CHI,
                             NOIDUNG = "Chi luong: " + _nv.NAME,
                             TONGTIEN = _luong.TONG_TIEN,
                         });

            var noibo = (from _chi in DataInstance.Instance().DBContext().CHI_TIEU_DUNG_NOI_BO
                         join _xe in DataInstance.Instance().DBContext().XEs on _chi.MAXE equals _xe.ID
                         where _chi.MAKHO == _kho
                         where _chi.NGAY_CHI >= _from && _chi.NGAY_CHI <= _to
                         select new CChiTungKho
                         {
                             NGAYCHI = _chi.NGAY_CHI,
                             NOIDUNG = "Xe: " + _xe.BIEN_SO,
                             TONGTIEN = _chi.SO_LUONG * _chi.DON_GIA_BAN,
                         });
            var khac = (from _luong in DataInstance.Instance().DBContext().CHI_KHAC
                        where _luong.MAKHO == _kho
                        where _luong.NGAY_CHI >= _from && _luong.NGAY_CHI <= _to
                         select new CChiTungKho
                         {
                             NGAYCHI = _luong.NGAY_CHI,
                             NOIDUNG = _luong.NOI_DUNG,
                             TONGTIEN = _luong.TONG_TIEN,
                         });
            var chovay = (from _luong in DataInstance.Instance().DBContext().CHO_VAY
                          join _kh in DataInstance.Instance().DBContext().KHACH_HANG on _luong.MA_NGUON_NO equals _kh.ID
                          where _luong.MAKHO == _kho
                          where _luong.NGAY_CHO_VAY >= _from && _luong.NGAY_CHO_VAY <= _to
                          select new CChiTungKho
                          {
                              NGAYCHI = _luong.NGAY_CHO_VAY,
                              NOIDUNG = "Cho vay: " + _kh.NAME,
                              TONGTIEN = _luong.TONG_TIEN,
                          });


            /*CHI LUONG*/
            foreach (CChiTungKho h in luong)
            {
                list.Add(h);
            }
            foreach (CChiTungKho h in noibo)
            {
                list.Add(h);
            }
            foreach (CChiTungKho h in khac)
            {
                list.Add(h);
            }
            list = list.OrderBy(u => u.NGAYCHI).ToList();
            bs.DataSource = list;
            CrystalReportCHITUNGKHO rpt = new CrystalReportCHITUNGKHO();
            rpt.SetDataSource(bs);
            rpt.SetParameterValue("KHO", comboBoxKHO.Text);
            rpt.SetParameterValue("FROM", dateTimePickerFROM.Value);
            rpt.SetParameterValue("TO", dateTimePickerTO.Value);
            rpt.SetParameterValue("COMP", ConstClass.COMPANY_NAME);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Zoom(150);
        }
    }
    class CChiTungKho
    {
        public DateTime NGAYCHI;
        public string NOIDUNG;
        public long TONGTIEN;
    }
}
