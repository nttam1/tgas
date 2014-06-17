namespace T_Manager.Data
{
    partial class FKho
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
            this.buttonADD = new System.Windows.Forms.Button();
            this.textBoxKHACHHANG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewKHACHHANG = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKHACHHANG)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(360, 81);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 23);
            this.buttonADD.TabIndex = 7;
            this.buttonADD.Text = "THÊM";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // textBoxKHACHHANG
            // 
            this.textBoxKHACHHANG.Location = new System.Drawing.Point(299, 39);
            this.textBoxKHACHHANG.Name = "textBoxKHACHHANG";
            this.textBoxKHACHHANG.Size = new System.Drawing.Size(219, 20);
            this.textBoxKHACHHANG.TabIndex = 6;
            this.textBoxKHACHHANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKHACHHANG_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TÊN KHO MỚI";
            // 
            // dataGridViewKHACHHANG
            // 
            this.dataGridViewKHACHHANG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKHACHHANG.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewKHACHHANG.Name = "dataGridViewKHACHHANG";
            this.dataGridViewKHACHHANG.Size = new System.Drawing.Size(278, 306);
            this.dataGridViewKHACHHANG.TabIndex = 4;
            // 
            // FKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 329);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.textBoxKHACHHANG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewKHACHHANG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KHO CHỨA HÀNG";
            this.Load += new System.EventHandler(this.FKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKHACHHANG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.TextBox textBoxKHACHHANG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewKHACHHANG;
    }
}