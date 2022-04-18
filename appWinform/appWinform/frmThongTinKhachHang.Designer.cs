namespace appWinform
{
    partial class frmThongTinKhachHang
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
            this.thongTinKH3 = new GUI.ThongTinKH();
            this.SuspendLayout();
            // 
            // thongTinKH3
            // 
            this.thongTinKH3.BackColor = System.Drawing.Color.White;
            this.thongTinKH3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongTinKH3.Kh = null;
            this.thongTinKH3.Location = new System.Drawing.Point(0, 0);
            this.thongTinKH3.Name = "thongTinKH3";
            this.thongTinKH3.Size = new System.Drawing.Size(823, 593);
            this.thongTinKH3.TabIndex = 0;
            this.thongTinKH3.Load += new System.EventHandler(this.thongTinKH3_Load);
            // 
            // frmThongTinKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 593);
            this.Controls.Add(this.thongTinKH3);
            this.Name = "frmThongTinKhachHang";
            this.Text = "frmThongTinKhachHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThongTinKhachHang_FormClosing);
            this.Load += new System.EventHandler(this.frmThongTinKhachHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.ThongTinKH thongTinKH1;
        private GUI.ThongTinKH thongTinKH2;
        private GUI.ThongTinKH thongTinKH3;
    }
}