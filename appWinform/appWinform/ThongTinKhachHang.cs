using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace appWinform
{
    public partial class ThongTinKhachHang : Form
    {
        BUS_QLKH bus_qlkh = new BUS_QLKH();
        public KhachHang kh = null;

        bool isAddCustomer;

        public ThongTinKhachHang()
        {
            InitializeComponent();
            rdbNam.Checked = true;
        }
        private void ChkThongTinKH(object sender, EventArgs e)
        {
            if (this.txtSDT.Texts.Trim().Length == 0)
                return;

            kh = bus_qlkh.getKhachHang_sdt(this.txtSDT.Texts.Trim());

            if (kh.Ten != string.Empty)
            {
                txtHoTen.Texts = kh.Ten;
                txtNgaySinh.Texts = kh.NgaySinh;
                txtEmail.Texts = kh.Email;
                txtSDT.Texts = kh.Sdt;
                txtDiaChi.Texts = kh.DiaChi;
                txtNgayTao.Texts = kh.NgayTao;
                if (kh.GioiTinh.Equals("Nam"))
                    rdbNam.Checked = true;
                else rdbNu.Checked = true;

                btnXacNhan.Text = "Xác Nhận";
                return;
            }

            txtHoTen.Clear();
            txtEmail.Clear();
            txtNgaySinh.Clear();
            txtDiaChi.Clear();
            txtNgayTao.Clear();
            kh = null;

            btnXacNhan.Text = "Cập Nhật";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (btnXacNhan.Text == "Cập Nhật")
            {
                kh = new KhachHang();
                if (this.txtHoTen.Texts.Trim().Length == 0 || this.txtNgaySinh.Texts.Trim().Length == 0 || this.txtEmail.Texts.Trim().Length == 0 || this.txtSDT.Texts.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng điền thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (!GUI.KiemTra.CK_Email(txtEmail.Texts.Trim()))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtEmail.Focus();
                    return;
                }
                if (!GUI.KiemTra.CK_SDT(txtSDT.Texts.Trim()))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtSDT.Focus();
                    return;
                }

                try
                {
                    DateTime dt = DateTime.ParseExact(txtNgaySinh.Texts.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    MessageBox.Show("Định dạng ngày không phù hợp. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtNgaySinh.Focus();
                    return;
                }

                kh.Username = string.Empty;
                kh.Pw = string.Empty;
                kh.Ten = txtHoTen.Texts.Trim();
                kh.NgaySinh = txtNgaySinh.Texts.Trim();
                kh.Email = txtEmail.Texts.Trim();
                kh.Sdt = txtSDT.Texts.Trim();
                kh.DiaChi = txtDiaChi.Texts.Trim();
                kh.GioiTinh = rdbNam.Checked ? "Nam" : "Nữ";

                // thêm khách hàng mới
                bus_qlkh.themKhachHang(kh);
            }
            else this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
