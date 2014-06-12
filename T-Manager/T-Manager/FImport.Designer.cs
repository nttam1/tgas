namespace T_Manager
{
    partial class FImport
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFILE = new System.Windows.Forms.Button();
            this.buttonIMPORT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(127, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "FILE DỮ LIÊU";
            // 
            // buttonFILE
            // 
            this.buttonFILE.Location = new System.Drawing.Point(483, 24);
            this.buttonFILE.Name = "buttonFILE";
            this.buttonFILE.Size = new System.Drawing.Size(75, 23);
            this.buttonFILE.TabIndex = 2;
            this.buttonFILE.Text = "CHỌN";
            this.buttonFILE.UseVisualStyleBackColor = true;
            this.buttonFILE.Click += new System.EventHandler(this.buttonFILE_Click);
            // 
            // buttonIMPORT
            // 
            this.buttonIMPORT.Location = new System.Drawing.Point(243, 78);
            this.buttonIMPORT.Name = "buttonIMPORT";
            this.buttonIMPORT.Size = new System.Drawing.Size(75, 23);
            this.buttonIMPORT.TabIndex = 3;
            this.buttonIMPORT.Text = "IMPORT";
            this.buttonIMPORT.UseVisualStyleBackColor = true;
            this.buttonIMPORT.Click += new System.EventHandler(this.buttonIMPORT_Click);
            // 
            // FImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 113);
            this.Controls.Add(this.buttonIMPORT);
            this.Controls.Add(this.buttonFILE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHẬP DỮ LIỆU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFILE;
        private System.Windows.Forms.Button buttonIMPORT;
    }
}