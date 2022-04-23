namespace appWinform
{
    partial class frmQLSP
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
            this.frmQL_SP1 = new GUI.FrmQL_SP();
            this.SuspendLayout();
            // 
            // frmQL_SP1
            // 
            this.frmQL_SP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmQL_SP1.Location = new System.Drawing.Point(0, 0);
            this.frmQL_SP1.Name = "frmQL_SP1";
            this.frmQL_SP1.Size = new System.Drawing.Size(813, 464);
            this.frmQL_SP1.TabIndex = 0;
            // 
            // frmQLSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 464);
            this.Controls.Add(this.frmQL_SP1);
            this.Name = "frmQLSP";
            this.Text = "frmQLSP";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.FrmQL_SP frmQL_SP1;
    }
}