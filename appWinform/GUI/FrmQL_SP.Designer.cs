namespace GUI
{
    partial class FrmQL_SP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQL_SP));
            this.dataGridView_QLSP = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThem = new FontAwesome.Sharp.IconMenuItem();
            this.btnCapNhatGia = new FontAwesome.Sharp.IconMenuItem();
            this.btnChangeName = new FontAwesome.Sharp.IconMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimSP = new GUI.CustomButton();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QLSP)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_QLSP
            // 
            this.dataGridView_QLSP.AllowUserToAddRows = false;
            this.dataGridView_QLSP.AllowUserToDeleteRows = false;
            this.dataGridView_QLSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_QLSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_QLSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_QLSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TenSP,
            this.SoLuong,
            this.Gia,
            this.TenHang,
            this.TenLoai,
            this.TenDanhMuc});
            this.dataGridView_QLSP.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_QLSP.Location = new System.Drawing.Point(3, 106);
            this.dataGridView_QLSP.Name = "dataGridView_QLSP";
            this.dataGridView_QLSP.ReadOnly = true;
            this.dataGridView_QLSP.RowTemplate.Height = 24;
            this.dataGridView_QLSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_QLSP.Size = new System.Drawing.Size(826, 371);
            this.dataGridView_QLSP.TabIndex = 0;
            this.dataGridView_QLSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_QLSP_CellClick);
            this.dataGridView_QLSP.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_QLSP_CellMouseDown);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ID";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TENSP";
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SOLUONG";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "GIA";
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            // 
            // TenHang
            // 
            this.TenHang.DataPropertyName = "TENHANG";
            this.TenHang.HeaderText = "Hãng";
            this.TenHang.Name = "TenHang";
            this.TenHang.ReadOnly = true;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TENLOAI";
            this.TenLoai.HeaderText = "Loại";
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.ReadOnly = true;
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.DataPropertyName = "TENDANHMUC";
            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnCapNhatGia,
            this.btnChangeName});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 100);
            // 
            // btnThem
            // 
            this.btnThem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThem.IconColor = System.Drawing.Color.Lime;
            this.btnThem.IconSize = 25;
            this.btnThem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnThem.Name = "btnThem";
            this.btnThem.Rotation = 0D;
            this.btnThem.Size = new System.Drawing.Size(212, 32);
            this.btnThem.Text = "Thêm sản phẩm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhatGia
            // 
            this.btnCapNhatGia.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCapNhatGia.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            this.btnCapNhatGia.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCapNhatGia.IconSize = 25;
            this.btnCapNhatGia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCapNhatGia.Name = "btnCapNhatGia";
            this.btnCapNhatGia.Rotation = 0D;
            this.btnCapNhatGia.Size = new System.Drawing.Size(212, 32);
            this.btnCapNhatGia.Text = "Cập nhật số giá";
            this.btnCapNhatGia.Click += new System.EventHandler(this.btnCapNhatGia_Click);
            // 
            // btnChangeName
            // 
            this.btnChangeName.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnChangeName.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnChangeName.IconColor = System.Drawing.Color.Blue;
            this.btnChangeName.IconSize = 25;
            this.btnChangeName.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Rotation = 0D;
            this.btnChangeName.Size = new System.Drawing.Size(212, 32);
            this.btnChangeName.Text = "Thay đổi tên";
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 100);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnTimSP);
            this.panel1.Controls.Add(this.txtFind);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(221, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 94);
            this.panel1.TabIndex = 0;
            // 
            // btnTimSP
            // 
            this.btnTimSP.BackColor = System.Drawing.Color.White;
            this.btnTimSP.BackgroundColor = System.Drawing.Color.White;
            this.btnTimSP.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTimSP.BorderRadius = 0;
            this.btnTimSP.BorderSize = 0;
            this.btnTimSP.FlatAppearance.BorderSize = 0;
            this.btnTimSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimSP.ForeColor = System.Drawing.Color.White;
            this.btnTimSP.Image = ((System.Drawing.Image)(resources.GetObject("btnTimSP.Image")));
            this.btnTimSP.Location = new System.Drawing.Point(333, 25);
            this.btnTimSP.Name = "btnTimSP";
            this.btnTimSP.Size = new System.Drawing.Size(40, 38);
            this.btnTimSP.TabIndex = 7;
            this.btnTimSP.TextColor = System.Drawing.Color.White;
            this.btnTimSP.UseVisualStyleBackColor = false;
            this.btnTimSP.Click += new System.EventHandler(this.btnTimSP_Click);
            // 
            // txtFind
            // 
            this.txtFind.BackColor = System.Drawing.Color.White;
            this.txtFind.Location = new System.Drawing.Point(120, 36);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(207, 22);
            this.txtFind.TabIndex = 6;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm kiếm";
            // 
            // FrmQL_SP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView_QLSP);
            this.Name = "FrmQL_SP";
            this.Size = new System.Drawing.Size(832, 480);
            this.Load += new System.EventHandler(this.FrmQL_SP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QLSP)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_QLSP;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FontAwesome.Sharp.IconMenuItem btnThem;
        private FontAwesome.Sharp.IconMenuItem btnCapNhatGia;
        private FontAwesome.Sharp.IconMenuItem btnChangeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CustomButton btnTimSP;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
    }
}
