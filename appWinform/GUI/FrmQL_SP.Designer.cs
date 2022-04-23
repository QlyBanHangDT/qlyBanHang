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
            this.dataGridView_QLSP = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThem = new FontAwesome.Sharp.IconMenuItem();
            this.btnCapNhatGia = new FontAwesome.Sharp.IconMenuItem();
            this.btnChangeName = new FontAwesome.Sharp.IconMenuItem();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QLSP)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.Column1,
            this.Column4,
            this.SoLuong,
            this.Column2,
            this.TenHang,
            this.TenLoai,
            this.TenDanhMuc});
            this.dataGridView_QLSP.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_QLSP.Location = new System.Drawing.Point(3, 84);
            this.dataGridView_QLSP.Name = "dataGridView_QLSP";
            this.dataGridView_QLSP.ReadOnly = true;
            this.dataGridView_QLSP.RowTemplate.Height = 24;
            this.dataGridView_QLSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_QLSP.Size = new System.Drawing.Size(826, 393);
            this.dataGridView_QLSP.TabIndex = 0;
            this.dataGridView_QLSP.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_QLSP_CellMouseDown);
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
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.DataPropertyName = "TENDANHMUC";
            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TENLOAI";
            this.TenLoai.HeaderText = "Loại";
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.ReadOnly = true;
            // 
            // TenHang
            // 
            this.TenHang.DataPropertyName = "TENHANG";
            this.TenHang.HeaderText = "Hãng";
            this.TenHang.Name = "TenHang";
            this.TenHang.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "GIA";
            this.Column2.HeaderText = "Giá";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SOLUONG";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TENSP";
            this.Column4.HeaderText = "Tên sản phẩm";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // FrmQL_SP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_QLSP);
            this.Name = "FrmQL_SP";
            this.Size = new System.Drawing.Size(832, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QLSP)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_QLSP;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FontAwesome.Sharp.IconMenuItem btnThem;
        private FontAwesome.Sharp.IconMenuItem btnCapNhatGia;
        private FontAwesome.Sharp.IconMenuItem btnChangeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
    }
}
