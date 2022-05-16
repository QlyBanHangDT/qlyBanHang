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
    public partial class FrmQL_SP : UserControl
    {
        BUS_QLSP qlsp = new BUS_QLSP();
        public FrmQL_SP()
        {
            InitializeComponent();
            styleDatagridview();
        }
        private void styleDatagridview()
        {
            dataGridView_QLSP.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView_QLSP.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            // null value
            dataGridView_QLSP.DefaultCellStyle.NullValue = "";

            dataGridView_QLSP.Columns["GIA"].DefaultCellStyle.Format = "#,##0";
            dataGridView_QLSP.Columns["GIA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void dataGridView_QLSP_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnCapNhatGia.Enabled = btnChangeName.Enabled = false;
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                btnCapNhatGia.Enabled = btnChangeName.Enabled = true;
            }
        }

        private void btnCapNhatGia_Click(object sender, EventArgs e)
        {
            frmCapNhatSP frm = new frmCapNhatSP();
            frm.flg_capNhatTen = false;
            frm.Value = double.Parse(dataGridView_QLSP.CurrentRow.Cells["Gia"].Value.ToString());
            frm.ShowDialog();

            // cập nhập giá cho sản phẩm
            if (frm.ckUpdate)
            {
                if (qlsp.capNhatGia(dataGridView_QLSP.CurrentRow.Cells["ID"].Value.ToString(), frm.GiaTien))
                {
                    Program.AlertMessage("Cập nhật thành công", MessageBoxIcon.Information);
                    this.OnLoad(e);
                }else
                    Program.AlertMessage("Cập nhật Thất bại");
            }
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            frmCapNhatSP frm = new frmCapNhatSP();
            frm.flg_capNhatTen = true;
            frm.Value = dataGridView_QLSP.CurrentRow.Cells["TenSP"].Value.ToString();
            frm.ShowDialog();

            // cập nhập tên cho sản phẩm
            if (frm.ckUpdate)
            {
                if (qlsp.capNhatTen(dataGridView_QLSP.CurrentRow.Cells["ID"].Value.ToString(), frm.Value.ToString()))
                {
                    Program.AlertMessage("Cập nhật thành công", MessageBoxIcon.Information);
                    this.OnLoad(e);
                }
                else
                    Program.AlertMessage("Cập nhật Thất bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSanPham frm = new frmThemSanPham();
            frm.ShowDialog();
            this.OnLoad(e);
        }

        private void dataGridView_QLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // xem thông tin sản phẩm
            string masp = dataGridView_QLSP.CurrentRow.Cells["ID"].Value.ToString();
            SelectedRow_Click(masp, EventArgs.Empty);
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtFind.Text.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập thông tin tìm kiếm");
                txtFind.Focus();

                dataGridView_QLSP.DataSource = qlsp.getDSSP();
                return;
            }

            dataGridView_QLSP.DataSource = qlsp.timKiemSP(txtFind.Text.Trim());
        }

        private void FrmQL_SP_Load(object sender, EventArgs e)
        {
            dataGridView_QLSP.DataSource = qlsp.getDSSP();
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KPress.ENTER_KEY) // nhấn enter
            {
                btnTimSP.PerformClick();
            }
        }


        [Browsable(true)]
        [Category("Action")]
        [Description("after click a row in data grid view")]
        public event EventHandler SelectedRow;

        // sự kiện clik datagrid view
        protected virtual void SelectedRow_Click(object sender, EventArgs e)
        {
            if (this.SelectedRow != null)
                this.SelectedRow(sender, e);
        }
    }
}
