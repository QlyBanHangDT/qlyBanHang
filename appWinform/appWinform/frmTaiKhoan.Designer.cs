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
            this.frmQL_TK2 = new GUI.frmQL_TK();
            this.frmQL_TK3 = new GUI.frmQL_TK();
            this.SuspendLayout();
            // 
            // frmQL_TK2
            // 
            this.frmQL_TK2.BackColor = System.Drawing.Color.White;
            this.frmQL_TK2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmQL_TK2.Location = new System.Drawing.Point(0, 0);
            this.frmQL_TK2.Name = "frmQL_TK2";
            this.frmQL_TK2.Size = new System.Drawing.Size(868, 486);
            this.frmQL_TK2.TabIndex = 0;
            // 
            // frmQL_TK3
            // 
            this.frmQL_TK3.BackColor = System.Drawing.Color.White;
            this.frmQL_TK3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmQL_TK3.Location = new System.Drawing.Point(0, 0);
            this.frmQL_TK3.Name = "frmQL_TK3";
            this.frmQL_TK3.Size = new System.Drawing.Size(1043, 544);
            this.frmQL_TK3.TabIndex = 0;
            // 
            // frmTaiKhoan
            // 
            this.ClientSize = new System.Drawing.Size(1043, 544);
            this.Controls.Add(this.frmQL_TK3);
            this.Name = "frmTaiKhoan";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.frmQL_TK frmQL_TK1;
        private GUI.frmQL_TK frmQL_TK2;
        private GUI.frmQL_TK frmQL_TK3;
    }
}