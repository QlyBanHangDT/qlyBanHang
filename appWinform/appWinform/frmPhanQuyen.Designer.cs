namespace appWinform
{
    partial class frmPhanQuyen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drvNhomNguoiDung = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.ID_PQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoQuyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            this.ckAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drvNhomNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drvPhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drvNhomNguoiDung);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 503);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhóm người dùng";
            // 
            // drvNhomNguoiDung
            // 
            this.drvNhomNguoiDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvNhomNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvNhomNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TenNhom,
            this.Column1});
            this.drvNhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drvNhomNguoiDung.Location = new System.Drawing.Point(3, 23);
            this.drvNhomNguoiDung.Name = "drvNhomNguoiDung";
            this.drvNhomNguoiDung.ReadOnly = true;
            this.drvNhomNguoiDung.RowTemplate.Height = 24;
            this.drvNhomNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvNhomNguoiDung.Size = new System.Drawing.Size(320, 477);
            this.drvNhomNguoiDung.TabIndex = 0;
            this.drvNhomNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drvNhomNguoiDung_CellClick);
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
            // Column1
            // 
            this.Column1.DataPropertyName = "CODEGR";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // drvPhanQuyen
            // 
            this.drvPhanQuyen.AllowUserToAddRows = false;
            this.drvPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drvPhanQuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_PQ,
            this.TenMH,
            this.CoQuyen});
            this.drvPhanQuyen.Location = new System.Drawing.Point(329, 12);
            this.drvPhanQuyen.Name = "drvPhanQuyen";
            this.drvPhanQuyen.RowTemplate.Height = 24;
            this.drvPhanQuyen.Size = new System.Drawing.Size(588, 428);
            this.drvPhanQuyen.TabIndex = 1;
            this.drvPhanQuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drvPhanQuyen_CellContentClick);
            // 
            // ID_PQ
            // 
            this.ID_PQ.DataPropertyName = "ID";
            this.ID_PQ.HeaderText = "ID";
            this.ID_PQ.Name = "ID_PQ";
            // 
            // TenMH
            // 
            this.TenMH.DataPropertyName = "TENMH";
            this.TenMH.HeaderText = "Màn hình";
            this.TenMH.Name = "TenMH";
            // 
            // CoQuyen
            // 
            this.CoQuyen.DataPropertyName = "COQUYEN";
            this.CoQuyen.HeaderText = "Quyền";
            this.CoQuyen.Name = "CoQuyen";
            this.CoQuyen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CoQuyen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnLuu.IconColor = System.Drawing.Color.White;
            this.btnLuu.IconSize = 25;
            this.btnLuu.Location = new System.Drawing.Point(802, 446);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Rotation = 0D;
            this.btnLuu.Size = new System.Drawing.Size(115, 45);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // ckAll
            // 
            this.ckAll.AutoSize = true;
            this.ckAll.Location = new System.Drawing.Point(816, 17);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(18, 17);
            this.ckAll.TabIndex = 3;
            this.ckAll.UseVisualStyleBackColor = true;
            this.ckAll.Click += new System.EventHandler(this.ckAll_Click);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(929, 503);
            this.Controls.Add(this.ckAll);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.drvPhanQuyen);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPhanQuyen";
            this.Text = "frmPhanQuyen";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drvNhomNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drvPhanQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView drvPhanQuyen;
        private FontAwesome.Sharp.IconButton btnLuu;
        private System.Windows.Forms.DataGridView drvNhomNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_PQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CoQuyen;
        private System.Windows.Forms.CheckBox ckAll;
    }
}