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
    public partial class frmThemPhieuKiemKho : Form
    {
        BUS_PhieuKiemKho pkk = new BUS_PhieuKiemKho();
        public frmThemPhieuKiemKho()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaPhieuKiemKho.Texts))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu kiểm kho !", "Thông báo");
                txtMaPhieuKiemKho.Focus();
                return;
            }
            //Kiểm tra mã phiếu kiểm kho(nếu người dùng tự nhập)
            if (pkk.kt_MaPhieuKK(txtMaPhieuKiemKho.Texts.Trim()) > 0)
            {
                MessageBox.Show("Mã phiếu kiểm kho bị trùng", "Thông báo");
                txtMaPhieuKiemKho.Focus();
                return;
            }

            if (pkk.them_PKK(txtMaPhieuKiemKho.Texts.Trim()))
            {
                MessageBox.Show("Thêm phiếu kiểm kho thành công", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo");
            }
        }

    }
}
