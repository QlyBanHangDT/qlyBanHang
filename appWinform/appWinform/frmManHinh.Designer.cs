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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvManHinh = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.txtTenMH = new GUI.textBoxCustom();
            this.txtIDMH = new GUI.textBoxCustom();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManHinh)).BeginInit();
            this.SuspendLayout();
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
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThem.IconColor = System.Drawing.Color.White;
            this.btnThem.IconSize = 25;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThem.Location = new System.Drawing.Point(183, 460);
            this.btnThem.Name = "btnThem";
            this.btnThem.Rotation = 0D;
            this.btnThem.Size = new System.Drawing.Size(103, 39);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoa.Enabled = false;
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
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXoa.Location = new System.Drawing.Point(292, 460);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rotation = 0D;
            this.btnXoa.Size = new System.Drawing.Size(103, 39);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSua.Enabled = false;
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSua.IconColor = System.Drawing.Color.White;
            this.btnSua.IconSize = 25;
            this.btnSua.Location = new System.Drawing.Point(401, 460);
            this.btnSua.Name = "btnSua";
            this.btnSua.Rotation = 0D;
            this.btnSua.Size = new System.Drawing.Size(103, 39);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
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
            // frmManHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 511);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
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
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnSua;
    }
}