namespace appWinform
{
    partial class frmNhomNguoiDung
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
            this.components = new System.ComponentModel.Container();
            this.drvThongTinNhom = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThem = new FontAwesome.Sharp.IconMenuItem();
            this.btnXoa = new FontAwesome.Sharp.IconMenuItem();
            this.btnSua = new FontAwesome.Sharp.IconMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.drvThongTinNhom)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drvThongTinNhom
            // 
            this.drvThongTinNhom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvThongTinNhom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvThongTinNhom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TenNhom,
            this.CodeGroup});
            this.drvThongTinNhom.ContextMenuStrip = this.contextMenuStrip1;
            this.drvThongTinNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drvThongTinNhom.Location = new System.Drawing.Point(0, 0);
            this.drvThongTinNhom.MultiSelect = false;
            this.drvThongTinNhom.Name = "drvThongTinNhom";
            this.drvThongTinNhom.ReadOnly = true;
            this.drvThongTinNhom.RowTemplate.Height = 24;
            this.drvThongTinNhom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvThongTinNhom.Size = new System.Drawing.Size(645, 493);
            this.drvThongTinNhom.TabIndex = 0;
            this.drvThongTinNhom.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.drvThongTinNhom_CellMouseDown);
            this.drvThongTinNhom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drvThongTinNhom_MouseDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // TenNhom
            // 
            this.TenNhom.DataPropertyName = "TEN";
            this.TenNhom.HeaderText = "Tên nhóm";
            this.TenNhom.Name = "TenNhom";
            this.TenNhom.ReadOnly = true;
            // 
            // CodeGroup
            // 
            this.CodeGroup.DataPropertyName = "CODEGR";
            this.CodeGroup.HeaderText = "Column1";
            this.CodeGroup.Name = "CodeGroup";
            this.CodeGroup.ReadOnly = true;
            this.CodeGroup.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 100);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
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
            this.btnThem.Size = new System.Drawing.Size(193, 32);
            this.btnThem.Text = "Thêm nhóm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnXoa.IconColor = System.Drawing.Color.Red;
            this.btnXoa.IconSize = 25;
            this.btnXoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rotation = 0D;
            this.btnXoa.Size = new System.Drawing.Size(193, 32);
            this.btnXoa.Text = "Xóa nhóm";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSua.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSua.IconSize = 25;
            this.btnSua.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSua.Name = "btnSua";
            this.btnSua.Rotation = 0D;
            this.btnSua.Size = new System.Drawing.Size(193, 32);
            this.btnSua.Text = "Sửa thông tin";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 493);
            this.Controls.Add(this.drvThongTinNhom);
            this.Name = "frmNhomNguoiDung";
            this.Text = "frmNhomNguoiDung";
            this.Load += new System.EventHandler(this.frmNhomNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drvThongTinNhom)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView drvThongTinNhom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FontAwesome.Sharp.IconMenuItem btnThem;
        private FontAwesome.Sharp.IconMenuItem btnXoa;
        private FontAwesome.Sharp.IconMenuItem btnSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeGroup;
    }
}