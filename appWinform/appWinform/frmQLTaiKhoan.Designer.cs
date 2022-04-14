namespace appWinform
{
    partial class frmQLTaiKhoan
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
            this.frmQL_TK1 = new GUI.frmQL_TK();
            this.SuspendLayout();
            // 
            // frmQL_TK1
            // 
            this.frmQL_TK1.Location = new System.Drawing.Point(12, 17);
            this.frmQL_TK1.Name = "frmQL_TK1";
            this.frmQL_TK1.Size = new System.Drawing.Size(703, 325);
            this.frmQL_TK1.TabIndex = 0;
            // 
            // frmQLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 339);
            this.Controls.Add(this.frmQL_TK1);
            this.Name = "frmQLTaiKhoan";
            this.Text = "frmQLTaiKhoan";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.frmQL_TK frmQL_TK1;
    }
}