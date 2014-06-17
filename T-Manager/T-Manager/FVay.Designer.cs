namespace T_Manager
{
    partial class FVay
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNGUONVAY = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTONGTIEN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLAISUAT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxKHO = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "VAY TIỀN TỪ NGUỒN NGOÀI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(278, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NGUỒN VAY";
            // 
            // comboBoxNGUONVAY
            // 
            this.comboBoxNGUONVAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNGUONVAY.FormattingEnabled = true;
            this.comboBoxNGUONVAY.Location = new System.Drawing.Point(380, 59);
            this.comboBoxNGUONVAY.Name = "comboBoxNGUONVAY";
            this.comboBoxNGUONVAY.Size = new System.Drawing.Size(173, 21);
            this.comboBoxNGUONVAY.TabIndex = 0;
            this.comboBoxNGUONVAY.SelectedIndexChanged += new System.EventHandler(this.comboBoxNGUONVAY_SelectedIndexChanged);
            this.comboBoxNGUONVAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "TỔNG TIỀN";
            // 
            // textBoxTONGTIEN
            // 
            this.textBoxTONGTIEN.Location = new System.Drawing.Point(494, 136);
            this.textBoxTONGTIEN.Name = "textBoxTONGTIEN";
            this.textBoxTONGTIEN.Size = new System.Drawing.Size(173, 20);
            this.textBoxTONGTIEN.TabIndex = 5;
            this.textBoxTONGTIEN.TextChanged += new System.EventHandler(this.textBoxTONGTIEN_TextChanged);
            this.textBoxTONGTIEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTONGTIEN_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "LÃI SUẤT";
            // 
            // textBoxLAISUAT
            // 
            this.textBoxLAISUAT.Location = new System.Drawing.Point(494, 96);
            this.textBoxLAISUAT.Name = "textBoxLAISUAT";
            this.textBoxLAISUAT.Size = new System.Drawing.Size(173, 20);
            this.textBoxLAISUAT.TabIndex = 3;
            this.textBoxLAISUAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "NHẬP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "LỊCH SỬ VAY";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(782, 246);
            this.dataGridView1.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(207, 137);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "NGÀY VAY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(676, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "%";
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(207, 100);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(173, 21);
            this.comboBoxKHO.TabIndex = 1;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            this.comboBoxKHO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxNGUONVAY_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(105, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "KHO";
            // 
            // FVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 473);
            this.Controls.Add(this.comboBoxKHO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxLAISUAT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTONGTIEN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxNGUONVAY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FVay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VAY";
            this.Load += new System.EventHandler(this.FVay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNGUONVAY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTONGTIEN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLAISUAT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label9;
    }
}