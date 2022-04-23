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
            this.frmQL_TK = new GUI.frmQL_TK();
            this.SuspendLayout();
            // 
            // frmQL_TK
            // 
            this.frmQL_TK.BackColor = System.Drawing.Color.White;
            this.frmQL_TK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmQL_TK.Location = new System.Drawing.Point(0, 0);
            this.frmQL_TK.Name = "frmQL_TK";
            this.frmQL_TK.Size = new System.Drawing.Size(894, 483);
            this.frmQL_TK.TabIndex = 0;
            // 
            // frmTaiKhoan
            // 
            this.ClientSize = new System.Drawing.Size(894, 483);
            this.Controls.Add(this.frmQL_TK);
            this.Name = "frmTaiKhoan";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.frmQL_TK frmQL_TK;
    }
}