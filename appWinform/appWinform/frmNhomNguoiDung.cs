using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace appWinform
{
    public partial class frmNhomNguoiDung : Form
    {
        BUS_QLNND bus_qlnnd = new BUS_QLNND();
        public frmNhomNguoiDung()
        {
            InitializeComponent();

            drvThongTinNhom.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            drvThongTinNhom.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(205, 253, 255);

            // null value
            drvThongTinNhom.DefaultCellStyle.NullValue = "no entry";
        }

        private void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            drvThongTinNhom.DataSource = bus_qlnnd.getGrs();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var a = drvThongTinNhom.CurrentRow.Cells[0].Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThongTinNhom frm = new frmThongTinNhom();
            frm.ShowDialog();
            // thực hiện thêm nhóm
            if (frm.TenNhom != null)
            {
                bus_qlnnd.themNhom(frm.TenNhom);
                this.OnLoad(e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThongTinNhom frm = new frmThongTinNhom();
            frm.TenNhom = drvThongTinNhom.CurrentRow.Cells["TenNhom"].Value.ToString();
            frm.ShowDialog();

            if (frm.TenNhom != null)
            {
                bus_qlnnd.chinhSua(int.Parse(drvThongTinNhom.CurrentRow.Cells["ID"].Value.ToString()) ,frm.TenNhom);
                this.OnLoad(e);
            }
        }

        private void drvThongTinNhom_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                btnXoa.Enabled = btnSua.Enabled = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                btnXoa.Enabled = btnSua.Enabled = false;
            }
        }


        private void drvThongTinNhom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                btnXoa.Enabled = btnSua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == System.Windows.Forms.DialogResult.Yes)
            {
                try 
	            {
                    bus_qlnnd.xoaNhom(drvThongTinNhom.CurrentRow.Cells["TenNhom"].Value.ToString());
                    this.OnLoad(e);
	            }
	            catch (Exception err)
	            {
                    MessageBox.Show(err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
	            }
            }
        }
    }
}
