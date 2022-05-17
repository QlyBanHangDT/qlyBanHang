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
using DTO;

namespace appWinform
{
    public partial class frmNhapNCC : Form
    {
        BUS_NCC bus_ncc = new BUS_NCC();

        public frmNhapNCC()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Texts.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNCC.Focus();
                return;
            }
            if (bus_ncc.IsExists(txtTenNCC.Texts.Trim()))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNCC.SelectAll();
                return;
            }

            if (bus_ncc.themNCC(txtTenNCC.Texts.Trim()))
            {
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }
    }
}
