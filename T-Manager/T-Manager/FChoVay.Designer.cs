namespace T_Manager
{
    partial class FChoVay
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxKHACHHANG = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTONGTIEN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLAISUAT = new System.Windows.Forms.TextBox();
            this.buttonADD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerCHOVAY = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewCHOVAY = new System.Windows.Forms.DataGridView();
            this.textBoxMAKHO = new System.Windows.Forms.TextBox();
            this.textBoxKHACHHANG = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCHOVAY)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(392, 12);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(254, 37);
            this.comboBoxKHO.TabIndex = 20;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            this.comboBoxKHO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKHO_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "KHO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "KHÁCH HÀNG";
            // 
            // comboBoxKHACHHANG
            // 
            this.comboBoxKHACHHANG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHACHHANG.FormattingEnabled = true;
            this.comboBoxKHACHHANG.Location = new System.Drawing.Point(75, 105);
            this.comboBoxKHACHHANG.Name = "comboBoxKHACHHANG";
            this.comboBoxKHACHHANG.Size = new System.Drawing.Size(157, 21);
            this.comboBoxKHACHHANG.TabIndex = 1;
            this.comboBoxKHACHHANG.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHACHHANG_SelectedIndexChanged);
            this.comboBoxKHACHHANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKHO_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(518, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TỔNG TIỀN";
            // 
            // textBoxTONGTIEN
            // 
            this.textBoxTONGTIEN.Location = new System.Drawing.Point(521, 105);
            this.textBoxTONGTIEN.Name = "textBoxTONGTIEN";
            this.textBoxTONGTIEN.Size = new System.Drawing.Size(166, 20);
            this.textBoxTONGTIEN.TabIndex = 4;
            this.textBoxTONGTIEN.TextChanged += new System.EventHandler(this.textBoxTONGTIEN_TextChanged);
            this.textBoxTONGTIEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTONGTIEN_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(399, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "LÃI SUẤT";
            // 
            // textBoxLAISUAT
            // 
            this.textBoxLAISUAT.Location = new System.Drawing.Point(402, 105);
            this.textBoxLAISUAT.Name = "textBoxLAISUAT";
            this.textBoxLAISUAT.Size = new System.Drawing.Size(85, 20);
            this.textBoxLAISUAT.TabIndex = 3;
            this.textBoxLAISUAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKHO_KeyPress);
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(693, 78);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 48);
            this.buttonADD.TabIndex = 8;
            this.buttonADD.Text = "NHẬP";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(10, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "CHI TIẾT VAY TRONG NGÀY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(245, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "NGÀY CHO VAY";
            // 
            // dateTimePickerCHOVAY
            // 
            this.dateTimePickerCHOVAY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCHOVAY.Location = new System.Drawing.Point(257, 105);
            this.dateTimePickerCHOVAY.Name = "dateTimePickerCHOVAY";
            this.dateTimePickerCHOVAY.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerCHOVAY.TabIndex = 2;
            this.dateTimePickerCHOVAY.ValueChanged += new System.EventHandler(this.dateTimePickerCHOVAY_ValueChanged);
            this.dateTimePickerCHOVAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKHO_KeyPress);
            // 
            // dataGridViewCHOVAY
            // 
            this.dataGridViewCHOVAY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCHOVAY.Location = new System.Drawing.Point(15, 153);
            this.dataGridViewCHOVAY.Name = "dataGridViewCHOVAY";
            this.dataGridViewCHOVAY.Size = new System.Drawing.Size(768, 277);
            this.dataGridViewCHOVAY.TabIndex = 14;
            // 
            // textBoxMAKHO
            // 
            this.textBoxMAKHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMAKHO.Location = new System.Drawing.Point(320, 12);
            this.textBoxMAKHO.Name = "textBoxMAKHO";
            this.textBoxMAKHO.Size = new System.Drawing.Size(58, 35);
            this.textBoxMAKHO.TabIndex = 0;
            this.textBoxMAKHO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKHO_KeyPress);
            // 
            // textBoxKHACHHANG
            // 
            this.textBoxKHACHHANG.Location = new System.Drawing.Point(25, 105);
            this.textBoxKHACHHANG.Name = "textBoxKHACHHANG";
            this.textBoxKHACHHANG.Size = new System.Drawing.Size(38, 20);
            this.textBoxKHACHHANG.TabIndex = 1;
            this.textBoxKHACHHANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxKHO_KeyPress);
            // 
            // FChoVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 442);
            this.Controls.Add(this.textBoxKHACHHANG);
            this.Controls.Add(this.textBoxMAKHO);
            this.Controls.Add(this.dataGridViewCHOVAY);
            this.Controls.Add(this.dateTimePickerCHOVAY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.textBoxLAISUAT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTONGTIEN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxKHACHHANG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxKHO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FChoVay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHO VAY";
            this.Load += new System.EventHandler(this.FChoVay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCHOVAY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxKHACHHANG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTONGTIEN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLAISUAT;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerCHOVAY;
        private System.Windows.Forms.DataGridView dataGridViewCHOVAY;
        private System.Windows.Forms.TextBox textBoxMAKHO;
        private System.Windows.Forms.TextBox textBoxKHACHHANG;
    }
}