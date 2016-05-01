namespace T_Manager
{
    partial class FReportTon
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxHANGHOA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxKHO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerNGAY = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonVIEW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "HÀNG HÓA";
            // 
            // comboBoxHANGHOA
            // 
            this.comboBoxHANGHOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHANGHOA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHANGHOA.FormattingEnabled = true;
            this.comboBoxHANGHOA.Location = new System.Drawing.Point(465, 38);
            this.comboBoxHANGHOA.Name = "comboBoxHANGHOA";
            this.comboBoxHANGHOA.Size = new System.Drawing.Size(192, 28);
            this.comboBoxHANGHOA.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "KHO";
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(63, 38);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(251, 28);
            this.comboBoxKHO.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(691, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 101;
            this.label4.Text = "NGÀY";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dateTimePickerNGAY
            // 
            this.dateTimePickerNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNGAY.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNGAY.Location = new System.Drawing.Point(777, 36);
            this.dateTimePickerNGAY.Name = "dateTimePickerNGAY";
            this.dateTimePickerNGAY.Size = new System.Drawing.Size(133, 26);
            this.dateTimePickerNGAY.TabIndex = 102;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(892, 322);
            this.dataGridView1.TabIndex = 103;
            // 
            // buttonVIEW
            // 
            this.buttonVIEW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVIEW.Location = new System.Drawing.Point(420, 93);
            this.buttonVIEW.Name = "buttonVIEW";
            this.buttonVIEW.Size = new System.Drawing.Size(118, 34);
            this.buttonVIEW.TabIndex = 104;
            this.buttonVIEW.Text = "XEM";
            this.buttonVIEW.UseVisualStyleBackColor = true;
            // 
            // FReportTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 467);
            this.Controls.Add(this.buttonVIEW);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerNGAY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxHANGHOA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxKHO);
            this.Name = "FReportTon";
            this.Text = "CHI TIẾT TỒN";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxHANGHOA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerNGAY;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonVIEW;
    }
}