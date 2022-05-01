namespace GUI
{
    partial class frmThemSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemSanPham));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.imageSP = new System.Windows.Forms.PictureBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.cboHang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCauHinh = new System.Windows.Forms.TabPage();
            this.drvCauHinh = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCauHinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXacNhan = new GUI.CustomButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSP)).BeginInit();
            this.tabCauHinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drvCauHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabThongTin);
            this.tabControl1.Controls.Add(this.tabCauHinh);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(679, 373);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.txtGia);
            this.tabThongTin.Controls.Add(this.txtTen);
            this.tabThongTin.Controls.Add(this.imageSP);
            this.tabThongTin.Controls.Add(this.cboLoai);
            this.tabThongTin.Controls.Add(this.cboDanhMuc);
            this.tabThongTin.Controls.Add(this.cboHang);
            this.tabThongTin.Controls.Add(this.label2);
            this.tabThongTin.Controls.Add(this.label5);
            this.tabThongTin.Controls.Add(this.label4);
            this.tabThongTin.Controls.Add(this.label3);
            this.tabThongTin.Controls.Add(this.label1);
            this.tabThongTin.Location = new System.Drawing.Point(4, 25);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(671, 344);
            this.tabThongTin.TabIndex = 0;
            this.tabThongTin.Text = "Thông tin chi tiêt";
            this.tabThongTin.UseVisualStyleBackColor = true;
            // 
            // imageSP
            // 
            this.imageSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageSP.Image = ((System.Drawing.Image)(resources.GetObject("imageSP.Image")));
            this.imageSP.InitialImage = ((System.Drawing.Image)(resources.GetObject("imageSP.InitialImage")));
            this.imageSP.Location = new System.Drawing.Point(0, 0);
            this.imageSP.Name = "imageSP";
            this.imageSP.Size = new System.Drawing.Size(246, 343);
            this.imageSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageSP.TabIndex = 4;
            this.imageSP.TabStop = false;
            this.imageSP.Click += new System.EventHandler(this.imageSP_Click);
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(334, 62);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(135, 24);
            this.cboDanhMuc.TabIndex = 3;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // cboHang
            // 
            this.cboHang.FormattingEnabled = true;
            this.cboHang.Location = new System.Drawing.Point(529, 55);
            this.cboHang.Name = "cboHang";
            this.cboHang.Size = new System.Drawing.Size(135, 24);
            this.cboHang.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(475, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "Giá:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(252, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "Danh mục";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hãng:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabCauHinh
            // 
            this.tabCauHinh.Controls.Add(this.drvCauHinh);
            this.tabCauHinh.Location = new System.Drawing.Point(4, 25);
            this.tabCauHinh.Name = "tabCauHinh";
            this.tabCauHinh.Padding = new System.Windows.Forms.Padding(3);
            this.tabCauHinh.Size = new System.Drawing.Size(638, 292);
            this.tabCauHinh.TabIndex = 1;
            this.tabCauHinh.Text = "Cấu hình";
            this.tabCauHinh.UseVisualStyleBackColor = true;
            // 
            // drvCauHinh
            // 
            this.drvCauHinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drvCauHinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvCauHinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvCauHinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.TenCauHinh,
            this.NoiDung});
            this.drvCauHinh.Location = new System.Drawing.Point(9, 7);
            this.drvCauHinh.Name = "drvCauHinh";
            this.drvCauHinh.RowTemplate.Height = 24;
            this.drvCauHinh.Size = new System.Drawing.Size(622, 279);
            this.drvCauHinh.TabIndex = 0;
            this.drvCauHinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            // 
            // TenCauHinh
            // 
            this.TenCauHinh.HeaderText = "Tên";
            this.TenCauHinh.Name = "TenCauHinh";
            // 
            // NoiDung
            // 
            this.NoiDung.HeaderText = "Nội dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.White;
            this.btnXacNhan.BackgroundColor = System.Drawing.Color.White;
            this.btnXacNhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.BorderSize = 2;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.Location = new System.Drawing.Point(518, 378);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(150, 40);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(280, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 35);
            this.label5.TabIndex = 0;
            this.label5.Text = "Loại";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLoai
            // 
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(334, 97);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(135, 24);
            this.cboLoai.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(334, 20);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(135, 22);
            this.txtTen.TabIndex = 5;
            this.txtTen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(529, 20);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(135, 22);
            this.txtGia.TabIndex = 6;
            this.txtGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGia.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGia_KeyPress);
            // 
            // frmThemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 430);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmThemSanPham";
            this.Text = "frmThemSanPham";
            this.Load += new System.EventHandler(this.frmThemSanPham_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSP)).EndInit();
            this.tabCauHinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drvCauHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabCauHinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.ComboBox cboHang;
        private System.Windows.Forms.PictureBox imageSP;
        private System.Windows.Forms.DataGridView drvCauHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCauHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private CustomButton btnXacNhan;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtGia;
    }
}