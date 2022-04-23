namespace appWinform
{
    partial class frmThongTinNhom
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNhom = new GUI.textBoxCustom();
            this.btnXacNhan = new GUI.CustomButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nhóm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.BackColor = System.Drawing.Color.White;
            this.txtTenNhom.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtTenNhom.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTenNhom.BorderSize = 2;
            this.txtTenNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhom.ForeColor = System.Drawing.Color.DimGray;
            this.txtTenNhom.Location = new System.Drawing.Point(119, 38);
            this.txtTenNhom.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNhom.Multiline = false;
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Padding = new System.Windows.Forms.Padding(7);
            this.txtTenNhom.PasswordChar = false;
            this.txtTenNhom.Size = new System.Drawing.Size(188, 35);
            this.txtTenNhom.TabIndex = 1;
            this.txtTenNhom.Texts = "";
            this.txtTenNhom.UnderlinedStyle = true;
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
            this.btnXacNhan.Location = new System.Drawing.Point(93, 93);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(150, 40);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextColor = System.Drawing.Color.White;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // frmThongTinNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 145);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtTenNhom);
            this.Controls.Add(this.label1);
            this.Name = "frmThongTinNhom";
            this.Text = "frmThongTinNhom";
            this.Load += new System.EventHandler(this.frmThongTinNhom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private GUI.textBoxCustom txtTenNhom;
        private GUI.CustomButton btnXacNhan;
    }
}