namespace appWinform
{
    partial class frmTaiKhoan
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
            this.frmQL_TK1.BackColor = System.Drawing.Color.White;
            this.frmQL_TK1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmQL_TK1.Location = new System.Drawing.Point(0, 0);
            this.frmQL_TK1.Name = "frmQL_TK1";
            this.frmQL_TK1.Size = new System.Drawing.Size(822, 469);
            this.frmQL_TK1.TabIndex = 0;
            // 
            // frmTaiKhoan
            // 
            this.ClientSize = new System.Drawing.Size(822, 469);
            this.Controls.Add(this.frmQL_TK1);
            this.Name = "frmTaiKhoan";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.frmQL_TK frmQL_TK;
        private GUI.frmQL_TK frmQL_TK1;
    }
}