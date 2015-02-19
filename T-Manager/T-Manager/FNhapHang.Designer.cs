namespace T_Manager
{
    partial class FNhapHang
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
            this.comboBoxKho = new System.Windows.Forms.ComboBox();
            this.comboBoxNCC = new System.Windows.Forms.ComboBox();
            this.textBoxSOLUONG = new System.Windows.Forms.TextBox();
            this.textBoxDONGIA = new System.Windows.Forms.TextBox();
            this.dateTimePickerNGAYNHAP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonADD = new System.Windows.Forms.Button();
            this.buttonCLEAR = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxHANGHOA = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelDONVITINH = new System.Windows.Forms.Label();
            this.textBoxMAKHO = new System.Windows.Forms.TextBox();
            this.textBoxNCC = new System.Windows.Forms.TextBox();
            this.textBoxHANGHOA = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxKho
            // 
            this.comboBoxKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKho.FormattingEnabled = true;
            this.comboBoxKho.Location = new System.Drawing.Point(207, 110);
            this.comboBoxKho.Name = "comboBoxKho";
            this.comboBoxKho.Size = new System.Drawing.Size(162, 21);
            this.comboBoxKho.TabIndex = 30;
            this.comboBoxKho.SelectedIndexChanged += new System.EventHandler(this.comboBoxKho_SelectedIndexChanged);
            this.comboBoxKho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKho_KeyPress);
            // 
            // comboBoxNCC
            // 
            this.comboBoxNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNCC.FormattingEnabled = true;
            this.comboBoxNCC.Location = new System.Drawing.Point(207, 155);
            this.comboBoxNCC.Name = "comboBoxNCC";
            this.comboBoxNCC.Size = new System.Drawing.Size(162, 21);
            this.comboBoxNCC.TabIndex = 31;
            this.comboBoxNCC.SelectedIndexChanged += new System.EventHandler(this.comboBoxNCC_SelectedIndexChanged);
            this.comboBoxNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKho_KeyPress);
            // 
            // textBoxSOLUONG
            // 
            this.textBoxSOLUONG.Location = new System.Drawing.Point(501, 200);
            this.textBoxSOLUONG.Name = "textBoxSOLUONG";
            this.textBoxSOLUONG.Size = new System.Drawing.Size(155, 20);
            this.textBoxSOLUONG.TabIndex = 5;
            this.textBoxSOLUONG.Text = "0";
            this.textBoxSOLUONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSOLUONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSOLUONG_KeyPress);
            // 
            // textBoxDONGIA
            // 
            this.textBoxDONGIA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDONGIA.Location = new System.Drawing.Point(501, 156);
            this.textBoxDONGIA.Name = "textBoxDONGIA";
            this.textBoxDONGIA.Size = new System.Drawing.Size(155, 20);
            this.textBoxDONGIA.TabIndex = 4;
            this.textBoxDONGIA.Text = "0";
            this.textBoxDONGIA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDONGIA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKho_KeyPress);
            // 
            // dateTimePickerNGAYNHAP
            // 
            this.dateTimePickerNGAYNHAP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNGAYNHAP.Location = new System.Drawing.Point(501, 106);
            this.dateTimePickerNGAYNHAP.Name = "dateTimePickerNGAYNHAP";
            this.dateTimePickerNGAYNHAP.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerNGAYNHAP.TabIndex = 3;
            this.dateTimePickerNGAYNHAP.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePickerNGAYNHAP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKho_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "KHO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "NHÀ CUNG CẤP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "SỐ LƯỢNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ĐƠN GIÁ MUA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "NGÀY NHẬP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(106, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(550, 39);
            this.label7.TabIndex = 12;
            this.label7.Text = "NHẬP HÀNG TỪ NHÀ CUNG CẤP";
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(271, 250);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 23);
            this.buttonADD.TabIndex = 7;
            this.buttonADD.Text = "NHẬP";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // buttonCLEAR
            // 
            this.buttonCLEAR.Location = new System.Drawing.Point(398, 250);
            this.buttonCLEAR.Name = "buttonCLEAR";
            this.buttonCLEAR.Size = new System.Drawing.Size(75, 23);
            this.buttonCLEAR.TabIndex = 8;
            this.buttonCLEAR.Text = "XÓA";
            this.buttonCLEAR.UseVisualStyleBackColor = true;
            this.buttonCLEAR.Click += new System.EventHandler(this.buttonCLEAR_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "HÀNG HÓA";
            // 
            // comboBoxHANGHOA
            // 
            this.comboBoxHANGHOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHANGHOA.FormattingEnabled = true;
            this.comboBoxHANGHOA.Location = new System.Drawing.Point(207, 204);
            this.comboBoxHANGHOA.Name = "comboBoxHANGHOA";
            this.comboBoxHANGHOA.Size = new System.Drawing.Size(162, 21);
            this.comboBoxHANGHOA.TabIndex = 32;
            this.comboBoxHANGHOA.SelectedIndexChanged += new System.EventHandler(this.comboBoxHANGHOA_SelectedIndexChanged);
            this.comboBoxHANGHOA.SelectedValueChanged += new System.EventHandler(this.comboBoxHANGHOA_SelectedValueChanged);
            this.comboBoxHANGHOA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKho_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 312);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(741, 150);
            this.dataGridView1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(261, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "Chứng từ nhập trong ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(662, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "VND";
            // 
            // labelDONVITINH
            // 
            this.labelDONVITINH.AutoSize = true;
            this.labelDONVITINH.Location = new System.Drawing.Point(662, 203);
            this.labelDONVITINH.Name = "labelDONVITINH";
            this.labelDONVITINH.Size = new System.Drawing.Size(60, 13);
            this.labelDONVITINH.TabIndex = 20;
            this.labelDONVITINH.Text = "Đơn vị tính";
            // 
            // textBoxMAKHO
            // 
            this.textBoxMAKHO.Location = new System.Drawing.Point(163, 110);
            this.textBoxMAKHO.Name = "textBoxMAKHO";
            this.textBoxMAKHO.Size = new System.Drawing.Size(38, 20);
            this.textBoxMAKHO.TabIndex = 0;
            this.textBoxMAKHO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDONGIA_KeyPress);
            this.textBoxMAKHO.Leave += new System.EventHandler(this.textBoxMAKHO_Leave);
            // 
            // textBoxNCC
            // 
            this.textBoxNCC.Location = new System.Drawing.Point(163, 156);
            this.textBoxNCC.Name = "textBoxNCC";
            this.textBoxNCC.Size = new System.Drawing.Size(38, 20);
            this.textBoxNCC.TabIndex = 1;
            this.textBoxNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDONGIA_KeyPress);
            this.textBoxNCC.Leave += new System.EventHandler(this.textBoxNCC_Leave);
            // 
            // textBoxHANGHOA
            // 
            this.textBoxHANGHOA.Location = new System.Drawing.Point(163, 205);
            this.textBoxHANGHOA.Name = "textBoxHANGHOA";
            this.textBoxHANGHOA.Size = new System.Drawing.Size(38, 20);
            this.textBoxHANGHOA.TabIndex = 2;
            this.textBoxHANGHOA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDONGIA_KeyPress);
            this.textBoxHANGHOA.Leave += new System.EventHandler(this.textBoxHANGHOA_Leave);
            // 
            // FNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 474);
            this.Controls.Add(this.textBoxHANGHOA);
            this.Controls.Add(this.textBoxNCC);
            this.Controls.Add(this.textBoxMAKHO);
            this.Controls.Add(this.labelDONVITINH);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxHANGHOA);
            this.Controls.Add(this.buttonCLEAR);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerNGAYNHAP);
            this.Controls.Add(this.textBoxDONGIA);
            this.Controls.Add(this.textBoxSOLUONG);
            this.Controls.Add(this.comboBoxNCC);
            this.Controls.Add(this.comboBoxKho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FNhapHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NHẬP HÀNG";
            this.Load += new System.EventHandler(this.NhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKho;
        private System.Windows.Forms.ComboBox comboBoxNCC;
        private System.Windows.Forms.TextBox textBoxSOLUONG;
        private System.Windows.Forms.TextBox textBoxDONGIA;
        private System.Windows.Forms.DateTimePicker dateTimePickerNGAYNHAP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Button buttonCLEAR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxHANGHOA;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelDONVITINH;
        private System.Windows.Forms.TextBox textBoxMAKHO;
        private System.Windows.Forms.TextBox textBoxNCC;
        private System.Windows.Forms.TextBox textBoxHANGHOA;

    }
}