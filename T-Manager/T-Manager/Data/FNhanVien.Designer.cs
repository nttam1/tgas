namespace T_Manager
{
    partial class FNhanVien
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
            this.listBoxNHANVIEN = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNHANVIEN = new System.Windows.Forms.TextBox();
            this.buttonADD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(99, 62);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(276, 21);
            this.comboBoxKHO.TabIndex = 0;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "KHO";
            // 
            // listBoxNHANVIEN
            // 
            this.listBoxNHANVIEN.FormattingEnabled = true;
            this.listBoxNHANVIEN.Location = new System.Drawing.Point(36, 95);
            this.listBoxNHANVIEN.Name = "listBoxNHANVIEN";
            this.listBoxNHANVIEN.Size = new System.Drawing.Size(205, 251);
            this.listBoxNHANVIEN.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // textBoxNHANVIEN
            // 
            this.textBoxNHANVIEN.Location = new System.Drawing.Point(258, 132);
            this.textBoxNHANVIEN.Name = "textBoxNHANVIEN";
            this.textBoxNHANVIEN.Size = new System.Drawing.Size(200, 20);
            this.textBoxNHANVIEN.TabIndex = 4;
            this.textBoxNHANVIEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNHANVIEN_KeyPress);
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(383, 158);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 23);
            this.buttonADD.TabIndex = 5;
            this.buttonADD.Text = "THÊM";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "TÊN NHÂN VIÊN";
            // 
            // FNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 358);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.textBoxNHANVIEN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxNHANVIEN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxKHO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THÊM MỚI NHÂN VIÊN";
            this.Load += new System.EventHandler(this.FNhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxNHANVIEN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNHANVIEN;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Label label3;
    }
}