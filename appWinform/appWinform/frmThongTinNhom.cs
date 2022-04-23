using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appWinform
{
    public partial class frmThongTinNhom : Form
    {
        string _tenNhom;

        public string TenNhom
        {
            get { return _tenNhom; }
            set { _tenNhom = value; }
        }
        public frmThongTinNhom()
        {
            InitializeComponent();
        }

        private void frmThongTinNhom_Load(object sender, EventArgs e)
        {
            if (TenNhom != null)
            {
                btnXacNhan.Text = "Cập nhập";
                txtTenNhom.Texts = TenNhom;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            BUS.BUS_QLNND bus_qlnnd = new BUS.BUS_QLNND();

            if (string.IsNullOrEmpty(txtTenNhom.Texts))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNhom.Focus();
                return;
            }

            if (txtTenNhom.Texts.Trim().Split(' ').Count() > 1)
            {
                MessageBox.Show("Nhập giá trị không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNhom.Focus();
                return;
            }

            if (bus_qlnnd.isExists(txtTenNhom.Texts.Trim()))
            {
                MessageBox.Show("Tên nhóm đã tồn tại.\nVui lòng nhập tên nhóm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtTenNhom.Focus();
                return;
            }

            TenNhom = txtTenNhom.Texts.Trim();

            this.Dispose();
        }
    }
}
