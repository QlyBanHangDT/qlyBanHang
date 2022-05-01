namespace GUI
{
    partial class frmCapNhatSP
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
            this.btnCapNhat = new GUI.CustomButton();
            this.txtCapNhat = new GUI.textBoxCustom();
            this.SuspendLayout();
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhat.BackColor = System.Drawing.Color.Aqua;
            this.btnCapNhat.BackgroundColor = System.Drawing.Color.Aqua;
            this.btnCapNhat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCapNhat.BorderRadius = 10;
            this.btnCapNhat.BorderSize = 2;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(50, 55);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(135, 42);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = "customButton1";
            this.btnCapNhat.TextColor = System.Drawing.Color.White;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtCapNhat
            // 
            this.txtCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCapNhat.BackColor = System.Drawing.Color.White;
            this.txtCapNhat.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCapNhat.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtCapNhat.BorderSize = 2;
            this.txtCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapNhat.ForeColor = System.Drawing.Color.DimGray;
            this.txtCapNhat.Location = new System.Drawing.Point(13, 13);
            this.txtCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.txtCapNhat.Multiline = false;
            this.txtCapNhat.Name = "txtCapNhat";
            this.txtCapNhat.Padding = new System.Windows.Forms.Padding(7);
            this.txtCapNhat.PasswordChar = false;
            this.txtCapNhat.Size = new System.Drawing.Size(208, 35);
            this.txtCapNhat.TabIndex = 1;
            this.txtCapNhat.Texts = "";
            this.txtCapNhat.UnderlinedStyle = false;
            this.txtCapNhat._TextChanged += new System.EventHandler(this.txtCapNhat__TextChanged);
            this.txtCapNhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapNhat_KeyPress);
            // 
            // frmCapNhatSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(234, 107);
            this.Controls.Add(this.txtCapNhat);
            this.Controls.Add(this.btnCapNhat);
            this.Name = "frmCapNhatSP";
            this.Text = "frmTTSP";
            this.Load += new System.EventHandler(this.frmTTSP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton btnCapNhat;
        private textBoxCustom txtCapNhat;
    }
}