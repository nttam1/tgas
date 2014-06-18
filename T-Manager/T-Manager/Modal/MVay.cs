﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_Manager.Modal
{
    class MVay
    {
        public const int CHUA_TRA_XONG = 0;
        public const int DA_TRA_XONG = 1;


        public static List<object> ThoiDoan()
        {
            List<object> l = new List<object>();
            l.Add(new { NAME = "1 Tháng", VALUE = 1 });
            l.Add(new { NAME = "2 Tháng", VALUE = 2 });
            l.Add(new { NAME = "3 Tháng", VALUE = 3 });
            l.Add(new { NAME = "6 Tháng", VALUE = 6 });
            l.Add(new { NAME = "9 Tháng", VALUE = 9 });
            l.Add(new { NAME = "12 Tháng", VALUE = 12 });
            l.Add(new { NAME = "24 Tháng", VALUE = 24 });
            l.Add(new { NAME = "36 Tháng", VALUE = 36 });
            return l;
        }

        public static CThanhToan THANHTOAN(long Ma_Nguon_Vay, DateTime From)
        {
            return THANHTOAN(Ma_Nguon_Vay, From, DateTime.Now);
        }

        public static CThanhToan THANHTOAN(long Ma_Nguon_Vay, DateTime From, DateTime To)
        {
            CThanhToan result = new CThanhToan();
            long goc = 0;
            long lai = 0;
            try
            {
                goc = (from _tt in DataInstance.Instance().DBContext().TRA_NO_VAY
                            where _tt.MA_NGUON_VAY == Ma_Nguon_Vay && _tt.NGAY_TRA >= From && _tt.NGAY_TRA <= To
                            select _tt.TIEN_GOC).Sum();

            }
            catch (Exception ex)
            {

            }

            try
            {
                lai = (from _tt in DataInstance.Instance().DBContext().TRA_NO_VAY
                       where _tt.MA_NGUON_VAY == Ma_Nguon_Vay && _tt.NGAY_TRA >= From && _tt.NGAY_TRA <= To
                       select _tt.TIEN_LAI).Sum();

            }
            catch (Exception ex)
            {

            }
            result.GOC = goc;
            result.LAI = lai;
            return result;
        }


        public static CThanhToan THANHTOAN(VAY vay)
        {
            CThanhToan result = new CThanhToan();
            try
            {
                CThanhToan _e = (from tnv in DataInstance.Instance().DBContext().TRA_NO_VAY
                                 where tnv.VAY_ID == vay.ID
                                 group tnv by tnv.VAY_ID into g
                                 select new CThanhToan
                                     {
                                         GOC = g.Sum(u => u.TIEN_GOC),
                                         LAI = g.Sum(u => u.TIEN_LAI)
                                     }).First();
                result.GOC = _e.GOC;
                result.LAI = _e.LAI;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
    class CThanhToan
    {
        public long GOC = 0;
        public long LAI = 0;
    }

    class CThoiDoan
    {
        public string NAME;
        public int VALUE;
    }

}
