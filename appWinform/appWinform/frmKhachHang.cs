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

namespace appWinform
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmQL_KH1_SelectedRow(object sender, EventArgs e)
        {
            KhachHang kh = sender as KhachHang;
            // hiển thị thông tin khách hàng
            new frmThongTinKhachHang(kh).ShowDialog();
            //MessageBox.Show(kh.Ten);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
