using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using DAL;

namespace GUI
{
    public partial class ThongTinKH : UserControl
    {
        KhachHang _kh;
        BUS_QLKH qlkh = new BUS_QLKH();
        bool isEdit; // dùng để kiểm tra xem form có chỉnh sửa gì không

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public KhachHang Kh
        {
            get { return _kh; }
            set { _kh = value; }
        }

        public ThongTinKH()
        {
            InitializeComponent();

            // định dạng cho data gridview
            formatColumnDataGridView();
        }

        private void formatColumnDataGridView()
        {
            // thiết lập font & text size
            foreach (DataGridViewColumn c in drvLSMuaHang.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 14.5f, GraphicsUnit.Pixel);
            }

            //drvLSMuaHang.Columns["clTDG"].DefaultCellStyle.Format = "#,## VNĐ";
            //drvLSMuaHang.Columns["clTDG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            drvLSMuaHang.DefaultCellStyle.NullValue = "no entry";

            // chỉnh màu cho datagridview
            drvLSMuaHang.RowsDefaultCellStyle.BackColor = Color.FromArgb(251, 228, 213);
            drvLSMuaHang.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        public void LoadData()
        {
            // lấy dữ liệu từ database
            var ttkh = qlkh.getKhachHang(Kh.Id);

            txtID.Texts = ttkh.Id;
            txtTenKH.Texts = ttkh.Ten;
            txtSDT.Texts = ttkh.Sdt;
            txtEmail.Texts = ttkh.Email;
            txtNgaySinh.Text = ttkh.NgaySinh;
            txtNgayTao.Texts = ttkh.NgayTao;
            txtGioiTinh.Texts = ttkh.GioiTinh;
            txtTongBan.Texts = string.Format("{0:#,##0}", qlkh.tongBan(Kh.Id));
            btnLuuTen.Visible = false;
            IsEdit = false; // gán flag don't edit
            drvLSMuaHang.DataSource = qlkh.getChiTietHoaDon(Kh.Id);
        }

        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = sender as ToolStripDropDownItem;
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    GUI.textBoxCustom txtMn = owner.SourceControl as GUI.textBoxCustom;
                    txtMn.Enabled = true;
                    txtMn.ForeColor = Color.Black;
                    btnLuuTen.Visible = true;
                    IsEdit = true;
                    txtMn.Select();
                    txtMn.Focus();

                }

            }
        }

        private void txtNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            btnLuuTen.Visible = true;
            IsEdit = true;
        }

        private void btnLuuTen_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtTenKH.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng không để trông thông tin họ tên");
                txtTenKH.Enabled = true;
                txtTenKH.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng không để trông thông tin số điện thoại");
                txtSDT.Enabled = true;
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng không để trông thông tin email");
                txtEmail.Enabled = true;
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtGioiTinh.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng không để trông thông tin giới tính");
                txtGioiTinh.Enabled = true;
                txtGioiTinh.Focus();
                return;
            }

            // kiểm tra độ chính xác của giá trị (giới tính, email, sdt)
            if (!KiemTra.CK_Gtinh(txtGioiTinh.Texts))
            {
                Program.AlertMessage("Giới tính nhập không phù hợp\nVui lòng chỉ nhập: Nam hoặc nữ");
                txtGioiTinh.Enabled = true;
                txtGioiTinh.Focus();
                return;
            }
            if (!KiemTra.CK_Email(txtEmail.Texts))
            {
                Program.AlertMessage("Email nhập không phù hợp\nVui lòng nhập lại");
                txtEmail.Enabled = true;
                txtEmail.Focus();
                return;
            }
            if (!KiemTra.CK_SDT(txtSDT.Texts))
            {
                Program.AlertMessage("Số điện thoại nhập không phù hợp\nVui lòng nhập lại");
                txtSDT.Enabled = true;
                txtSDT.Focus();
                return;
            }

            // lưu thông tin khách hàng nếu có
            if (qlkh.capNhatThongTin(new THONGTINTAIKHOAN{ 
                HOTEN = txtTenKH.Texts.ToUpper().Trim(),
                SDT = txtSDT.Texts.Trim(),
                EMAIL = txtEmail.Texts.Trim(),
                NGSINH = txtNgaySinh.Value,
                GTINH = txtGioiTinh.Texts.Trim().ToLower().Equals("nam") ? true : false
            }, txtID.Texts.Trim()))
            {
                Program.AlertMessage("Cập nhật thành công", MessageBoxIcon.Information);
                btnLuuTen.Visible = false;
                IsEdit = false;

                txtTenKH.Enabled = txtEmail.Enabled = txtSDT.Enabled = isEdit;
            }
            else Program.AlertMessage("Đã xãy ra lỗi\nVui lòng thử lại sau", MessageBoxIcon.Error);
            
        }

    }
}
