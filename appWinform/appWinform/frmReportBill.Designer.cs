namespace appWinform
{
    partial class frmReportBill
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
            this.rpBill = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rpBill
            // 
            this.rpBill.ActiveViewIndex = -1;
            this.rpBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpBill.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpBill.Location = new System.Drawing.Point(0, 0);
            this.rpBill.Name = "rpBill";
            this.rpBill.Size = new System.Drawing.Size(765, 476);
            this.rpBill.TabIndex = 0;
            this.rpBill.Load += new System.EventHandler(this.rpBill_Load);
            // 
            // frmReportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 476);
            this.Controls.Add(this.rpBill);
            this.Name = "frmReportBill";
            this.Text = "frmReportBill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportBill_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpBill;
    }
}