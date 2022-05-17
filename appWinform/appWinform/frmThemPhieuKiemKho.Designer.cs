namespace appWinform
{
    partial class frmThemPhieuKiemKho
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
            this.btnXacNhan = new GUI.CustomButton();
            this.txtMaPhieuKiemKho = new GUI.textBoxCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.BorderSize = 0;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(136, 68);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(150, 40);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextColor = System.Drawing.Color.White;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtMaPhieuKiemKho
            // 
            this.txtMaPhieuKiemKho.BackColor = System.Drawing.SystemColors.Control;
            this.txtMaPhieuKiemKho.BorderColor = System.Drawing.Color.Black;
            this.txtMaPhieuKiemKho.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtMaPhieuKiemKho.BorderSize = 2;
            this.txtMaPhieuKiemKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuKiemKho.ForeColor = System.Drawing.Color.DimGray;
            this.txtMaPhieuKiemKho.Location = new System.Drawing.Point(191, 8);
            this.txtMaPhieuKiemKho.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPhieuKiemKho.Multiline = false;
            this.txtMaPhieuKiemKho.Name = "txtMaPhieuKiemKho";
            this.txtMaPhieuKiemKho.Padding = new System.Windows.Forms.Padding(7);
            this.txtMaPhieuKiemKho.PasswordChar = false;
            this.txtMaPhieuKiemKho.Size = new System.Drawing.Size(188, 35);
            this.txtMaPhieuKiemKho.TabIndex = 4;
            this.txtMaPhieuKiemKho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaPhieuKiemKho.Texts = "";
            this.txtMaPhieuKiemKho.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã phiếu kiểm kho";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmThemPhieuKiemKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 130);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtMaPhieuKiemKho);
            this.Controls.Add(this.label1);
            this.Name = "frmThemPhieuKiemKho";
            this.Text = "frmThemPhieuKiemKho";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.CustomButton btnXacNhan;
        private GUI.textBoxCustom txtMaPhieuKiemKho;
        private System.Windows.Forms.Label label1;
    }
}