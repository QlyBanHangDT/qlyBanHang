using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmQL_KH : UserControl
    {
        BUS_QLKH bus_qlkh = new BUS_QLKH();

        public frmQL_KH()
        {
            InitializeComponent();
            dgrvKH.DataSource = bus_qlkh.getDSKH();

            formatColumnDataGridView();
        }

        private void formatColumnDataGridView()
        {
            // thiết lập font & text size
            foreach (DataGridViewColumn c in dgrvKH.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 14.5f, GraphicsUnit.Pixel);
            }

            dgrvKH.Columns["clTDG"].DefaultCellStyle.Format = "#,## VNĐ";
            dgrvKH.Columns["clTDG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgrvKH.DefaultCellStyle.NullValue = "no entry";

            // chỉnh màu cho datagridview
            dgrvKH.RowsDefaultCellStyle.BackColor = Color.Bisque; // dòng lẻ
            dgrvKH.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige; // dòng chẵn
        }

        // tìm thông tin của khách hàng
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtFind.Text.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập thông tin tìm kiếm");
                txtFind.Focus();

                dgrvKH.DataSource = bus_qlkh.getDSKH();
                return;
            }

            dgrvKH.DataSource = bus_qlkh.findKHs(txtFind.Text.Trim());
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKh.PerformClick();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("after click double a row in data grid view")]
        public event EventHandler SelectedRow;

        // sự kiện clik datagrid view
        protected virtual void SelectedRow_Click(object sender, EventArgs e)
        {
            if (this.SelectedRow != null)
                this.SelectedRow(sender, e);
        }

        // chọn khách hàng
        private void dgrvKH_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // không click vào item
            if (dgrvKH.CurrentRow == null) return;

            // thông tin khách hàng
            KhachHang kh = new KhachHang(
                dgrvKH.CurrentRow.Cells["clID"].Value.ToString(),
                dgrvKH.CurrentRow.Cells["clHoTen"].Value.ToString());

            SelectedRow_Click(kh, EventArgs.Empty);
        }

    
    }
}
