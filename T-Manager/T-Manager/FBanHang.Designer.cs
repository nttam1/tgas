namespace T_Manager
{
    partial class FBanHang
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
            this.comboBoxKHO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHANGHOA = new System.Windows.Forms.ComboBox();
            this.textBoxSOLUONG = new System.Windows.Forms.TextBox();
            this.textBoxDONGIABAN = new System.Windows.Forms.TextBox();
            this.buttonADD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labeLUNIT = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxKHO = new System.Windows.Forms.TextBox();
            this.textBoxHANGHOA = new System.Windows.Forms.TextBox();
            this.textBoxDONGIA = new System.Windows.Forms.TextBox();
            this.textBoxSLTON = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(260, 12);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(251, 28);
            this.comboBoxKHO.TabIndex = 0;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "KHO";
            // 
            // comboBoxHANGHOA
            // 
            this.comboBoxHANGHOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHANGHOA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHANGHOA.FormattingEnabled = true;
            this.comboBoxHANGHOA.Location = new System.Drawing.Point(138, 54);
            this.comboBoxHANGHOA.Name = "comboBoxHANGHOA";
            this.comboBoxHANGHOA.Size = new System.Drawing.Size(192, 28);
            this.comboBoxHANGHOA.TabIndex = 1;
            this.comboBoxHANGHOA.SelectedIndexChanged += new System.EventHandler(this.comboBoxHANGHOA_SelectedIndexChanged);
            // 
            // textBoxSOLUONG
            // 
            this.textBoxSOLUONG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSOLUONG.Location = new System.Drawing.Point(138, 128);
            this.textBoxSOLUONG.Name = "textBoxSOLUONG";
            this.textBoxSOLUONG.Size = new System.Drawing.Size(192, 26);
            this.textBoxSOLUONG.TabIndex = 3;
            this.textBoxSOLUONG.Text = "0";
            this.textBoxSOLUONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSOLUONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSOLUONG_KeyPress);
            // 
            // textBoxDONGIABAN
            // 
            this.textBoxDONGIABAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDONGIABAN.Location = new System.Drawing.Point(138, 94);
            this.textBoxDONGIABAN.Name = "textBoxDONGIABAN";
            this.textBoxDONGIABAN.Size = new System.Drawing.Size(192, 26);
            this.textBoxDONGIABAN.TabIndex = 2;
            this.textBoxDONGIABAN.Text = "0";
            this.textBoxDONGIABAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDONGIABAN.TextChanged += new System.EventHandler(this.textBoxDONGIABAN_TextChanged);
            this.textBoxDONGIABAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDONGIABAN_KeyPress);
            // 
            // buttonADD
            // 
            this.buttonADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonADD.Location = new System.Drawing.Point(645, 77);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(92, 60);
            this.buttonADD.TabIndex = 4;
            this.buttonADD.Text = "NHẬP";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "HÀNG HÓA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "SỐ LƯỢNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "ĐƠN GIÁ BÁN";
            // 
            // labeLUNIT
            // 
            this.labeLUNIT.AutoSize = true;
            this.labeLUNIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLUNIT.Location = new System.Drawing.Point(336, 131);
            this.labeLUNIT.Name = "labeLUNIT";
            this.labeLUNIT.Size = new System.Drawing.Size(43, 20);
            this.labeLUNIT.TabIndex = 9;
            this.labeLUNIT.Text = "uNIT";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(734, 238);
            this.dataGridView1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSLTON);
            this.groupBox1.Controls.Add(this.textBoxDONGIA);
            this.groupBox1.Controls.Add(this.textBoxHANGHOA);
            this.groupBox1.Controls.Add(this.textBoxKHO);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(385, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 114);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHI TIẾT TỒN HÀNG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "KHO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "HÀNG HÓA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ĐƠN GIÁ NHẬP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(402, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "SỐ LƯỢNG TRONG KHO";
            // 
            // textBoxKHO
            // 
            this.textBoxKHO.Location = new System.Drawing.Point(148, 20);
            this.textBoxKHO.Name = "textBoxKHO";
            this.textBoxKHO.ReadOnly = true;
            this.textBoxKHO.Size = new System.Drawing.Size(100, 20);
            this.textBoxKHO.TabIndex = 14;
            this.textBoxKHO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxHANGHOA
            // 
            this.textBoxHANGHOA.Location = new System.Drawing.Point(148, 42);
            this.textBoxHANGHOA.Name = "textBoxHANGHOA";
            this.textBoxHANGHOA.ReadOnly = true;
            this.textBoxHANGHOA.Size = new System.Drawing.Size(100, 20);
            this.textBoxHANGHOA.TabIndex = 15;
            this.textBoxHANGHOA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxDONGIA
            // 
            this.textBoxDONGIA.Location = new System.Drawing.Point(148, 66);
            this.textBoxDONGIA.Name = "textBoxDONGIA";
            this.textBoxDONGIA.ReadOnly = true;
            this.textBoxDONGIA.Size = new System.Drawing.Size(100, 20);
            this.textBoxDONGIA.TabIndex = 16;
            this.textBoxDONGIA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxSLTON
            // 
            this.textBoxSLTON.Location = new System.Drawing.Point(148, 89);
            this.textBoxSLTON.Name = "textBoxSLTON";
            this.textBoxSLTON.ReadOnly = true;
            this.textBoxSLTON.Size = new System.Drawing.Size(100, 20);
            this.textBoxSLTON.TabIndex = 17;
            this.textBoxSLTON.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 432);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labeLUNIT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.textBoxDONGIABAN);
            this.Controls.Add(this.textBoxSOLUONG);
            this.Controls.Add(this.comboBoxHANGHOA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxKHO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BÁN HÀNG";
            this.Load += new System.EventHandler(this.FBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHANGHOA;
        private System.Windows.Forms.TextBox textBoxSOLUONG;
        private System.Windows.Forms.TextBox textBoxDONGIABAN;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labeLUNIT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSLTON;
        private System.Windows.Forms.TextBox textBoxDONGIA;
        private System.Windows.Forms.TextBox textBoxHANGHOA;
        private System.Windows.Forms.TextBox textBoxKHO;
    }
}