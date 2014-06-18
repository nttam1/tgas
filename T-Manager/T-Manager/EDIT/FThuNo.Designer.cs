namespace T_Manager.EDIT
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.dateTimePickerNGAYXUAT = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSAVE = new System.Windows.Forms.Button();
            this.textBoxTIENLAI = new System.Windows.Forms.TextBox();
            this.textBoxTIENGOC = new System.Windows.Forms.TextBox();
            this.comboBoxKHACHHANG = new System.Windows.Forms.ComboBox();
            this.comboBoxKHO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerDATE = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(467, 98);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(68, 20);
            this.textBoxID.TabIndex = 18;
            this.textBoxID.Visible = false;
            // 
            // dateTimePickerNGAYXUAT
            // 
            this.dateTimePickerNGAYXUAT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNGAYXUAT.Location = new System.Drawing.Point(224, 72);
            this.dateTimePickerNGAYXUAT.Name = "dateTimePickerNGAYXUAT";
            this.dateTimePickerNGAYXUAT.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerNGAYXUAT.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePickerDATE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 147);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XUẤT HÀNG";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxID);
            this.groupBox2.Controls.Add(this.dateTimePickerNGAYXUAT);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonSAVE);
            this.groupBox2.Controls.Add(this.textBoxTIENLAI);
            this.groupBox2.Controls.Add(this.textBoxTIENGOC);
            this.groupBox2.Controls.Add(this.comboBoxKHACHHANG);
            this.groupBox2.Controls.Add(this.comboBoxKHO);
            this.groupBox2.Location = new System.Drawing.Point(250, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHI TIẾT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(149, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "NGÀY XUẤT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "TIỀN LÃI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "TIỀN GỐC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "KHÁCH HÀNG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "KHO";
            // 
            // buttonSAVE
            // 
            this.buttonSAVE.Location = new System.Drawing.Point(462, 42);
            this.buttonSAVE.Name = "buttonSAVE";
            this.buttonSAVE.Size = new System.Drawing.Size(75, 48);
            this.buttonSAVE.TabIndex = 8;
            this.buttonSAVE.Text = "LƯU";
            this.buttonSAVE.UseVisualStyleBackColor = true;
            this.buttonSAVE.Click += new System.EventHandler(this.buttonSAVE_Click);
            // 
            // textBoxTIENLAI
            // 
            this.textBoxTIENLAI.Enabled = false;
            this.textBoxTIENLAI.Location = new System.Drawing.Point(310, 46);
            this.textBoxTIENLAI.Name = "textBoxTIENLAI";
            this.textBoxTIENLAI.Size = new System.Drawing.Size(121, 20);
            this.textBoxTIENLAI.TabIndex = 5;
            // 
            // textBoxTIENGOC
            // 
            this.textBoxTIENGOC.Enabled = false;
            this.textBoxTIENGOC.Location = new System.Drawing.Point(310, 20);
            this.textBoxTIENGOC.Name = "textBoxTIENGOC";
            this.textBoxTIENGOC.Size = new System.Drawing.Size(121, 20);
            this.textBoxTIENGOC.TabIndex = 4;
            // 
            // comboBoxKHACHHANG
            // 
            this.comboBoxKHACHHANG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHACHHANG.FormattingEnabled = true;
            this.comboBoxKHACHHANG.Location = new System.Drawing.Point(92, 46);
            this.comboBoxKHACHHANG.Name = "comboBoxKHACHHANG";
            this.comboBoxKHACHHANG.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKHACHHANG.TabIndex = 1;
            this.comboBoxKHACHHANG.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHACHHANG_SelectedIndexChanged);
            // 
            // comboBoxKHO
            // 
            this.comboBoxKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKHO.FormattingEnabled = true;
            this.comboBoxKHO.Location = new System.Drawing.Point(92, 19);
            this.comboBoxKHO.Name = "comboBoxKHO";
            this.comboBoxKHO.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKHO.TabIndex = 0;
            this.comboBoxKHO.SelectedIndexChanged += new System.EventHandler(this.comboBoxKHO_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "NGÀY XUẤT";
            // 
            // dateTimePickerDATE
            // 
            this.dateTimePickerDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDATE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDATE.Location = new System.Drawing.Point(51, 84);
            this.dateTimePickerDATE.Name = "dateTimePickerDATE";
            this.dateTimePickerDATE.Size = new System.Drawing.Size(138, 26);
            this.dateTimePickerDATE.TabIndex = 0;
            this.dateTimePickerDATE.ValueChanged += new System.EventHandler(this.dateTimePickerDATE_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(808, 273);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // FThuNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 420);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FThuNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THU NỢ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FThuNo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.DateTimePicker dateTimePickerNGAYXUAT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSAVE;
        private System.Windows.Forms.TextBox textBoxTIENLAI;
        private System.Windows.Forms.TextBox textBoxTIENGOC;
        private System.Windows.Forms.ComboBox comboBoxKHACHHANG;
        private System.Windows.Forms.ComboBox comboBoxKHO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDATE;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}