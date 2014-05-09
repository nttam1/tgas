using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_Manager.Data
{
    public partial class FHangHoa : Form
    {
        public FHangHoa()
        {
            InitializeComponent();
        }

        private BindingSource bs = new BindingSource();
        private void FHangHoa_Load(object sender, EventArgs e)
        {
            bs.DataSource = DataInstance.Instance().DBContext().HANG_HOA;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "TÊN";
            dataGridView1.Columns[2].HeaderText = "ĐƠN VỊ TÍNH";
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSO.Text == "" || textBoxTEN.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên hàng hóa hoặc đơn vị tính");
                }
                bs.Add(new HANG_HOA()
                {
                    NAME = textBoxTEN.Text,
                    UNIT = textBoxSO.Text
                });
                bs.EndEdit();
                bs.ResetBindings(false);
                DataInstance.Instance().DBContext().SaveChanges();
                textBoxSO.Text = "";
                textBoxTEN.Text = "";
                textBoxSO.Select();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
