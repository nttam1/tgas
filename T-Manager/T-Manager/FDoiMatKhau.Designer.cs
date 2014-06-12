namespace T_Manager
{
    partial class FDoiMatKhau
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
            this.textBoxOLDPASS = new System.Windows.Forms.TextBox();
            this.textBoxNEWPASS = new System.Windows.Forms.TextBox();
            this.textBoxRENEWPASS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCHANGE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxOLDPASS
            // 
            this.textBoxOLDPASS.Location = new System.Drawing.Point(200, 31);
            this.textBoxOLDPASS.Name = "textBoxOLDPASS";
            this.textBoxOLDPASS.PasswordChar = '*';
            this.textBoxOLDPASS.Size = new System.Drawing.Size(215, 20);
            this.textBoxOLDPASS.TabIndex = 0;
            // 
            // textBoxNEWPASS
            // 
            this.textBoxNEWPASS.Location = new System.Drawing.Point(200, 75);
            this.textBoxNEWPASS.Name = "textBoxNEWPASS";
            this.textBoxNEWPASS.PasswordChar = '*';
            this.textBoxNEWPASS.Size = new System.Drawing.Size(215, 20);
            this.textBoxNEWPASS.TabIndex = 1;
            // 
            // textBoxRENEWPASS
            // 
            this.textBoxRENEWPASS.Location = new System.Drawing.Point(200, 125);
            this.textBoxRENEWPASS.Name = "textBoxRENEWPASS";
            this.textBoxRENEWPASS.PasswordChar = '*';
            this.textBoxRENEWPASS.Size = new System.Drawing.Size(215, 20);
            this.textBoxRENEWPASS.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MẬT KHẨU CŨ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MẬT KHẨU MỚI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "NHẬP LẠI MẬT KHẨU MỚI";
            // 
            // buttonCHANGE
            // 
            this.buttonCHANGE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCHANGE.Location = new System.Drawing.Point(120, 173);
            this.buttonCHANGE.Name = "buttonCHANGE";
            this.buttonCHANGE.Size = new System.Drawing.Size(228, 23);
            this.buttonCHANGE.TabIndex = 6;
            this.buttonCHANGE.Text = "ĐỔI MẬT KHẨU";
            this.buttonCHANGE.UseVisualStyleBackColor = true;
            this.buttonCHANGE.Click += new System.EventHandler(this.buttonCHANGE_Click);
            // 
            // FDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 228);
            this.Controls.Add(this.buttonCHANGE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRENEWPASS);
            this.Controls.Add(this.textBoxNEWPASS);
            this.Controls.Add(this.textBoxOLDPASS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ĐỔI MẬT KHẨU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOLDPASS;
        private System.Windows.Forms.TextBox textBoxNEWPASS;
        private System.Windows.Forms.TextBox textBoxRENEWPASS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCHANGE;
    }
}