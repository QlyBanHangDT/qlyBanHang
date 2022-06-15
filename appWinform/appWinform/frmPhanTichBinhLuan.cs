using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace appWinform
{
    public partial class frmPhanTichBinhLuan : Form
    {
        public frmPhanTichBinhLuan()
        {
            InitializeComponent();
        }

        private void frmPhanTichBinhLuan_Load(object sender, EventArgs e)
        {
            cboSanPham.DataSource = new BUS_QLSP().getSanPhams();
            cboSanPham.DisplayMember = "TENSP";
            cboSanPham.ValueMember = "ID";
            cboSanPham.Text = string.Empty;


        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                chartThongKe.Series["ThongKe"].Points.Clear();

                chartThongKe.Series["ThongKe"].LabelForeColor = Color.White;

                chartThongKe.Series["ThongKe"].IsValueShownAsLabel = true;

                var listCMT = new BUS_ThongKeCMT().PhanTichBinhLuan(cboSanPham.SelectedValue.ToString());

                chartThongKe.Series["ThongKe"].Points.AddXY("Tích cực", listCMT.Where(cmt => cmt.DanhGia).Count());
                chartThongKe.Series["ThongKe"].Points.AddXY("Tiêu cực", listCMT.Where(cmt => !cmt.DanhGia).Count());

                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                
            }
        }
    }
}
