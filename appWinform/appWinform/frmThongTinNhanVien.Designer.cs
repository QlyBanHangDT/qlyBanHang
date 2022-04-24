namespace appWinform
{
    partial class frmThongTinNhanVien
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.btnCapNhat = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNgayTao = new GUI.textBoxCustom();
            this.txtDiaChi = new GUI.textBoxCustom();
            this.txtSDT = new GUI.textBoxCustom();
            this.txtTinhTrang = new GUI.textBoxCustom();
            this.txtEmail = new GUI.textBoxCustom();
            this.txtTenNV = new GUI.textBoxCustom();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(857, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tình trạng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(503, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Giới tính";
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(596, 81);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(58, 21);
            this.rdbNam.TabIndex = 15;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(707, 81);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(47, 21);
            this.rdbNu.TabIndex = 16;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgaySinh.Location = new System.Drawing.Point(177, 142);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(241, 30);
            this.txtNgaySinh.TabIndex = 17;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.LightGreen;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnCapNhat.IconColor = System.Drawing.Color.Black;
            this.btnCapNhat.IconSize = 26;
            this.btnCapNhat.Location = new System.Drawing.Point(707, 370);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Rotation = 0D;
            this.btnCapNhat.Size = new System.Drawing.Size(146, 39);
            this.btnCapNhat.TabIndex = 18;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(500, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ngày tạo";
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.BackColor = System.Drawing.SystemColors.Control;
            this.txtNgayTao.BorderColor = System.Drawing.Color.Gray;
            this.txtNgayTao.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtNgayTao.BorderSize = 2;
            this.txtNgayTao.Enabled = false;
            this.txtNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayTao.ForeColor = System.Drawing.Color.Black;
            this.txtNgayTao.Location = new System.Drawing.Point(593, 127);
            this.txtNgayTao.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayTao.Multiline = false;
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.Padding = new System.Windows.Forms.Padding(7);
            this.txtNgayTao.PasswordChar = false;
            this.txtNgayTao.Size = new System.Drawing.Size(240, 35);
            this.txtNgayTao.TabIndex = 21;
            this.txtNgayTao.Texts = "";
            this.txtNgayTao.UnderlinedStyle = true;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.SystemColors.Control;
            this.txtDiaChi.BorderColor = System.Drawing.Color.Gray;
            this.txtDiaChi.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtDiaChi.BorderSize = 2;
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChi.Location = new System.Drawing.Point(178, 293);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaChi.Multiline = false;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Padding = new System.Windows.Forms.Padding(7);
            this.txtDiaChi.PasswordChar = false;
            this.txtDiaChi.Size = new System.Drawing.Size(240, 35);
            this.txtDiaChi.TabIndex = 12;
            this.txtDiaChi.TabStop = false;
            this.txtDiaChi.Texts = "";
            this.txtDiaChi.UnderlinedStyle = true;
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.SystemColors.Control;
            this.txtSDT.BorderColor = System.Drawing.Color.Gray;
            this.txtSDT.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtSDT.BorderSize = 2;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.ForeColor = System.Drawing.Color.Black;
            this.txtSDT.Location = new System.Drawing.Point(178, 233);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSDT.Multiline = false;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Padding = new System.Windows.Forms.Padding(7);
            this.txtSDT.PasswordChar = false;
            this.txtSDT.Size = new System.Drawing.Size(240, 35);
            this.txtSDT.TabIndex = 10;
            this.txtSDT.TabStop = false;
            this.txtSDT.Texts = "";
            this.txtSDT.UnderlinedStyle = true;
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.BackColor = System.Drawing.SystemColors.Control;
            this.txtTinhTrang.BorderColor = System.Drawing.Color.Gray;
            this.txtTinhTrang.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtTinhTrang.BorderSize = 2;
            this.txtTinhTrang.Enabled = false;
            this.txtTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhTrang.ForeColor = System.Drawing.Color.Black;
            this.txtTinhTrang.Location = new System.Drawing.Point(178, 352);
            this.txtTinhTrang.Margin = new System.Windows.Forms.Padding(4);
            this.txtTinhTrang.Multiline = false;
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Padding = new System.Windows.Forms.Padding(7);
            this.txtTinhTrang.PasswordChar = false;
            this.txtTinhTrang.Size = new System.Drawing.Size(240, 35);
            this.txtTinhTrang.TabIndex = 8;
            this.txtTinhTrang.Texts = "";
            this.txtTinhTrang.UnderlinedStyle = true;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmail.BorderColor = System.Drawing.Color.Gray;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtEmail.BorderSize = 2;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(178, 180);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(7);
            this.txtEmail.PasswordChar = false;
            this.txtEmail.Size = new System.Drawing.Size(240, 35);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.TabStop = false;
            this.txtEmail.Texts = "";
            this.txtEmail.UnderlinedStyle = true;
            // 
            // txtTenNV
            // 
            this.txtTenNV.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenNV.BorderColor = System.Drawing.Color.Gray;
            this.txtTenNV.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtTenNV.BorderSize = 2;
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.ForeColor = System.Drawing.Color.Black;
            this.txtTenNV.Location = new System.Drawing.Point(178, 67);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNV.Multiline = false;
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Padding = new System.Windows.Forms.Padding(7);
            this.txtTenNV.PasswordChar = false;
            this.txtTenNV.Size = new System.Drawing.Size(240, 35);
            this.txtTenNV.TabIndex = 6;
            this.txtTenNV.TabStop = false;
            this.txtTenNV.Texts = "";
            this.txtTenNV.UnderlinedStyle = true;
            // 
            // frmThongTinNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 438);
            this.Controls.Add(this.txtNgayTao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.rdbNu);
            this.Controls.Add(this.rdbNam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTinhTrang);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmThongTinNhanVien";
            this.Text = "frmThongTinNhanVien";
            this.Load += new System.EventHandler(this.frmThongTinNhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private GUI.textBoxCustom txtTenNV;
        private GUI.textBoxCustom txtEmail;
        private GUI.textBoxCustom txtTinhTrang;
        private System.Windows.Forms.Label label7;
        private GUI.textBoxCustom txtSDT;
        private GUI.textBoxCustom txtDiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker txtNgaySinh;
        private FontAwesome.Sharp.IconButton btnCapNhat;
        private System.Windows.Forms.Label label9;
        private GUI.textBoxCustom txtNgayTao;
    }
}