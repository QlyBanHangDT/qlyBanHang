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
using GUI;
namespace appWinform
{
    public partial class frmThongTinNhanVien : Form
    {
        BUS_QLNV bus_nv = new BUS_QLNV();
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            
        }

        public void loadThongTinNhanVien()
        {
            NhanVien nv = bus_nv.getNhanVien(frmLogin.USERNAME);
            txtTenNV.Texts = nv.Ten;
            txtSDT.Texts = nv.Sdt;
            txtNgaySinh.Text = nv.NgaySinh;
            txtNgayTao.Texts = nv.NgayTao;
            if (nv.GioiTinh.Equals("Nam"))
                rdbNam.Checked = true;
            else
                rdbNu.Checked = false;
            txtEmail.Texts = nv.Email;
            txtDiaChi.Texts = nv.DiaChi;
            txtTinhTrang.Texts = nv.TinhTrang;
        }

        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            loadThongTinNhanVien();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtTenNV.Texts.Trim()))
            {
                MessageBox.Show("Vui lòng không để trông thông tin họ tên");
                txtTenNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Texts.Trim()))
            {
                MessageBox.Show("Vui lòng không để trông thông tin số điện thoại");
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Texts.Trim()))
            {
                MessageBox.Show("Vui lòng không để trông thông tin email");
                txtEmail.Focus();
                return;
            }

            //Kiểm tra email, số điện thoại
            if (!KiemTra.CK_Email(txtEmail.Texts))
            {
                MessageBox.Show("Email không phù hợp \n Vui lòng nhập lại");
                txtEmail.Focus();
                return;
            }

            if (!KiemTra.CK_SDT(txtSDT.Texts))
            {
                MessageBox.Show("Số điện thoại không phù hợp \n Vui lòng nhập lại");
                txtSDT.Focus();
                return;
            }

            // lưu thông tin nhân viên
            bool gt = false;
            if (rdbNam.Checked)
                gt = true;

            if (bus_nv.capNhatNV(new THONGTINTAIKHOAN
            {
                HOTEN = txtTenNV.Texts.ToUpper().Trim(),
                SDT = txtSDT.Texts.Trim(),
                EMAIL = txtEmail.Texts.Trim(),
                NGSINH = txtNgaySinh.Value,
                GTINH = gt
            },frmLogin.USERNAME))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else MessageBox.Show("Đã xãy ra lỗi");
        }

    }
}
