namespace appWinform
{
    partial class frmPhanTichBinhLuan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // chartThongKe
            // 
            chartArea2.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend2);
            this.chartThongKe.Location = new System.Drawing.Point(12, 65);
            this.chartThongKe.Name = "chartThongKe";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "ThongKe";
            this.chartThongKe.Series.Add(series2);
            this.chartThongKe.Size = new System.Drawing.Size(673, 519);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "Mức độ ưu thích";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "PhanHoi";
            title2.Text = "Phản hồi của khách hàng";
            title2.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow;
            this.chartThongKe.Titles.Add(title2);
            // 
            // cboSanPham
            // 
            this.cboSanPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSanPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(117, 12);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(462, 37);
            this.cboSanPham.TabIndex = 1;
            this.cboSanPham.SelectedIndexChanged += new System.EventHandler(this.cboSanPham_SelectedIndexChanged);
            // 
            // frmPhanTichBinhLuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 596);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.chartThongKe);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(715, 643);
            this.MinimumSize = new System.Drawing.Size(715, 643);
            this.Name = "frmPhanTichBinhLuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPhanTichBinhLuan";
            this.Load += new System.EventHandler(this.frmPhanTichBinhLuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.ComboBox cboSanPham;
    }
}