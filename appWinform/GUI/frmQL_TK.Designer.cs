namespace GUI
{
    partial class frmQL_TK
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
            this.dataGridView_TaiKhoan = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clID_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckHD = new System.Windows.Forms.CheckBox();
            this.txtP = new GUI.textBoxCustom();
            this.txtU = new GUI.textBoxCustom();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TaiKhoan)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_TaiKhoan
            // 
            this.dataGridView_TaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_TaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clU,
            this.clPW,
            this.clHD,
            this.clID_gr});
            this.dataGridView_TaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TaiKhoan.Name = "dataGridView_TaiKhoan";
            this.dataGridView_TaiKhoan.ReadOnly = true;
            this.dataGridView_TaiKhoan.RowTemplate.Height = 24;
            this.dataGridView_TaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_TaiKhoan.Size = new System.Drawing.Size(894, 395);
            this.dataGridView_TaiKhoan.TabIndex = 0;
            this.dataGridView_TaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_TaiKhoan_CellClick);
            // 
            // clID
            // 
            this.clID.DataPropertyName = "ID";
            this.clID.HeaderText = "ID";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            // 
            // clU
            // 
            this.clU.DataPropertyName = "USERNAME";
            this.clU.HeaderText = "USERNAME";
            this.clU.Name = "clU";
            this.clU.ReadOnly = true;
            // 
            // clPW
            // 
            this.clPW.DataPropertyName = "PW";
            this.clPW.HeaderText = "PASSWORD";
            this.clPW.Name = "clPW";
            this.clPW.ReadOnly = true;
            // 
            // clHD
            // 
            this.clHD.DataPropertyName = "HOATDONG";
            this.clHD.HeaderText = "Hoạt động";
            this.clHD.Name = "clHD";
            this.clHD.ReadOnly = true;
            // 
            // clID_gr
            // 
            this.clID_gr.DataPropertyName = "ID_GR";
            this.clID_gr.HeaderText = "ID_GR";
            this.clID_gr.Name = "clID_gr";
            this.clID_gr.ReadOnly = true;
            this.clID_gr.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnThem.Location = new System.Drawing.Point(17, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Rotation = 0D;
            this.btnThem.Size = new System.Drawing.Size(103, 39);
            this.btnThem.TabIndex = 6;
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
            this.btnXoa.Location = new System.Drawing.Point(126, 7);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rotation = 0D;
            this.btnXoa.Size = new System.Drawing.Size(103, 39);
            this.btnXoa.TabIndex = 7;
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
            this.btnSua.Location = new System.Drawing.Point(235, 7);
            this.btnSua.Name = "btnSua";
            this.btnSua.Rotation = 0D;
            this.btnSua.Size = new System.Drawing.Size(103, 39);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.04819F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.95181F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 398);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 134);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(467, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 128);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckHD);
            this.panel2.Controls.Add(this.txtP);
            this.panel2.Controls.Add(this.txtU);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(458, 128);
            this.panel2.TabIndex = 1;
            // 
            // ckHD
            // 
            this.ckHD.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ckHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckHD.ForeColor = System.Drawing.Color.Black;
            this.ckHD.Location = new System.Drawing.Point(311, 37);
            this.ckHD.Name = "ckHD";
            this.ckHD.Size = new System.Drawing.Size(98, 48);
            this.ckHD.TabIndex = 12;
            this.ckHD.Text = "Hoạt động";
            this.ckHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckHD.UseVisualStyleBackColor = true;
            // 
            // txtP
            // 
            this.txtP.BackColor = System.Drawing.Color.White;
            this.txtP.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtP.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtP.BorderSize = 2;
            this.txtP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP.ForeColor = System.Drawing.Color.DimGray;
            this.txtP.Location = new System.Drawing.Point(104, 50);
            this.txtP.Margin = new System.Windows.Forms.Padding(4);
            this.txtP.Multiline = false;
            this.txtP.Name = "txtP";
            this.txtP.Padding = new System.Windows.Forms.Padding(7);
            this.txtP.PasswordChar = true;
            this.txtP.Size = new System.Drawing.Size(197, 35);
            this.txtP.TabIndex = 11;
            this.txtP.Texts = "";
            this.txtP.UnderlinedStyle = true;
            // 
            // txtU
            // 
            this.txtU.BackColor = System.Drawing.Color.White;
            this.txtU.BorderColor = System.Drawing.Color.DimGray;
            this.txtU.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtU.BorderSize = 2;
            this.txtU.Enabled = false;
            this.txtU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtU.ForeColor = System.Drawing.Color.DimGray;
            this.txtU.Location = new System.Drawing.Point(104, 7);
            this.txtU.Margin = new System.Windows.Forms.Padding(4);
            this.txtU.Multiline = false;
            this.txtU.Name = "txtU";
            this.txtU.Padding = new System.Windows.Forms.Padding(7);
            this.txtU.PasswordChar = false;
            this.txtU.Size = new System.Drawing.Size(197, 35);
            this.txtU.TabIndex = 10;
            this.txtU.Texts = "";
            this.txtU.UnderlinedStyle = true;
            // 
            // frmQL_TK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView_TaiKhoan);
            this.Name = "frmQL_TK";
            this.Size = new System.Drawing.Size(894, 532);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TaiKhoan)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_TaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPW;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID_gr;
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnSua;
        private textBoxCustom txtU;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private textBoxCustom txtP;
        private System.Windows.Forms.CheckBox ckHD;
    }
}
