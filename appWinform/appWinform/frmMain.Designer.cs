namespace appWinform
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemThôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânQuyềnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhómNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhómNgườiDùngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýMànHìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem,
            this.bánHàngToolStripMenuItem,
            this.kiểmTraTồnKhoToolStripMenuItem,
            this.xemThôngTinCáNhânToolStripMenuItem,
            this.phânQuyềnToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.Image = global::appWinform.Properties.Resources.Google_Noto_Emoji_Travel_Places_42554_delivery_truck;
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.nhậpHàngToolStripMenuItem.Tag = "M5";
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";
            this.nhậpHàngToolStripMenuItem.Click += new System.EventHandler(this.nhậpHàngToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýKháchHàngToolStripMenuItem,
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem,
            this.quảnLýSảnPhẩmToolStripMenuItem,
            this.toolStripSeparator1,
            this.quảnLýNhânViênToolStripMenuItem1,
            this.quảnLýNhómNgườiDùngToolStripMenuItem,
            this.quảnLýNhómNgườiDùngToolStripMenuItem1,
            this.quảnLýMànHìnhToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.thoátToolStripMenuItem.Tag = "";
            this.thoátToolStripMenuItem.Text = "Đăng xuất";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // bánHàngToolStripMenuItem
            // 
            this.bánHàngToolStripMenuItem.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Flatastic_4_Add_item;
            this.bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            this.bánHàngToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.bánHàngToolStripMenuItem.Tag = "M6";
            this.bánHàngToolStripMenuItem.Text = "Bán hàng";
            this.bánHàngToolStripMenuItem.Click += new System.EventHandler(this.bánHàngToolStripMenuItem_Click);
            // 
            // kiểmTraTồnKhoToolStripMenuItem
            // 
            this.kiểmTraTồnKhoToolStripMenuItem.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Flatastic_4_Inventory_maintenance;
            this.kiểmTraTồnKhoToolStripMenuItem.Name = "kiểmTraTồnKhoToolStripMenuItem";
            this.kiểmTraTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.kiểmTraTồnKhoToolStripMenuItem.Tag = "M8";
            this.kiểmTraTồnKhoToolStripMenuItem.Text = "Kiểm tra tồn kho";
            this.kiểmTraTồnKhoToolStripMenuItem.Click += new System.EventHandler(this.kiểmTraTồnKhoToolStripMenuItem_Click);
            // 
            // xemThôngTinCáNhânToolStripMenuItem
            // 
            this.xemThôngTinCáNhânToolStripMenuItem.Image = global::appWinform.Properties.Resources.Hopstarter_Rounded_Square_Folder_Profiles;
            this.xemThôngTinCáNhânToolStripMenuItem.Name = "xemThôngTinCáNhânToolStripMenuItem";
            this.xemThôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.xemThôngTinCáNhânToolStripMenuItem.Tag = "M7";
            this.xemThôngTinCáNhânToolStripMenuItem.Text = "Xem thông tin cá nhân";
            this.xemThôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.xemThôngTinCáNhânToolStripMenuItem_Click);
            // 
            // phânQuyềnToolStripMenuItem
            // 
            this.phânQuyềnToolStripMenuItem.Image = global::appWinform.Properties.Resources.Vexels_Office_Rules;
            this.phânQuyềnToolStripMenuItem.Name = "phânQuyềnToolStripMenuItem";
            this.phânQuyềnToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.phânQuyềnToolStripMenuItem.Tag = "M9";
            this.phânQuyềnToolStripMenuItem.Text = "Phân quyền";
            this.phânQuyềnToolStripMenuItem.Click += new System.EventHandler(this.phânQuyềnToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Pretty_Office_8_Users;
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.quảnLýKháchHàngToolStripMenuItem.Tag = "M1";
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // phânTíchBìnhLuậnKháchHàngToolStripMenuItem
            // 
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Pretty_Office_9_Comment_edit;
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem.Name = "phânTíchBìnhLuậnKháchHàngToolStripMenuItem";
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem.Tag = "MML";
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem.Text = "Phân tích bình luận khách hàng";
            this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.phânTíchBìnhLuậnKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Flatastic_2_Product;
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.quảnLýSảnPhẩmToolStripMenuItem.Tag = "M2";
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem1
            // 
            this.quảnLýNhânViênToolStripMenuItem1.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Pretty_Office_2_Man;
            this.quảnLýNhânViênToolStripMenuItem1.Name = "quảnLýNhânViênToolStripMenuItem1";
            this.quảnLýNhânViênToolStripMenuItem1.Size = new System.Drawing.Size(282, 24);
            this.quảnLýNhânViênToolStripMenuItem1.Tag = "M3";
            this.quảnLýNhânViênToolStripMenuItem1.Text = "Quản lý tài khoản";
            this.quảnLýNhânViênToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem1_Click);
            // 
            // quảnLýNhómNgườiDùngToolStripMenuItem
            // 
            this.quảnLýNhómNgườiDùngToolStripMenuItem.Image = global::appWinform.Properties.Resources.Blackvariant_Button_Ui_System_Folders_Drives_Group;
            this.quảnLýNhómNgườiDùngToolStripMenuItem.Name = "quảnLýNhómNgườiDùngToolStripMenuItem";
            this.quảnLýNhómNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.quảnLýNhómNgườiDùngToolStripMenuItem.Tag = "M10";
            this.quảnLýNhómNgườiDùngToolStripMenuItem.Text = "Quản lý nhóm người dùng";
            this.quảnLýNhómNgườiDùngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhómNgườiDùngToolStripMenuItem_Click);
            // 
            // quảnLýNhómNgườiDùngToolStripMenuItem1
            // 
            this.quảnLýNhómNgườiDùngToolStripMenuItem1.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Flatastic_4_Male_user_add;
            this.quảnLýNhómNgườiDùngToolStripMenuItem1.Name = "quảnLýNhómNgườiDùngToolStripMenuItem1";
            this.quảnLýNhómNgườiDùngToolStripMenuItem1.Size = new System.Drawing.Size(282, 24);
            this.quảnLýNhómNgườiDùngToolStripMenuItem1.Tag = "M11";
            this.quảnLýNhómNgườiDùngToolStripMenuItem1.Text = "Thêm người dùng vào nhóm";
            this.quảnLýNhómNgườiDùngToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýNhómNgườiDùngToolStripMenuItem1_Click);
            // 
            // quảnLýMànHìnhToolStripMenuItem
            // 
            this.quảnLýMànHìnhToolStripMenuItem.Image = global::appWinform.Properties.Resources.Custom_Icon_Design_Flatastic_11_Monitor;
            this.quảnLýMànHìnhToolStripMenuItem.Name = "quảnLýMànHìnhToolStripMenuItem";
            this.quảnLýMànHìnhToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            this.quảnLýMànHìnhToolStripMenuItem.Tag = "MMH";
            this.quảnLýMànHìnhToolStripMenuItem.Text = "Quản lý màn hình";
            this.quảnLýMànHìnhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýMànHìnhToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 478);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiểmTraTồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemThôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem phânQuyềnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhómNgườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhómNgườiDùngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýMànHìnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phânTíchBìnhLuậnKháchHàngToolStripMenuItem;
    }
}