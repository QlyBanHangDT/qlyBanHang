namespace appWinform
{
    partial class frm_KiemKho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbo_PKK = new System.Windows.Forms.ComboBox();
            this.dgv_CTPKK = new System.Windows.Forms.DataGridView();
            this.ID_SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_TONKHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_THUCTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_LECH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIATRILECH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapNhat = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnThemPKK = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.btnXoaPhieu = new FontAwesome.Sharp.IconButton();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.btnThemChiTiet = new FontAwesome.Sharp.IconButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnHoanThanh = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTenSP = new System.Windows.Forms.ComboBox();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiaTri = new GUI.textBoxCustom();
            this.txtSL_Lech = new GUI.textBoxCustom();
            this.txtSL_Ton = new GUI.textBoxCustom();
            this.txtSL_ThucTe = new GUI.textBoxCustom();
            this.btnXuatFile = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTPKK)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_PKK
            // 
            this.cbo_PKK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_PKK.FormattingEnabled = true;
            this.cbo_PKK.Location = new System.Drawing.Point(703, 89);
            this.cbo_PKK.Name = "cbo_PKK";
            this.cbo_PKK.Size = new System.Drawing.Size(143, 24);
            this.cbo_PKK.TabIndex = 0;
            this.cbo_PKK.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbo_PKK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_PKK_KeyPress);
            // 
            // dgv_CTPKK
            // 
            this.dgv_CTPKK.AllowUserToAddRows = false;
            this.dgv_CTPKK.AllowUserToDeleteRows = false;
            this.dgv_CTPKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CTPKK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_SP,
            this.SL_TONKHO,
            this.SL_THUCTE,
            this.SL_LECH,
            this.GIATRILECH});
            this.dgv_CTPKK.Location = new System.Drawing.Point(23, 128);
            this.dgv_CTPKK.MultiSelect = false;
            this.dgv_CTPKK.Name = "dgv_CTPKK";
            this.dgv_CTPKK.ReadOnly = true;
            this.dgv_CTPKK.RowTemplate.Height = 24;
            this.dgv_CTPKK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CTPKK.Size = new System.Drawing.Size(894, 179);
            this.dgv_CTPKK.TabIndex = 1;
            this.dgv_CTPKK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CTPKK_CellClick);
            // 
            // ID_SP
            // 
            this.ID_SP.DataPropertyName = "TenSP";
            this.ID_SP.HeaderText = "Tên sản phẩm";
            this.ID_SP.Name = "ID_SP";
            this.ID_SP.ReadOnly = true;
            this.ID_SP.Width = 170;
            // 
            // SL_TONKHO
            // 
            this.SL_TONKHO.DataPropertyName = "SL_TON";
            this.SL_TONKHO.HeaderText = "Số lượng tồn kho trong hệ thống";
            this.SL_TONKHO.Name = "SL_TONKHO";
            this.SL_TONKHO.ReadOnly = true;
            this.SL_TONKHO.Width = 170;
            // 
            // SL_THUCTE
            // 
            this.SL_THUCTE.DataPropertyName = "SL_THUCTE";
            this.SL_THUCTE.HeaderText = "Số lượng thực tế";
            this.SL_THUCTE.Name = "SL_THUCTE";
            this.SL_THUCTE.ReadOnly = true;
            this.SL_THUCTE.Width = 171;
            // 
            // SL_LECH
            // 
            this.SL_LECH.DataPropertyName = "SL_LECH";
            this.SL_LECH.HeaderText = "Số lượng lệch";
            this.SL_LECH.Name = "SL_LECH";
            this.SL_LECH.ReadOnly = true;
            this.SL_LECH.Width = 170;
            // 
            // GIATRILECH
            // 
            this.GIATRILECH.DataPropertyName = "GIATRI";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            dataGridViewCellStyle1.NullValue = null;
            this.GIATRILECH.DefaultCellStyle = dataGridViewCellStyle1;
            this.GIATRILECH.HeaderText = "Giá trị lệch";
            this.GIATRILECH.Name = "GIATRILECH";
            this.GIATRILECH.ReadOnly = true;
            this.GIATRILECH.Width = 170;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhat.BackColor = System.Drawing.Color.Chartreuse;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnCapNhat.IconColor = System.Drawing.Color.Black;
            this.btnCapNhat.IconSize = 26;
            this.btnCapNhat.Location = new System.Drawing.Point(662, 544);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Rotation = 0D;
            this.btnCapNhat.Size = new System.Drawing.Size(146, 45);
            this.btnCapNhat.TabIndex = 19;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tổng số lượng lệch";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(593, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Phiếu kiểm kho";
            // 
            // btnThemPKK
            // 
            this.btnThemPKK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemPKK.BackColor = System.Drawing.Color.Blue;
            this.btnThemPKK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnThemPKK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPKK.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnThemPKK.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThemPKK.IconColor = System.Drawing.Color.White;
            this.btnThemPKK.IconSize = 20;
            this.btnThemPKK.Location = new System.Drawing.Point(859, 89);
            this.btnThemPKK.Name = "btnThemPKK";
            this.btnThemPKK.Rotation = 0D;
            this.btnThemPKK.Size = new System.Drawing.Size(25, 24);
            this.btnThemPKK.TabIndex = 29;
            this.btnThemPKK.UseVisualStyleBackColor = false;
            this.btnThemPKK.Click += new System.EventHandler(this.btnThemPKK_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(894, 46);
            this.label9.TabIndex = 30;
            this.label9.Text = "PHIẾU KIỂM KHO";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaPhieu.BackColor = System.Drawing.Color.Red;
            this.btnXoaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhieu.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnXoaPhieu.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnXoaPhieu.IconColor = System.Drawing.Color.White;
            this.btnXoaPhieu.IconSize = 20;
            this.btnXoaPhieu.Location = new System.Drawing.Point(890, 89);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Rotation = 0D;
            this.btnXoaPhieu.Size = new System.Drawing.Size(25, 24);
            this.btnXoaPhieu.TabIndex = 31;
            this.btnXoaPhieu.UseVisualStyleBackColor = false;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            this.btnXoa.IconColor = System.Drawing.Color.White;
            this.btnXoa.IconSize = 25;
            this.btnXoa.Location = new System.Drawing.Point(814, 544);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rotation = 0D;
            this.btnXoa.Size = new System.Drawing.Size(103, 45);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThemChiTiet
            // 
            this.btnThemChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemChiTiet.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemChiTiet.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnThemChiTiet.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThemChiTiet.IconColor = System.Drawing.Color.White;
            this.btnThemChiTiet.IconSize = 20;
            this.btnThemChiTiet.Location = new System.Drawing.Point(780, 318);
            this.btnThemChiTiet.Name = "btnThemChiTiet";
            this.btnThemChiTiet.Rotation = 0D;
            this.btnThemChiTiet.Size = new System.Drawing.Size(25, 24);
            this.btnThemChiTiet.TabIndex = 34;
            this.btnThemChiTiet.UseVisualStyleBackColor = false;
            this.btnThemChiTiet.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(811, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Thêm chi tiết";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Tình trạng phiếu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "label12";
            this.label12.TextChanged += new System.EventHandler(this.label12_TextChanged);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHoanThanh.BackColor = System.Drawing.Color.Blue;
            this.btnHoanThanh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnHoanThanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoanThanh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnHoanThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnHoanThanh.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnHoanThanh.IconColor = System.Drawing.Color.White;
            this.btnHoanThanh.IconSize = 25;
            this.btnHoanThanh.Location = new System.Drawing.Point(371, 544);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Rotation = 0D;
            this.btnHoanThanh.Size = new System.Drawing.Size(147, 45);
            this.btnHoanThanh.TabIndex = 38;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboTenSP);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGiaTri);
            this.groupBox1.Controls.Add(this.txtSL_Lech);
            this.groupBox1.Controls.Add(this.txtSL_Ton);
            this.groupBox1.Controls.Add(this.txtSL_ThucTe);
            this.groupBox1.Location = new System.Drawing.Point(23, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 184);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // cboTenSP
            // 
            this.cboTenSP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTenSP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTenSP.FormattingEnabled = true;
            this.cboTenSP.Location = new System.Drawing.Point(111, 29);
            this.cboTenSP.Name = "cboTenSP";
            this.cboTenSP.Size = new System.Drawing.Size(271, 24);
            this.cboTenSP.TabIndex = 51;
            this.cboTenSP.SelectedIndexChanged += new System.EventHandler(this.cboTenSP_SelectedIndexChanged);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.BackColor = System.Drawing.Color.Silver;
            this.btnHuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnHuy.IconColor = System.Drawing.Color.White;
            this.btnHuy.IconSize = 25;
            this.btnHuy.Location = new System.Drawing.Point(141, 119);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Rotation = 0D;
            this.btnHuy.Size = new System.Drawing.Size(115, 45);
            this.btnHuy.TabIndex = 49;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnLuu.IconColor = System.Drawing.Color.White;
            this.btnLuu.IconSize = 25;
            this.btnLuu.Location = new System.Drawing.Point(20, 119);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Rotation = 0D;
            this.btnLuu.Size = new System.Drawing.Size(115, 45);
            this.btnLuu.TabIndex = 50;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(469, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "Số lượng lệch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Số lượng thực tế";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Sô lượng tồn kho";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Giá trị lệch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Tên sản phẩm";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.BackColor = System.Drawing.SystemColors.Control;
            this.txtGiaTri.BorderColor = System.Drawing.Color.Gray;
            this.txtGiaTri.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtGiaTri.BorderSize = 2;
            this.txtGiaTri.Enabled = false;
            this.txtGiaTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTri.ForeColor = System.Drawing.Color.Black;
            this.txtGiaTri.Location = new System.Drawing.Point(111, 65);
            this.txtGiaTri.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaTri.Multiline = false;
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Padding = new System.Windows.Forms.Padding(7);
            this.txtGiaTri.PasswordChar = false;
            this.txtGiaTri.Size = new System.Drawing.Size(127, 35);
            this.txtGiaTri.TabIndex = 43;
            this.txtGiaTri.TabStop = false;
            this.txtGiaTri.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtGiaTri.Texts = "";
            this.txtGiaTri.UnderlinedStyle = true;
            // 
            // txtSL_Lech
            // 
            this.txtSL_Lech.BackColor = System.Drawing.SystemColors.Control;
            this.txtSL_Lech.BorderColor = System.Drawing.Color.Gray;
            this.txtSL_Lech.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtSL_Lech.BorderSize = 2;
            this.txtSL_Lech.Enabled = false;
            this.txtSL_Lech.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL_Lech.ForeColor = System.Drawing.Color.Black;
            this.txtSL_Lech.Location = new System.Drawing.Point(591, 108);
            this.txtSL_Lech.Margin = new System.Windows.Forms.Padding(4);
            this.txtSL_Lech.Multiline = false;
            this.txtSL_Lech.Name = "txtSL_Lech";
            this.txtSL_Lech.Padding = new System.Windows.Forms.Padding(7);
            this.txtSL_Lech.PasswordChar = false;
            this.txtSL_Lech.Size = new System.Drawing.Size(103, 35);
            this.txtSL_Lech.TabIndex = 42;
            this.txtSL_Lech.TabStop = false;
            this.txtSL_Lech.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSL_Lech.Texts = "";
            this.txtSL_Lech.UnderlinedStyle = true;
            // 
            // txtSL_Ton
            // 
            this.txtSL_Ton.BackColor = System.Drawing.SystemColors.Control;
            this.txtSL_Ton.BorderColor = System.Drawing.Color.Gray;
            this.txtSL_Ton.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtSL_Ton.BorderSize = 2;
            this.txtSL_Ton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL_Ton.ForeColor = System.Drawing.Color.Black;
            this.txtSL_Ton.Location = new System.Drawing.Point(591, 22);
            this.txtSL_Ton.Margin = new System.Windows.Forms.Padding(4);
            this.txtSL_Ton.Multiline = false;
            this.txtSL_Ton.Name = "txtSL_Ton";
            this.txtSL_Ton.Padding = new System.Windows.Forms.Padding(7);
            this.txtSL_Ton.PasswordChar = false;
            this.txtSL_Ton.Size = new System.Drawing.Size(103, 35);
            this.txtSL_Ton.TabIndex = 41;
            this.txtSL_Ton.TabStop = false;
            this.txtSL_Ton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSL_Ton.Texts = "";
            this.txtSL_Ton.UnderlinedStyle = true;
            this.txtSL_Ton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber);
            // 
            // txtSL_ThucTe
            // 
            this.txtSL_ThucTe.BackColor = System.Drawing.SystemColors.Control;
            this.txtSL_ThucTe.BorderColor = System.Drawing.Color.Gray;
            this.txtSL_ThucTe.BorderFocusColor = System.Drawing.Color.Blue;
            this.txtSL_ThucTe.BorderSize = 2;
            this.txtSL_ThucTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL_ThucTe.ForeColor = System.Drawing.Color.Black;
            this.txtSL_ThucTe.Location = new System.Drawing.Point(591, 65);
            this.txtSL_ThucTe.Margin = new System.Windows.Forms.Padding(4);
            this.txtSL_ThucTe.Multiline = false;
            this.txtSL_ThucTe.Name = "txtSL_ThucTe";
            this.txtSL_ThucTe.Padding = new System.Windows.Forms.Padding(7);
            this.txtSL_ThucTe.PasswordChar = false;
            this.txtSL_ThucTe.Size = new System.Drawing.Size(103, 35);
            this.txtSL_ThucTe.TabIndex = 40;
            this.txtSL_ThucTe.TabStop = false;
            this.txtSL_ThucTe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSL_ThucTe.Texts = "";
            this.txtSL_ThucTe.UnderlinedStyle = true;
            this.txtSL_ThucTe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnXuatFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatFile.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnXuatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFile.ForeColor = System.Drawing.Color.White;
            this.btnXuatFile.IconChar = FontAwesome.Sharp.IconChar.FileWord;
            this.btnXuatFile.IconColor = System.Drawing.Color.White;
            this.btnXuatFile.IconSize = 25;
            this.btnXuatFile.Location = new System.Drawing.Point(524, 544);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Rotation = 0D;
            this.btnXuatFile.Size = new System.Drawing.Size(132, 45);
            this.btnXuatFile.TabIndex = 38;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXuatFile.UseVisualStyleBackColor = false;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // frm_KiemKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnThemChiTiet);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnXoaPhieu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnThemPKK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_CTPKK);
            this.Controls.Add(this.cbo_PKK);
            this.Name = "frm_KiemKho";
            this.Text = "frm_KiemKho";
            this.Load += new System.EventHandler(this.frm_KiemKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTPKK)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_PKK;
        private System.Windows.Forms.DataGridView dgv_CTPKK;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnCapNhat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton btnThemPKK;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btnXoaPhieu;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnThemChiTiet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton btnHoanThanh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTenSP;
        private FontAwesome.Sharp.IconButton btnHuy;
        private FontAwesome.Sharp.IconButton btnLuu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GUI.textBoxCustom txtGiaTri;
        private GUI.textBoxCustom txtSL_Lech;
        private GUI.textBoxCustom txtSL_Ton;
        private GUI.textBoxCustom txtSL_ThucTe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_TONKHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_THUCTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_LECH;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIATRILECH;
        private FontAwesome.Sharp.IconButton btnXuatFile;
    }
}