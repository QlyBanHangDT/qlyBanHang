namespace GUI
{
    partial class ThongTinKH
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cmenuTrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chỉnhSửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLuuTen = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new GUI.textBoxCustom();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new GUI.textBoxCustom();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKH = new GUI.textBoxCustom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNgayTao = new GUI.textBoxCustom();
            this.txtGioiTinh = new GUI.textBoxCustom();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtID = new GUI.textBoxCustom();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongBan = new GUI.textBoxCustom();
            this.label4 = new System.Windows.Forms.Label();
            this.drvLSMuaHang = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmenuTrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drvLSMuaHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(787, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin khách hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTen
            // 
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(3, 0);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(153, 35);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Tên khách hàng:";
            this.lbTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.604167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.45833F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.604167F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 215);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtNgaySinh);
            this.panel1.Controls.Add(this.btnLuuTen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTenKH);
            this.panel1.Controls.Add(this.lbTen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 209);
            this.panel1.TabIndex = 0;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.ContextMenuStrip = this.cmenuTrip;
            this.txtNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgaySinh.Location = new System.Drawing.Point(162, 88);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(241, 30);
            this.txtNgaySinh.TabIndex = 13;
            this.txtNgaySinh.ValueChanged += new System.EventHandler(this.txtNgaySinh_ValueChanged);
            // 
            // cmenuTrip
            // 
            this.cmenuTrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chỉnhSửaToolStripMenuItem});
            this.cmenuTrip.Name = "cmenuTrip";
            this.cmenuTrip.Size = new System.Drawing.Size(143, 28);
            // 
            // chỉnhSửaToolStripMenuItem
            // 
            this.chỉnhSửaToolStripMenuItem.Name = "chỉnhSửaToolStripMenuItem";
            this.chỉnhSửaToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.chỉnhSửaToolStripMenuItem.Text = "Chỉnh sửa";
            this.chỉnhSửaToolStripMenuItem.Click += new System.EventHandler(this.chỉnhSửaToolStripMenuItem_Click);
            // 
            // btnLuuTen
            // 
            this.btnLuuTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnLuuTen.FlatAppearance.BorderSize = 0;
            this.btnLuuTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuTen.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLuuTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTen.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnLuuTen.IconColor = System.Drawing.Color.Black;
            this.btnLuuTen.IconSize = 26;
            this.btnLuuTen.Location = new System.Drawing.Point(182, 167);
            this.btnLuuTen.Name = "btnLuuTen";
            this.btnLuuTen.Rotation = 0D;
            this.btnLuuTen.Size = new System.Drawing.Size(83, 39);
            this.btnLuuTen.TabIndex = 10;
            this.btnLuuTen.Text = "Lưu";
            this.btnLuuTen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuTen.UseVisualStyleBackColor = false;
            this.btnLuuTen.Visible = false;
            this.btnLuuTen.Click += new System.EventHandler(this.btnLuuTen_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày sinh:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.Gray;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtEmail.BorderSize = 2;
            this.txtEmail.ContextMenuStrip = this.cmenuTrip;
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(163, 125);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(7);
            this.txtEmail.PasswordChar = false;
            this.txtEmail.Size = new System.Drawing.Size(240, 35);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Texts = "";
            this.txtEmail.UnderlinedStyle = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.White;
            this.txtSDT.BorderColor = System.Drawing.Color.Gray;
            this.txtSDT.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtSDT.BorderSize = 2;
            this.txtSDT.ContextMenuStrip = this.cmenuTrip;
            this.txtSDT.Enabled = false;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.ForeColor = System.Drawing.Color.Black;
            this.txtSDT.Location = new System.Drawing.Point(163, 41);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSDT.Multiline = false;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Padding = new System.Windows.Forms.Padding(7);
            this.txtSDT.PasswordChar = false;
            this.txtSDT.Size = new System.Drawing.Size(240, 35);
            this.txtSDT.TabIndex = 4;
            this.txtSDT.Texts = "";
            this.txtSDT.UnderlinedStyle = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số điện thoại:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.Color.White;
            this.txtTenKH.BorderColor = System.Drawing.Color.Gray;
            this.txtTenKH.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTenKH.BorderSize = 2;
            this.txtTenKH.ContextMenuStrip = this.cmenuTrip;
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.ForeColor = System.Drawing.Color.Black;
            this.txtTenKH.Location = new System.Drawing.Point(163, -2);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenKH.Multiline = false;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Padding = new System.Windows.Forms.Padding(7);
            this.txtTenKH.PasswordChar = false;
            this.txtTenKH.Size = new System.Drawing.Size(240, 35);
            this.txtTenKH.TabIndex = 2;
            this.txtTenKH.Texts = "";
            this.txtTenKH.UnderlinedStyle = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtNgayTao);
            this.panel2.Controls.Add(this.txtGioiTinh);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTongBan);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(482, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 209);
            this.panel2.TabIndex = 1;
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.BackColor = System.Drawing.Color.White;
            this.txtNgayTao.BorderColor = System.Drawing.Color.Gray;
            this.txtNgayTao.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNgayTao.BorderSize = 2;
            this.txtNgayTao.Enabled = false;
            this.txtNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayTao.ForeColor = System.Drawing.Color.Black;
            this.txtNgayTao.Location = new System.Drawing.Point(110, 90);
            this.txtNgayTao.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayTao.Multiline = false;
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.Padding = new System.Windows.Forms.Padding(7);
            this.txtNgayTao.PasswordChar = false;
            this.txtNgayTao.Size = new System.Drawing.Size(166, 35);
            this.txtNgayTao.TabIndex = 19;
            this.txtNgayTao.Texts = "";
            this.txtNgayTao.UnderlinedStyle = true;
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.BackColor = System.Drawing.Color.White;
            this.txtGioiTinh.BorderColor = System.Drawing.Color.Gray;
            this.txtGioiTinh.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtGioiTinh.BorderSize = 2;
            this.txtGioiTinh.ContextMenuStrip = this.cmenuTrip;
            this.txtGioiTinh.Enabled = false;
            this.txtGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGioiTinh.ForeColor = System.Drawing.Color.Black;
            this.txtGioiTinh.Location = new System.Drawing.Point(114, 47);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtGioiTinh.Multiline = false;
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Padding = new System.Windows.Forms.Padding(7);
            this.txtGioiTinh.PasswordChar = false;
            this.txtGioiTinh.Size = new System.Drawing.Size(166, 35);
            this.txtGioiTinh.TabIndex = 18;
            this.txtGioiTinh.Texts = "";
            this.txtGioiTinh.UnderlinedStyle = true;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 35);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ngày tạo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 35);
            this.label7.TabIndex = 16;
            this.label7.Text = "Giới tính:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderColor = System.Drawing.Color.Gray;
            this.txtID.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtID.BorderSize = 2;
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.Black;
            this.txtID.Location = new System.Drawing.Point(114, 4);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Multiline = false;
            this.txtID.Name = "txtID";
            this.txtID.Padding = new System.Windows.Forms.Padding(7);
            this.txtID.PasswordChar = false;
            this.txtID.Size = new System.Drawing.Size(166, 35);
            this.txtID.TabIndex = 14;
            this.txtID.Texts = "";
            this.txtID.UnderlinedStyle = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 35);
            this.label5.TabIndex = 15;
            this.label5.Text = "ID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTongBan
            // 
            this.txtTongBan.BackColor = System.Drawing.Color.White;
            this.txtTongBan.BorderColor = System.Drawing.Color.Blue;
            this.txtTongBan.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTongBan.BorderSize = 2;
            this.txtTongBan.Enabled = false;
            this.txtTongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTongBan.Location = new System.Drawing.Point(110, 133);
            this.txtTongBan.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongBan.Multiline = false;
            this.txtTongBan.Name = "txtTongBan";
            this.txtTongBan.Padding = new System.Windows.Forms.Padding(7);
            this.txtTongBan.PasswordChar = false;
            this.txtTongBan.Size = new System.Drawing.Size(166, 35);
            this.txtTongBan.TabIndex = 13;
            this.txtTongBan.Texts = "";
            this.txtTongBan.UnderlinedStyle = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 35);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tổng bán:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // drvLSMuaHang
            // 
            this.drvLSMuaHang.AllowUserToAddRows = false;
            this.drvLSMuaHang.AllowUserToDeleteRows = false;
            this.drvLSMuaHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drvLSMuaHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvLSMuaHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvLSMuaHang.Location = new System.Drawing.Point(0, 315);
            this.drvLSMuaHang.Name = "drvLSMuaHang";
            this.drvLSMuaHang.ReadOnly = true;
            this.drvLSMuaHang.RowTemplate.Height = 24;
            this.drvLSMuaHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvLSMuaHang.Size = new System.Drawing.Size(793, 365);
            this.drvLSMuaHang.TabIndex = 4;
            // 
            // ThongTinKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.drvLSMuaHang);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "ThongTinKH";
            this.Size = new System.Drawing.Size(793, 680);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.cmenuTrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drvLSMuaHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private GUI.textBoxCustom txtEmail;
        private System.Windows.Forms.Label label3;
        private GUI.textBoxCustom txtSDT;
        private System.Windows.Forms.Label label2;
        private GUI.textBoxCustom txtTenKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private textBoxCustom txtTongBan;
        private FontAwesome.Sharp.IconButton btnLuuTen;
        private System.Windows.Forms.ContextMenuStrip cmenuTrip;
        private System.Windows.Forms.ToolStripMenuItem chỉnhSửaToolStripMenuItem;
        private System.Windows.Forms.DataGridView drvLSMuaHang;
        private textBoxCustom txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtNgaySinh;
        private System.Windows.Forms.Label label6;
        private textBoxCustom txtNgayTao;
        private textBoxCustom txtGioiTinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}
