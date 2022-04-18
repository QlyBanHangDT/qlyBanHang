namespace GUI
{
    partial class frmQL_KH
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
            this.dgrvKH = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKh = new GUI.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKH)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvKH
            // 
            this.dgrvKH.AllowUserToAddRows = false;
            this.dgrvKH.AllowUserToDeleteRows = false;
            this.dgrvKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrvKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clHoTen,
            this.clSDT,
            this.clDTL,
            this.clTDG});
            this.dgrvKH.Location = new System.Drawing.Point(0, 115);
            this.dgrvKH.MultiSelect = false;
            this.dgrvKH.Name = "dgrvKH";
            this.dgrvKH.ReadOnly = true;
            this.dgrvKH.RowTemplate.Height = 24;
            this.dgrvKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrvKH.Size = new System.Drawing.Size(792, 412);
            this.dgrvKH.TabIndex = 0;
            this.dgrvKH.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvKH_CellContentDoubleClick);
            // 
            // clID
            // 
            this.clID.DataPropertyName = "ID";
            this.clID.HeaderText = "ID";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            // 
            // clHoTen
            // 
            this.clHoTen.DataPropertyName = "HOTEN";
            this.clHoTen.HeaderText = "HỌ TÊN";
            this.clHoTen.Name = "clHoTen";
            this.clHoTen.ReadOnly = true;
            // 
            // clSDT
            // 
            this.clSDT.DataPropertyName = "SDT";
            this.clSDT.HeaderText = "SDT";
            this.clSDT.Name = "clSDT";
            this.clSDT.ReadOnly = true;
            // 
            // clDTL
            // 
            this.clDTL.DataPropertyName = "DIEMTICHLUY";
            this.clDTL.HeaderText = "ĐIỂM TÍCH LŨY";
            this.clDTL.Name = "clDTL";
            this.clDTL.ReadOnly = true;
            // 
            // clTDG
            // 
            this.clTDG.DataPropertyName = "TONGDONGIA";
            this.clTDG.HeaderText = "TỔNG ĐƠN GIÁ";
            this.clTDG.Name = "clTDG";
            this.clTDG.ReadOnly = true;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 100);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnTimKh);
            this.panel1.Controls.Add(this.txtFind);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 94);
            this.panel1.TabIndex = 0;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(120, 36);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(207, 22);
            this.txtFind.TabIndex = 6;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
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
            // btnTimKh
            // 
            this.btnTimKh.BackColor = System.Drawing.Color.White;
            this.btnTimKh.BackgroundColor = System.Drawing.Color.White;
            this.btnTimKh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTimKh.BorderRadius = 0;
            this.btnTimKh.BorderSize = 0;
            this.btnTimKh.FlatAppearance.BorderSize = 0;
            this.btnTimKh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKh.ForeColor = System.Drawing.Color.White;
            this.btnTimKh.Image = global::GUI.Properties.Resources.Start_Menu_Search_icon;
            this.btnTimKh.Location = new System.Drawing.Point(333, 25);
            this.btnTimKh.Name = "btnTimKh";
            this.btnTimKh.Size = new System.Drawing.Size(40, 38);
            this.btnTimKh.TabIndex = 7;
            this.btnTimKh.TextColor = System.Drawing.Color.White;
            this.btnTimKh.UseVisualStyleBackColor = false;
            this.btnTimKh.Click += new System.EventHandler(this.btnTimKH_Click);
            // 
            // frmQL_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgrvKH);
            this.Name = "frmQL_KH";
            this.Size = new System.Drawing.Size(792, 527);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKH)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvKH;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTDG;
        private CustomButton btnTimKh;
    }
}
