﻿namespace appWinform
{
    partial class frmKhachHang
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
            this.frmQL_KH1 = new GUI.frmQL_KH();
            this.SuspendLayout();
            // 
            // frmQL_KH1
            // 
            this.frmQL_KH1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmQL_KH1.Location = new System.Drawing.Point(0, 0);
            this.frmQL_KH1.Name = "frmQL_KH1";
            this.frmQL_KH1.Size = new System.Drawing.Size(860, 455);
            this.frmQL_KH1.TabIndex = 0;
            this.frmQL_KH1.SelectedRow += new System.EventHandler(this.frmQL_KH1_SelectedRow);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 455);
            this.Controls.Add(this.frmQL_KH1);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.frmQL_KH frmQL_KH1;

        public GUI.frmQL_KH frmQL_KHa { get; set; }
    }
}