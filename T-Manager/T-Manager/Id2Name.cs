using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace T_Manager
{
    class Id2Name
    {
        private TextBox txt;
        private ComboBox cb;

        public Id2Name(TextBox tx, ComboBox cb)
        {
            this.txt = tx;
            this.cb = cb;
            this.txt.TextChanged += new EventHandler(tx_TextChanged);
            this.cb.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);
        }

        private void tx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long value = long.Parse(txt.Text);
                var ob = cb.SelectedItem;
                if (ob.GetType().Name == "KHO")
                {
                    KHO _e = DataInstance.Instance().DBContext().KHOes.Where(u => u.ID == value).First();
                    cb.SelectedItem = _e;
                }
                if (ob.GetType().Name == "NHA_CUNG_CAP")
                {
                    NHA_CUNG_CAP _e = DataInstance.Instance().DBContext().NHA_CUNG_CAP.Where(u => u.ID == value).First();
                    cb.SelectedItem = _e;
                }
                if (ob.GetType().Name == "KHACH_HANG")
                {
                    KHACH_HANG _e = DataInstance.Instance().DBContext().KHACH_HANG.Where(u => u.ID == value).First();
                    cb.SelectedItem = _e;
                }
                if (ob.GetType().Name == "HANG_HOA")
                {
                    HANG_HOA _e = DataInstance.Instance().DBContext().HANG_HOA.Where(u => u.ID == value).First();
                    cb.SelectedItem = _e;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cb_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var ob = cb.SelectedItem;
                if (ob.GetType().Name == "KHO")
                {
                    KHO _e = (KHO)cb.SelectedItem;
                    txt.Text = _e.ID.ToString();
                }
                if (ob.GetType().Name == "NHA_CUNG_CAP")
                {
                    NHA_CUNG_CAP _e = (NHA_CUNG_CAP)cb.SelectedItem;
                    txt.Text = _e.ID.ToString();
                }
                if (ob.GetType().Name == "KHACH_HANG")
                {
                    KHACH_HANG _e = (KHACH_HANG)cb.SelectedItem;
                    txt.Text = _e.ID.ToString();
                }
                if (ob.GetType().Name == "HANG_HOA")
                {
                    HANG_HOA _e = (HANG_HOA)cb.SelectedItem;
                    txt.Text = _e.ID.ToString();
                }
                txt.Select();
                txt.SelectAll();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
