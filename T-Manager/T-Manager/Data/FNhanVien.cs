using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace T_Manager
{
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private tgasEntities dbContext = DataInstance.Instance().DBContext();

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            comboBoxKHO.DataSource = dbContext.KHOes.Where(u => u.TYPE == 0);
            comboBoxKHO.DisplayMember = "NAME";
            comboBoxKHO.ValueMember = "ID";
            this.comboBoxKHO_SelectedIndexChanged(sender, e);
        }

        private void comboBoxKHO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var makho = long.Parse(comboBoxKHO.SelectedValue.ToString());
                bs.DataSource = dbContext.NHAN_VIEN.Where(u => u.MAKHO == makho);
                listBoxNHANVIEN.DataSource = bs;
                listBoxNHANVIEN.DisplayMember = "NAME";
                listBoxNHANVIEN.ValueMember = "ID";
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (textBoxNHANVIEN.Text == "")
            {
                MessageBox.Show("Chưa nhập tên nhân viên");
                return;
            }
            var makho = Int32.Parse(comboBoxKHO.SelectedValue.ToString());
            bs.Add(new NHAN_VIEN() { NAME = textBoxNHANVIEN.Text, MAKHO = makho});
            bs.EndEdit();
            bs.ResetBindings(false);
            dbContext.SaveChanges(false);
            textBoxNHANVIEN.Text = "";
            textBoxNHANVIEN.Select();
        }

        private void textBoxNHANVIEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonADD_Click(sender, e);
            }
        }
    }
}
