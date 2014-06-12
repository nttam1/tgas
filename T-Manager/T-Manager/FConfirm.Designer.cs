namespace T_Manager
{
    partial class FConfirm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCONFIRM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 0;
            // 
            // buttonCONFIRM
            // 
            this.buttonCONFIRM.Location = new System.Drawing.Point(362, 45);
            this.buttonCONFIRM.Name = "buttonCONFIRM";
            this.buttonCONFIRM.Size = new System.Drawing.Size(75, 23);
            this.buttonCONFIRM.TabIndex = 1;
            this.buttonCONFIRM.Text = "XÁC NHẬN";
            this.buttonCONFIRM.UseVisualStyleBackColor = true;
            this.buttonCONFIRM.Click += new System.EventHandler(this.buttonCONFIRM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NGÀY THÁNG CỦA HỆ THỐNG ĐÃ BỊ CHỈNH SỬA. VUI LÒNG NHẬP MẬT KHẨU ĐỂ XÁC NHẬN";
            // 
            // FConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 92);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCONFIRM);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XÁC NHẬN NGÀY THÁNG";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FConfirm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCONFIRM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}