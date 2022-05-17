namespace appWinform
{
    partial class frmNhapNCC
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
            this.txtTenNCC = new GUI.textBoxCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.BorderSize = 0;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(110, 70);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(150, 40);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextColor = System.Drawing.Color.White;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.BackColor = System.Drawing.Color.White;
            this.txtTenNCC.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtTenNCC.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTenNCC.BorderSize = 2;
            this.txtTenNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNCC.ForeColor = System.Drawing.Color.DimGray;
            this.txtTenNCC.Location = new System.Drawing.Point(145, 14);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNCC.Multiline = false;
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Padding = new System.Windows.Forms.Padding(7);
            this.txtTenNCC.PasswordChar = false;
            this.txtTenNCC.Size = new System.Drawing.Size(187, 35);
            this.txtTenNCC.TabIndex = 4;
            this.txtTenNCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenNCC.Texts = "";
            this.txtTenNCC.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhà cung cấp:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNhapNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 124);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtTenNCC);
            this.Controls.Add(this.label1);
            this.Name = "frmNhapNCC";
            this.Text = "frmNhapNCC";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.CustomButton btnXacNhan;
        private GUI.textBoxCustom txtTenNCC;
        private System.Windows.Forms.Label label1;
    }
}