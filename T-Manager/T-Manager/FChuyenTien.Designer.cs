namespace T_Manager
{
    partial class FChuyenTien
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTONGTIEN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTIENTON = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxTAIKHOAN = new System.Windows.Forms.ListBox();
            this.buttonCHUYEN = new System.Windows.Forms.Button();
            this.dateTimePickerNGAY = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHUYỂN TIỀN TỪ KHO QUỸ VÀO TÀI KHOẢN NGÂN HÀNG";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePickerNGAY);
            this.groupBox1.Controls.Add(this.textBoxTONGTIEN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxTIENTON);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN KHO QUỸ";
            // 
            // textBoxTONGTIEN
            // 
            this.textBoxTONGTIEN.Location = new System.Drawing.Point(25, 122);
            this.textBoxTONGTIEN.Name = "textBoxTONGTIEN";
            this.textBoxTONGTIEN.Size = new System.Drawing.Size(232, 22);
            this.textBoxTONGTIEN.TabIndex = 3;
            this.textBoxTONGTIEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTONGTIEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTONGTIEN_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "SỐ TIỀN CHUYỂN:";
            // 
            // textBoxTIENTON
            // 
            this.textBoxTIENTON.Location = new System.Drawing.Point(25, 59);
            this.textBoxTIENTON.Name = "textBoxTIENTON";
            this.textBoxTIENTON.ReadOnly = true;
            this.textBoxTIENTON.Size = new System.Drawing.Size(232, 22);
            this.textBoxTIENTON.TabIndex = 1;
            this.textBoxTIENTON.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "TỔNG TIỀN:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxTAIKHOAN);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(281, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 241);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DANH SÁCH TÀI KHOẢN NGÂN HÀNG";
            // 
            // listBoxTAIKHOAN
            // 
            this.listBoxTAIKHOAN.FormattingEnabled = true;
            this.listBoxTAIKHOAN.ItemHeight = 16;
            this.listBoxTAIKHOAN.Location = new System.Drawing.Point(6, 19);
            this.listBoxTAIKHOAN.Name = "listBoxTAIKHOAN";
            this.listBoxTAIKHOAN.Size = new System.Drawing.Size(297, 212);
            this.listBoxTAIKHOAN.TabIndex = 0;
            // 
            // buttonCHUYEN
            // 
            this.buttonCHUYEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCHUYEN.Location = new System.Drawing.Point(622, 134);
            this.buttonCHUYEN.Name = "buttonCHUYEN";
            this.buttonCHUYEN.Size = new System.Drawing.Size(126, 108);
            this.buttonCHUYEN.TabIndex = 3;
            this.buttonCHUYEN.Text = "NHẬP";
            this.buttonCHUYEN.UseVisualStyleBackColor = true;
            this.buttonCHUYEN.Click += new System.EventHandler(this.buttonCHUYEN_Click);
            // 
            // dateTimePickerNGAY
            // 
            this.dateTimePickerNGAY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNGAY.Location = new System.Drawing.Point(25, 197);
            this.dateTimePickerNGAY.Name = "dateTimePickerNGAY";
            this.dateTimePickerNGAY.Size = new System.Drawing.Size(232, 22);
            this.dateTimePickerNGAY.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "NGÀY CHUYỂN";
            // 
            // FChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 314);
            this.Controls.Add(this.buttonCHUYEN);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FChuyenTien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHUYỂN TIỀN VÀO TÀI KHOẢN NGÂN HÀNG";
            this.Load += new System.EventHandler(this.FChuyenTien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxTAIKHOAN;
        private System.Windows.Forms.TextBox textBoxTIENTON;
        private System.Windows.Forms.TextBox textBoxTONGTIEN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCHUYEN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerNGAY;
    }
}