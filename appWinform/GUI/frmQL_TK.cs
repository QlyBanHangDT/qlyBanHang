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
    public partial class frmQL_TK : UserControl
    {
        BUS_QLTK bus_qltk = new BUS_QLTK();
        public frmQL_TK()
        {
            InitializeComponent();

            dataGridView_TaiKhoan.DataSource = bus_qltk.getDSTK();
        }

        private void dataGridView_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
	        {
                txtP.Texts = dataGridView_TaiKhoan.CurrentRow.Cells["clPw"].Value.ToString();
                txtU.Tag = dataGridView_TaiKhoan.CurrentRow.Cells["clID"].Value.ToString();
                txtU.Texts = dataGridView_TaiKhoan.CurrentRow.Cells["clU"].Value.ToString();
                ckHD.Checked = (bool)dataGridView_TaiKhoan.CurrentRow.Cells["clHD"].Value;
                btnSua.Enabled = btnXoa.Enabled = true;
                btnSua.Text = "Sửa";
	        }
	        catch (Exception)
	        {
		
		        return;
	        }
                
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = true;

            btnSua.Text = "Xác nhận";

            txtP.Clear();
            txtU.Clear();

            txtU.Enabled = true;
            txtU.BorderColor = Color.MediumSlateBlue;

            ckHD.Checked = true;

            txtU.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtU.Texts.Trim().Equals("admin"))
            {
                Program.AlertMessage("Không thể xóa admin. Vui lòng xóa tài khoản khác", MessageBoxIcon.Information);
                return;
            }

            if (Program.ConfirmMessage("Bạn có muốn xóa không") == DialogResult.Yes)
            {
                if (bus_qltk.xoaTK(txtU.Tag.ToString()))
                {
                    Program.AlertMessage("Xóa thành công", MessageBoxIcon.Information);
                    dataGridView_TaiKhoan.DataSource = bus_qltk.getDSTK();
                }
                else
                {
                    Program.AlertMessage("Đã xảy ra lỗi", MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Sửa")) // sửa thông tin
            {
                if (string.IsNullOrEmpty(txtP.Texts.Trim()))
                {
                    Program.AlertMessage("Vui lòng không để trổng mật khẩu");

                    if (string.IsNullOrEmpty(txtU.Texts.Trim()))
                        txtU.Focus();
                    else txtP.Focus();
                    return;
                }
                if (bus_qltk.capNhatTK(txtU.Texts.Trim(), txtP.Texts.Trim(), ckHD.Checked))
                {
                    Program.AlertMessage("Cập nhật thành công thành công", MessageBoxIcon.Information);

                    // cập nhật lại data gridview
                    dataGridView_TaiKhoan.DataSource = bus_qltk.getDSTK();
                }
                else
                {
                    Program.AlertMessage("Đã xảy ra lỗi", MessageBoxIcon.Error);
                    return;
                }
            }
            else // thêm thông tin
            {
                // rổng
                if (string.IsNullOrEmpty(txtU.Texts.Trim()) || string.IsNullOrEmpty(txtP.Texts.Trim()))
                {
                    Program.AlertMessage("Vui lòng nhập thông tin tài khoản");

                    if (string.IsNullOrEmpty(txtU.Texts.Trim()))
                        txtU.Focus();
                    else txtP.Focus();
                    return;
                }
                // trùng
                if (bus_qltk.isExists(txtU.Texts.Trim()))
                {
                    Program.AlertMessage("Username đã tồn tại\nVui lòng nhập lại");
                    txtU.Focus();
                    return;
                }
                if (bus_qltk.themTK(txtU.Texts.Trim(), txtP.Texts.Trim()))
                {
                    Program.AlertMessage("Thêm thành công", MessageBoxIcon.Information);

                    // cập nhật lại data gridview
                    dataGridView_TaiKhoan.DataSource = bus_qltk.getDSTK();
                }
                else
                {
                    Program.AlertMessage("Đã xảy ra lỗi", MessageBoxIcon.Error);
                    return;
                } 
            }
            btnSua.Text = "Sửa";
            txtU.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
            txtP.Clear();
            txtU.Clear();
            txtU.BorderColor = Color.DimGray;
        }

        

    }
}
