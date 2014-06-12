namespace T_Manager
{
    partial class FChinhSua
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDULIEU = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxKHO = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonCHIKHAC = new System.Windows.Forms.RadioButton();
            this.radioButtonCHINOIBO = new System.Windows.Forms.RadioButton();
            this.radioButtonCHILUONG = new System.Windows.Forms.RadioButton();
            this.radioButtonCHOVAY = new System.Windows.Forms.RadioButton();
            this.radioButtonNHAPHANG = new System.Windows.Forms.RadioButton();
            this.buttonSAVE = new System.Windows.Forms.Button();
            this.radioButtonCHUYENTIEN = new System.Windows.Forms.RadioButton();
            this.radioButtonTRANONCC = new System.Windows.Forms.RadioButton();
            this.radioButtonTRANOVAY = new System.Windows.Forms.RadioButton();
            this.radioButtonVAY = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLOGIN = new System.Windows.Forms.Button();
            this.textBoxPASSWORD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerDATE = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDULIEU);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listBoxKHO);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DỮ LIỆU ";
            // 
            // comboBoxDULIEU
            // 
            this.comboBoxDULIEU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDULIEU.FormattingEnabled = true;
            this.comboBoxDULIEU.Location = new System.Drawing.Point(652, 26);
            this.comboBoxDULIEU.Name = "comboBoxDULIEU";
            this.comboBoxDULIEU.Size = new System.Drawing.Size(259, 21);
            this.comboBoxDULIEU.TabIndex = 6;
            this.comboBoxDULIEU.SelectedIndexChanged += new System.EventHandler(this.comboBoxDULIEU_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(648, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID Dữ Liệu";
            // 
            // listBoxKHO
            // 
            this.listBoxKHO.FormattingEnabled = true;
            this.listBoxKHO.Location = new System.Drawing.Point(651, 52);
            this.listBoxKHO.Name = "listBoxKHO";
            this.listBoxKHO.Size = new System.Drawing.Size(260, 134);
            this.listBoxKHO.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonCHIKHAC);
            this.groupBox3.Controls.Add(this.radioButtonCHINOIBO);
            this.groupBox3.Controls.Add(this.radioButtonCHILUONG);
            this.groupBox3.Controls.Add(this.radioButtonCHOVAY);
            this.groupBox3.Controls.Add(this.radioButtonNHAPHANG);
            this.groupBox3.Controls.Add(this.buttonSAVE);
            this.groupBox3.Controls.Add(this.radioButtonCHUYENTIEN);
            this.groupBox3.Controls.Add(this.radioButtonTRANONCC);
            this.groupBox3.Controls.Add(this.radioButtonTRANOVAY);
            this.groupBox3.Controls.Add(this.radioButtonVAY);
            this.groupBox3.Location = new System.Drawing.Point(309, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 177);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DỮ LIỆU CẦN SỬA";
            // 
            // radioButtonCHIKHAC
            // 
            this.radioButtonCHIKHAC.AutoSize = true;
            this.radioButtonCHIKHAC.Location = new System.Drawing.Point(195, 130);
            this.radioButtonCHIKHAC.Name = "radioButtonCHIKHAC";
            this.radioButtonCHIKHAC.Size = new System.Drawing.Size(75, 17);
            this.radioButtonCHIKHAC.TabIndex = 14;
            this.radioButtonCHIKHAC.TabStop = true;
            this.radioButtonCHIKHAC.Text = "CHI KHÁC";
            this.radioButtonCHIKHAC.UseVisualStyleBackColor = true;
            this.radioButtonCHIKHAC.CheckedChanged += new System.EventHandler(this.radioButtonCHIKHAC_CheckedChanged);
            // 
            // radioButtonCHINOIBO
            // 
            this.radioButtonCHINOIBO.AutoSize = true;
            this.radioButtonCHINOIBO.Location = new System.Drawing.Point(106, 130);
            this.radioButtonCHINOIBO.Name = "radioButtonCHINOIBO";
            this.radioButtonCHINOIBO.Size = new System.Drawing.Size(83, 17);
            this.radioButtonCHINOIBO.TabIndex = 13;
            this.radioButtonCHINOIBO.TabStop = true;
            this.radioButtonCHINOIBO.Text = "CHI NỘI BỘ";
            this.radioButtonCHINOIBO.UseVisualStyleBackColor = true;
            this.radioButtonCHINOIBO.CheckedChanged += new System.EventHandler(this.radioButtonCHINOIBO_CheckedChanged);
            // 
            // radioButtonCHILUONG
            // 
            this.radioButtonCHILUONG.AutoSize = true;
            this.radioButtonCHILUONG.Location = new System.Drawing.Point(16, 130);
            this.radioButtonCHILUONG.Name = "radioButtonCHILUONG";
            this.radioButtonCHILUONG.Size = new System.Drawing.Size(84, 17);
            this.radioButtonCHILUONG.TabIndex = 12;
            this.radioButtonCHILUONG.TabStop = true;
            this.radioButtonCHILUONG.Text = "CHI LƯƠNG";
            this.radioButtonCHILUONG.UseVisualStyleBackColor = true;
            this.radioButtonCHILUONG.CheckedChanged += new System.EventHandler(this.radioButtonCHILUONG_CheckedChanged);
            // 
            // radioButtonCHOVAY
            // 
            this.radioButtonCHOVAY.AutoSize = true;
            this.radioButtonCHOVAY.Location = new System.Drawing.Point(16, 38);
            this.radioButtonCHOVAY.Name = "radioButtonCHOVAY";
            this.radioButtonCHOVAY.Size = new System.Drawing.Size(72, 17);
            this.radioButtonCHOVAY.TabIndex = 11;
            this.radioButtonCHOVAY.TabStop = true;
            this.radioButtonCHOVAY.Text = "CHO VAY";
            this.radioButtonCHOVAY.UseVisualStyleBackColor = true;
            this.radioButtonCHOVAY.CheckedChanged += new System.EventHandler(this.radioButtonCHOVAY_CheckedChanged);
            // 
            // radioButtonNHAPHANG
            // 
            this.radioButtonNHAPHANG.AutoSize = true;
            this.radioButtonNHAPHANG.Location = new System.Drawing.Point(16, 61);
            this.radioButtonNHAPHANG.Name = "radioButtonNHAPHANG";
            this.radioButtonNHAPHANG.Size = new System.Drawing.Size(89, 17);
            this.radioButtonNHAPHANG.TabIndex = 10;
            this.radioButtonNHAPHANG.TabStop = true;
            this.radioButtonNHAPHANG.Text = "NHẬP HÀNG";
            this.radioButtonNHAPHANG.UseVisualStyleBackColor = true;
            this.radioButtonNHAPHANG.CheckedChanged += new System.EventHandler(this.radioButtonNHAPHANG_CheckedChanged);
            // 
            // buttonSAVE
            // 
            this.buttonSAVE.Location = new System.Drawing.Point(255, 148);
            this.buttonSAVE.Name = "buttonSAVE";
            this.buttonSAVE.Size = new System.Drawing.Size(75, 23);
            this.buttonSAVE.TabIndex = 9;
            this.buttonSAVE.Text = "LƯU";
            this.buttonSAVE.UseVisualStyleBackColor = true;
            this.buttonSAVE.Click += new System.EventHandler(this.buttonSAVE_Click);
            // 
            // radioButtonCHUYENTIEN
            // 
            this.radioButtonCHUYENTIEN.AutoSize = true;
            this.radioButtonCHUYENTIEN.Location = new System.Drawing.Point(16, 84);
            this.radioButtonCHUYENTIEN.Name = "radioButtonCHUYENTIEN";
            this.radioButtonCHUYENTIEN.Size = new System.Drawing.Size(184, 17);
            this.radioButtonCHUYENTIEN.TabIndex = 8;
            this.radioButtonCHUYENTIEN.TabStop = true;
            this.radioButtonCHUYENTIEN.Text = "CHUYỂN TIỀN VÀO TÀI KHOẢN";
            this.radioButtonCHUYENTIEN.UseVisualStyleBackColor = true;
            this.radioButtonCHUYENTIEN.CheckedChanged += new System.EventHandler(this.radioButtonCHUYENTIEN_CheckedChanged);
            // 
            // radioButtonTRANONCC
            // 
            this.radioButtonTRANONCC.AutoSize = true;
            this.radioButtonTRANONCC.Location = new System.Drawing.Point(16, 107);
            this.radioButtonTRANONCC.Name = "radioButtonTRANONCC";
            this.radioButtonTRANONCC.Size = new System.Drawing.Size(150, 17);
            this.radioButtonTRANONCC.TabIndex = 6;
            this.radioButtonTRANONCC.TabStop = true;
            this.radioButtonTRANONCC.Text = "TRẢ NỢ NHÀ CUNG CẤP";
            this.radioButtonTRANONCC.UseVisualStyleBackColor = true;
            this.radioButtonTRANONCC.CheckedChanged += new System.EventHandler(this.radioButtonTRANONCC_CheckedChanged);
            // 
            // radioButtonTRANOVAY
            // 
            this.radioButtonTRANOVAY.AutoSize = true;
            this.radioButtonTRANOVAY.Location = new System.Drawing.Point(140, 17);
            this.radioButtonTRANOVAY.Name = "radioButtonTRANOVAY";
            this.radioButtonTRANOVAY.Size = new System.Drawing.Size(90, 17);
            this.radioButtonTRANOVAY.TabIndex = 3;
            this.radioButtonTRANOVAY.TabStop = true;
            this.radioButtonTRANOVAY.Text = "TRẢ NỢ VAY";
            this.radioButtonTRANOVAY.UseVisualStyleBackColor = true;
            this.radioButtonTRANOVAY.CheckedChanged += new System.EventHandler(this.radioButtonTRANOVAY_CheckedChanged);
            // 
            // radioButtonVAY
            // 
            this.radioButtonVAY.AutoSize = true;
            this.radioButtonVAY.Checked = true;
            this.radioButtonVAY.Location = new System.Drawing.Point(16, 19);
            this.radioButtonVAY.Name = "radioButtonVAY";
            this.radioButtonVAY.Size = new System.Drawing.Size(46, 17);
            this.radioButtonVAY.TabIndex = 2;
            this.radioButtonVAY.TabStop = true;
            this.radioButtonVAY.Text = "VAY";
            this.radioButtonVAY.UseVisualStyleBackColor = true;
            this.radioButtonVAY.CheckedChanged += new System.EventHandler(this.radioButtonVAY_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonLOGIN);
            this.groupBox2.Controls.Add(this.textBoxPASSWORD);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePickerDATE);
            this.groupBox2.Location = new System.Drawing.Point(12, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 137);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHỌN NGÀY NHẬP";
            // 
            // buttonLOGIN
            // 
            this.buttonLOGIN.Location = new System.Drawing.Point(6, 101);
            this.buttonLOGIN.Name = "buttonLOGIN";
            this.buttonLOGIN.Size = new System.Drawing.Size(268, 23);
            this.buttonLOGIN.TabIndex = 4;
            this.buttonLOGIN.Text = "XÁC NHẬN";
            this.buttonLOGIN.UseVisualStyleBackColor = true;
            this.buttonLOGIN.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPASSWORD
            // 
            this.textBoxPASSWORD.Location = new System.Drawing.Point(95, 69);
            this.textBoxPASSWORD.Name = "textBoxPASSWORD";
            this.textBoxPASSWORD.PasswordChar = '*';
            this.textBoxPASSWORD.Size = new System.Drawing.Size(179, 20);
            this.textBoxPASSWORD.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MẬT KHẨU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NGÀY";
            // 
            // dateTimePickerDATE
            // 
            this.dateTimePickerDATE.Enabled = false;
            this.dateTimePickerDATE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDATE.Location = new System.Drawing.Point(95, 28);
            this.dateTimePickerDATE.Name = "dateTimePickerDATE";
            this.dateTimePickerDATE.Size = new System.Drawing.Size(179, 20);
            this.dateTimePickerDATE.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1075, 166);
            this.dataGridView1.TabIndex = 1;
            // 
            // FChinhSua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 360);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FChinhSua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHỈNH SỬA DỮ LIỆU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FChinhSua_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDATE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPASSWORD;
        private System.Windows.Forms.Button buttonLOGIN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonTRANOVAY;
        private System.Windows.Forms.RadioButton radioButtonVAY;
        private System.Windows.Forms.RadioButton radioButtonTRANONCC;
        private System.Windows.Forms.RadioButton radioButtonCHUYENTIEN;
        private System.Windows.Forms.Button buttonSAVE;
        private System.Windows.Forms.ListBox listBoxKHO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxDULIEU;
        private System.Windows.Forms.RadioButton radioButtonCHOVAY;
        private System.Windows.Forms.RadioButton radioButtonNHAPHANG;
        private System.Windows.Forms.RadioButton radioButtonCHIKHAC;
        private System.Windows.Forms.RadioButton radioButtonCHINOIBO;
        private System.Windows.Forms.RadioButton radioButtonCHILUONG;
    }
}