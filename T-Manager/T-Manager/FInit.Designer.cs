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
            this.SuspendLayout();
            // 
            // textBoxPASS
            // 
            this.textBoxPASS.Location = new System.Drawing.Point(83, 28);
            this.textBoxPASS.Name = "textBoxPASS";
            this.textBoxPASS.PasswordChar = '*';
            this.textBoxPASS.Size = new System.Drawing.Size(100, 20);
            this.textBoxPASS.TabIndex = 0;
            // 
            // textBoxREPASS
            // 
            this.textBoxREPASS.Location = new System.Drawing.Point(83, 68);
            this.textBoxREPASS.Name = "textBoxREPASS";
            this.textBoxREPASS.PasswordChar = '*';
            this.textBoxREPASS.Size = new System.Drawing.Size(100, 20);
            this.textBoxREPASS.TabIndex = 1;
            // 
            // buttonPASS
            // 
            this.buttonPASS.Location = new System.Drawing.Point(242, 24);
            this.buttonPASS.Name = "buttonPASS";
            this.buttonPASS.Size = new System.Drawing.Size(75, 23);
            this.buttonPASS.TabIndex = 2;
            this.buttonPASS.Text = "NHẬP";
            this.buttonPASS.UseVisualStyleBackColor = true;
            this.buttonPASS.Click += new System.EventHandler(this.buttonPASS_Click);
            // 
            // FInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 338);
            this.Controls.Add(this.buttonPASS);
            this.Controls.Add(this.textBoxREPASS);
            this.Controls.Add(this.textBoxPASS);
            this.Name = "FInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CÀI ĐẶT HỆ THỐNG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPASS;
        private System.Windows.Forms.TextBox textBoxREPASS;
        private System.Windows.Forms.Button buttonPASS;
    }
}