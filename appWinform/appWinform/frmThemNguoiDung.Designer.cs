namespace appWinform
{
    partial class frmThemNguoiDung
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
            this.drvTK = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drvNhom = new System.Windows.Forms.DataGridView();
            this.cbNhoms = new System.Windows.Forms.ComboBox();
            this.btnAddOne = new FontAwesome.Sharp.IconButton();
            this.btnAddAll = new FontAwesome.Sharp.IconButton();
            this.btnDelAll = new FontAwesome.Sharp.IconButton();
            this.btnDelOne = new FontAwesome.Sharp.IconButton();
            this.btnRefesh = new FontAwesome.Sharp.IconButton();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdGr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_grA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTK_grA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username_grA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_grA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_grA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pw_nnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drvTK)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drvNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drvTK);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 456);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Người dùng";
            // 
            // drvTK
            // 
            this.drvTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvTK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ID,
            this.Username,
            this.Ten,
            this.IdGr,
            this.pw});
            this.drvTK.Location = new System.Drawing.Point(6, 21);
            this.drvTK.Name = "drvTK";
            this.drvTK.ReadOnly = true;
            this.drvTK.RowTemplate.Height = 24;
            this.drvTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvTK.Size = new System.Drawing.Size(405, 429);
            this.drvTK.TabIndex = 0;
            this.drvTK.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.drvTK_RowPostPaint);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.drvNhom);
            this.groupBox2.Location = new System.Drawing.Point(513, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 456);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhóm người dùng";
            // 
            // drvNhom
            // 
            this.drvNhom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.drvNhom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvNhom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No_grA,
            this.IDTK_grA,
            this.Username_grA,
            this.Ten_grA,
            this.Id_grA,
            this.Pw_nnd});
            this.drvNhom.Location = new System.Drawing.Point(6, 21);
            this.drvNhom.Name = "drvNhom";
            this.drvNhom.ReadOnly = true;
            this.drvNhom.RowTemplate.Height = 24;
            this.drvNhom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvNhom.Size = new System.Drawing.Size(405, 429);
            this.drvNhom.TabIndex = 1;
            this.drvNhom.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.drvNhom_RowPostPaint);
            // 
            // cbNhoms
            // 
            this.cbNhoms.FormattingEnabled = true;
            this.cbNhoms.Location = new System.Drawing.Point(519, 30);
            this.cbNhoms.Name = "cbNhoms";
            this.cbNhoms.Size = new System.Drawing.Size(185, 24);
            this.cbNhoms.TabIndex = 2;
            this.cbNhoms.SelectedIndexChanged += new System.EventHandler(this.cbNhoms_SelectedIndexChanged);
            // 
            // btnAddOne
            // 
            this.btnAddOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOne.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAddOne.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            this.btnAddOne.IconColor = System.Drawing.Color.Black;
            this.btnAddOne.IconSize = 20;
            this.btnAddOne.Location = new System.Drawing.Point(444, 147);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Rotation = 0D;
            this.btnAddOne.Size = new System.Drawing.Size(54, 47);
            this.btnAddOne.TabIndex = 3;
            this.btnAddOne.UseVisualStyleBackColor = true;
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAddAll.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnAddAll.IconColor = System.Drawing.Color.Black;
            this.btnAddAll.IconSize = 20;
            this.btnAddAll.Location = new System.Drawing.Point(444, 199);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Rotation = 0D;
            this.btnAddAll.Size = new System.Drawing.Size(54, 47);
            this.btnAddAll.TabIndex = 4;
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelAll.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDelAll.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnDelAll.IconColor = System.Drawing.Color.Black;
            this.btnDelAll.IconSize = 20;
            this.btnDelAll.Location = new System.Drawing.Point(444, 402);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Rotation = 0D;
            this.btnDelAll.Size = new System.Drawing.Size(54, 47);
            this.btnDelAll.TabIndex = 6;
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // btnDelOne
            // 
            this.btnDelOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelOne.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDelOne.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.btnDelOne.IconColor = System.Drawing.Color.Black;
            this.btnDelOne.IconSize = 20;
            this.btnDelOne.Location = new System.Drawing.Point(444, 350);
            this.btnDelOne.Name = "btnDelOne";
            this.btnDelOne.Rotation = 0D;
            this.btnDelOne.Size = new System.Drawing.Size(54, 47);
            this.btnDelOne.TabIndex = 5;
            this.btnDelOne.UseVisualStyleBackColor = true;
            this.btnDelOne.Click += new System.EventHandler(this.btnDelOne_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefesh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRefesh.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnRefesh.IconColor = System.Drawing.Color.Black;
            this.btnRefesh.IconSize = 20;
            this.btnRefesh.Location = new System.Drawing.Point(444, 272);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Rotation = 0D;
            this.btnRefesh.Size = new System.Drawing.Size(54, 47);
            this.btnRefesh.TabIndex = 4;
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "IdTK";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Ten
            // 
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Ten";
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            this.Ten.Visible = false;
            // 
            // IdGr
            // 
            this.IdGr.DataPropertyName = "IdGr";
            this.IdGr.HeaderText = "IdGr";
            this.IdGr.Name = "IdGr";
            this.IdGr.ReadOnly = true;
            this.IdGr.Visible = false;
            // 
            // pw
            // 
            this.pw.DataPropertyName = "Pw";
            this.pw.HeaderText = "Pw";
            this.pw.Name = "pw";
            this.pw.ReadOnly = true;
            this.pw.Visible = false;
            // 
            // No_grA
            // 
            this.No_grA.HeaderText = "No";
            this.No_grA.Name = "No_grA";
            this.No_grA.ReadOnly = true;
            // 
            // IDTK_grA
            // 
            this.IDTK_grA.DataPropertyName = "IdTK";
            this.IDTK_grA.HeaderText = "ID";
            this.IDTK_grA.Name = "IDTK_grA";
            this.IDTK_grA.ReadOnly = true;
            // 
            // Username_grA
            // 
            this.Username_grA.DataPropertyName = "Username";
            this.Username_grA.HeaderText = "Username";
            this.Username_grA.Name = "Username_grA";
            this.Username_grA.ReadOnly = true;
            // 
            // Ten_grA
            // 
            this.Ten_grA.DataPropertyName = "Ten";
            this.Ten_grA.HeaderText = "Ten";
            this.Ten_grA.Name = "Ten_grA";
            this.Ten_grA.ReadOnly = true;
            this.Ten_grA.Visible = false;
            // 
            // Id_grA
            // 
            this.Id_grA.DataPropertyName = "IdGr";
            this.Id_grA.HeaderText = "IDGR";
            this.Id_grA.Name = "Id_grA";
            this.Id_grA.ReadOnly = true;
            this.Id_grA.Visible = false;
            // 
            // Pw_nnd
            // 
            this.Pw_nnd.DataPropertyName = "Pw";
            this.Pw_nnd.HeaderText = "Pw";
            this.Pw_nnd.Name = "Pw_nnd";
            this.Pw_nnd.ReadOnly = true;
            this.Pw_nnd.Visible = false;
            // 
            // frmThemNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 528);
            this.Controls.Add(this.btnDelAll);
            this.Controls.Add(this.btnDelOne);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAddOne);
            this.Controls.Add(this.cbNhoms);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThemNguoiDung";
            this.Text = "frmNhomNguoiDung";
            this.Load += new System.EventHandler(this.frmNhomNguoiDung_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drvTK)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drvNhom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView drvTK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbNhoms;
        private System.Windows.Forms.DataGridView drvNhom;
        private FontAwesome.Sharp.IconButton btnAddOne;
        private FontAwesome.Sharp.IconButton btnAddAll;
        private FontAwesome.Sharp.IconButton btnDelAll;
        private FontAwesome.Sharp.IconButton btnDelOne;
        private FontAwesome.Sharp.IconButton btnRefesh;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGr;
        private System.Windows.Forms.DataGridViewTextBoxColumn pw;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_grA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTK_grA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username_grA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_grA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_grA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pw_nnd;
    }
}