namespace T_Manager
{
    partial class FInit
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
            this.textBoxPASS = new System.Windows.Forms.TextBox();
            this.textBoxREPASS = new System.Windows.Forms.TextBox();
            this.buttonPASS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPASS
            // 
            this.textBoxPASS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPASS.Location = new System.Drawing.Point(246, 29);
            this.textBoxPASS.Name = "textBoxPASS";
            this.textBoxPASS.PasswordChar = '*';
            this.textBoxPASS.Size = new System.Drawing.Size(169, 26);
            this.textBoxPASS.TabIndex = 0;
            // 
            // textBoxREPASS
            // 
            this.textBoxREPASS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxREPASS.Location = new System.Drawing.Point(246, 70);
            this.textBoxREPASS.Name = "textBoxREPASS";
            this.textBoxREPASS.PasswordChar = '*';
            this.textBoxREPASS.Size = new System.Drawing.Size(169, 26);
            this.textBoxREPASS.TabIndex = 1;
            // 
            // buttonPASS
            // 
            this.buttonPASS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPASS.Location = new System.Drawing.Point(212, 118);
            this.buttonPASS.Name = "buttonPASS";
            this.buttonPASS.Size = new System.Drawing.Size(149, 31);
            this.buttonPASS.TabIndex = 2;
            this.buttonPASS.Text = "NHẬP";
            this.buttonPASS.UseVisualStyleBackColor = true;
            this.buttonPASS.Click += new System.EventHandler(this.buttonPASS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ĐÁNH LẠI MẬT KHẨU";
            // 
            // FInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPASS);
            this.Controls.Add(this.textBoxREPASS);
            this.Controls.Add(this.textBoxPASS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÀI ĐẶT HỆ THỐNG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPASS;
        private System.Windows.Forms.TextBox textBoxREPASS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPASS;
    }
}