namespace T_Manager
{
    partial class FTonKho
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSAVE = new System.Windows.Forms.Button();
            this.dataGridViewIMPORT = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIMPORT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 123;
            this.label1.Text = "NHẬP HÀNG HÓA TỒN KHO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSAVE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 111);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            // 
            // buttonSAVE
            // 
            this.buttonSAVE.Location = new System.Drawing.Point(6, 52);
            this.buttonSAVE.Name = "buttonSAVE";
            this.buttonSAVE.Size = new System.Drawing.Size(140, 53);
            this.buttonSAVE.TabIndex = 124;
            this.buttonSAVE.Text = "NHẬP";
            this.buttonSAVE.UseVisualStyleBackColor = true;
            this.buttonSAVE.Click += new System.EventHandler(this.buttonSAVE_Click);
            // 
            // dataGridViewIMPORT
            // 
            this.dataGridViewIMPORT.AllowUserToDeleteRows = false;
            this.dataGridViewIMPORT.AllowUserToOrderColumns = true;
            this.dataGridViewIMPORT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIMPORT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIMPORT.Location = new System.Drawing.Point(0, 111);
            this.dataGridViewIMPORT.Name = "dataGridViewIMPORT";
            this.dataGridViewIMPORT.Size = new System.Drawing.Size(754, 317);
            this.dataGridViewIMPORT.TabIndex = 125;
            this.dataGridViewIMPORT.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewIMPORT_CellValidating);
            // 
            // FTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 428);
            this.Controls.Add(this.dataGridViewIMPORT);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NHẬP TỒN KHO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FTonKho_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIMPORT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewIMPORT;
        private System.Windows.Forms.Button buttonSAVE;
    }
}