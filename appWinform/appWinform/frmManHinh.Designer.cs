namespace appWinform
{
    partial class frmManHinh
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
            this.txtIDMH = new GUI.textBoxCustom();
            this.txtTenMH = new GUI.textBoxCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManHinh = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIDMH
            // 
            this.txtIDMH.BackColor = System.Drawing.SystemColors.Control;
            this.txtIDMH.BorderColor = System.Drawing.Color.Gray;
            this.txtIDMH.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtIDMH.BorderSize = 2;
            this.txtIDMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDMH.ForeColor = System.Drawing.Color.Black;
            this.txtIDMH.Location = new System.Drawing.Point(126, 363);
            this.txtIDMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDMH.Multiline = false;
            this.txtIDMH.Name = "txtIDMH";
            this.txtIDMH.Padding = new System.Windows.Forms.Padding(7);
            this.txtIDMH.PasswordChar = false;
            this.txtIDMH.Size = new System.Drawing.Size(248, 35);
            this.txtIDMH.TabIndex = 7;
            this.txtIDMH.TabStop = false;
            this.txtIDMH.Texts = "";
            this.txtIDMH.UnderlinedStyle = true;
            // 
            // txtTenMH
            // 
            this.txtTenMH.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenMH.BorderColor = System.Drawing.Color.Gray;
            this.txtTenMH.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtTenMH.BorderSize = 2;
            this.txtTenMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMH.ForeColor = System.Drawing.Color.Black;
            this.txtTenMH.Location = new System.Drawing.Point(126, 406);
            this.txtTenMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenMH.Multiline = false;
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Padding = new System.Windows.Forms.Padding(7);
            this.txtTenMH.PasswordChar = false;
            this.txtTenMH.Size = new System.Drawing.Size(248, 35);
            this.txtTenMH.TabIndex = 8;
            this.txtTenMH.TabStop = false;
            this.txtTenMH.Texts = "";
            this.txtTenMH.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "MÀN HÌNH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "ID Màn hình";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tên màn hình";
            // 
            // dgvManHinh
            // 
            this.dgvManHinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManHinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvManHinh.Location = new System.Drawing.Point(13, 55);
            this.dgvManHinh.Name = "dgvManHinh";
            this.dgvManHinh.RowTemplate.Height = 24;
            this.dgvManHinh.Size = new System.Drawing.Size(489, 284);
            this.dgvManHinh.TabIndex = 12;
            this.dgvManHinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManHinh_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID MÀN HÌNH";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENMH";
            this.Column2.HeaderText = "TÊN MÀN HÌNH";
            this.Column2.Name = "Column2";
            this.Column2.Width = 300;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LightGreen;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnLuu.IconColor = System.Drawing.Color.Black;
            this.btnLuu.IconSize = 26;
            this.btnLuu.Location = new System.Drawing.Point(393, 460);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Rotation = 0D;
            this.btnLuu.Size = new System.Drawing.Size(109, 39);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // frmManHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 511);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvManHinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.txtIDMH);
            this.Name = "frmManHinh";
            this.Text = "frmManHinh";
            this.Load += new System.EventHandler(this.frmManHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManHinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI.textBoxCustom txtIDMH;
        private GUI.textBoxCustom txtTenMH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvManHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private FontAwesome.Sharp.IconButton btnLuu;
    }
}