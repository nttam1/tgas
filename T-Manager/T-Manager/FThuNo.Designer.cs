namespace T_Manager
{
    partial class FThuNo
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
            this.buttonADD = new System.Windows.Forms.Button();
            this.textBoxTIENLAI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTIENGOC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxKHACHHANG = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxKHO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTHUNO = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTHUNO)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "THU NỢ KHÁCH HÀNG";
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(608, 152);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 23);
            this.buttonADD.TabIndex = 17;
            this.buttonADD.Text = "NHẬP";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // textBoxTIENLAI
            // 
            this.textBoxTIENLAI.Location = new System.Drawing.Point(436, 155);
            this.textBoxTIENLAI.Name = "textBoxTIENLAI";
            this.textBoxTIENLAI.Size = new System.Drawing.Size(146, 20);
            this.textBoxTIENLAI.TabIndex = 16;
            this.textBoxTIENLAI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTIENLAI_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(433, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "TIỀN LÃI";
            // 
            // textBoxTIENGOC
            // 
            this.textBoxTIENGOC.Location = new System.Drawing.Point(241, 155);
            this.textBoxTIENGOC.Name = "textBoxTIENGOC";
            this.textBoxTIENGOC.Size = new System.Drawing.Size(166, 20);
            this.textBoxTIENGOC.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(238, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "TIỀN GỐC";
            // 
            // comboBoxKHACHHANG
            // 
            this.comboBoxKHACHHANG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHACHHANG.FormattingEnabled = true;
            this.comboBoxKHACHHANG.Location = new System.Drawing.Point(12, 156);
            this.comboBoxKHACHHANG.Name = "comboBoxKHACHHANG";
            this.comboBoxKHACHHANG.Size = new System.Drawing.Size(198, 21);
            this.comboBoxKHACHHANG.TabIndex = 12;
            this.comboBoxKHACHHANG.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHACHHANG_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(9, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "KHÁCH HÀNG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(236, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "KHO";
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(333, 71);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(144, 37);
            this.comboBoxKHO.TabIndex = 9;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "NHỮNG LẦN THU NỢ KHÁC CỦA KHÁCH HÀNG NÀY";
            // 
            // dataGridViewTHUNO
            // 
            this.dataGridViewTHUNO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTHUNO.Location = new System.Drawing.Point(5, 208);
            this.dataGridViewTHUNO.Name = "dataGridViewTHUNO";
            this.dataGridViewTHUNO.Size = new System.Drawing.Size(709, 219);
            this.dataGridViewTHUNO.TabIndex = 19;
            // 
            // FThuNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 439);
            this.Controls.Add(this.dataGridViewTHUNO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.textBoxTIENLAI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTIENGOC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxKHACHHANG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxKHO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FThuNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THU NỢ KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.FThuNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTHUNO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.TextBox textBoxTIENLAI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTIENGOC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxKHACHHANG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewTHUNO;
    }
}