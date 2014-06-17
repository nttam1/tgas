namespace T_Manager
{
    partial class FTraNoVay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxTIENLAI = new System.Windows.Forms.TextBox();
            this.textBoxTONGTIEN = new System.Windows.Forms.TextBox();
            this.comboBoxNGUONVAY = new System.Windows.Forms.ComboBox();
            this.comboBoxKHO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(167, 143);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(171, 22);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(677, 228);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "DANH SÁCH NỢ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(290, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "NHẬP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxTIENLAI
            // 
            this.textBoxTIENLAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTIENLAI.Location = new System.Drawing.Point(509, 143);
            this.textBoxTIENLAI.Name = "textBoxTIENLAI";
            this.textBoxTIENLAI.Size = new System.Drawing.Size(140, 22);
            this.textBoxTIENLAI.TabIndex = 4;
            this.textBoxTIENLAI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTIENLAI_KeyPress);
            // 
            // textBoxTONGTIEN
            // 
            this.textBoxTONGTIEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTONGTIEN.Location = new System.Drawing.Point(509, 111);
            this.textBoxTONGTIEN.Name = "textBoxTONGTIEN";
            this.textBoxTONGTIEN.Size = new System.Drawing.Size(140, 22);
            this.textBoxTONGTIEN.TabIndex = 3;
            this.textBoxTONGTIEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // comboBoxNGUONVAY
            // 
            this.comboBoxNGUONVAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNGUONVAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNGUONVAY.FormattingEnabled = true;
            this.comboBoxNGUONVAY.Location = new System.Drawing.Point(346, 65);
            this.comboBoxNGUONVAY.Name = "comboBoxNGUONVAY";
            this.comboBoxNGUONVAY.Size = new System.Drawing.Size(171, 24);
            this.comboBoxNGUONVAY.TabIndex = 0;
            this.comboBoxNGUONVAY.SelectedIndexChanged += new System.EventHandler(this.comboBoxNGUONVAY_SelectedIndexChanged);
            this.comboBoxNGUONVAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(168, 105);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(171, 24);
            this.comboBoxKHO.TabIndex = 1;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            this.comboBoxKHO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "NGUỒN XUẤT TIỀN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "NGÀY TRẢ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "TIỀN LÃI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "TIỀN GỐC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "NGUỒN VAY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 37);
            this.label1.TabIndex = 31;
            this.label1.Text = "TRẢ NỢ VAY";
            // 
            // FTraNoVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxKHO);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTIENLAI);
            this.Controls.Add(this.textBoxTONGTIEN);
            this.Controls.Add(this.comboBoxNGUONVAY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTraNoVay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TRẢ NỢ VAY";
            this.Load += new System.EventHandler(this.FTraNoVay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxTIENLAI;
        private System.Windows.Forms.TextBox textBoxTONGTIEN;
        private System.Windows.Forms.ComboBox comboBoxNGUONVAY;
        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}