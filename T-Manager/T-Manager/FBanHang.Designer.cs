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
            this.labeldate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.comboBoxHANGHOA.Location = new System.Drawing.Point(16, 86);
            this.comboBoxHANGHOA.Name = "comboBoxHANGHOA";
            this.comboBoxHANGHOA.Size = new System.Drawing.Size(177, 28);
            this.comboBoxHANGHOA.TabIndex = 1;
            this.comboBoxHANGHOA.SelectedIndexChanged += new System.EventHandler(this.comboBoxHANGHOA_SelectedIndexChanged);
            // 
            // textBoxSOLUONG
            // 
            this.textBoxSOLUONG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSOLUONG.Location = new System.Drawing.Point(428, 88);
            this.textBoxSOLUONG.Name = "textBoxSOLUONG";
            this.textBoxSOLUONG.Size = new System.Drawing.Size(165, 26);
            this.textBoxSOLUONG.TabIndex = 3;
            this.textBoxSOLUONG.Text = "0";
            this.textBoxSOLUONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSOLUONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSOLUONG_KeyPress);
            // 
            // textBoxDONGIABAN
            // 
            this.textBoxDONGIABAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDONGIABAN.Location = new System.Drawing.Point(214, 88);
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
            this.buttonADD.Location = new System.Drawing.Point(654, 54);
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
            this.label3.Location = new System.Drawing.Point(424, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "SỐ LƯỢNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(211, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "ĐƠN GIÁ BÁN";
            // 
            // labeLUNIT
            // 
            this.labeLUNIT.AutoSize = true;
            this.labeLUNIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLUNIT.Location = new System.Drawing.Point(599, 94);
            this.labeLUNIT.Name = "labeLUNIT";
            this.labeLUNIT.Size = new System.Drawing.Size(43, 20);
            this.labeLUNIT.TabIndex = 9;
            this.labeLUNIT.Text = "uNIT";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(734, 278);
            this.dataGridView1.TabIndex = 10;
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldate.Location = new System.Drawing.Point(562, 126);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(31, 13);
            this.labeldate.TabIndex = 11;
            this.labeldate.Text = "uNIT";
            // 
            // FBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 432);
            this.Controls.Add(this.labeldate);
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
        private System.Windows.Forms.Label labeldate;
    }
}