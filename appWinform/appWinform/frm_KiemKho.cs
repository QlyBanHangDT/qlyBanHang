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
    public partial class frm_KiemKho : Form
    {
        BUS_PhieuKiemKho pkk = new BUS_PhieuKiemKho();
        BUS_QLSP sp = new BUS_QLSP();
        public frm_KiemKho()
        {
            InitializeComponent();
        }

        public void loadMaPhieuKiem()
        {
            cbo_PKK.DataSource = pkk.loadPhieuKK();
            cbo_PKK.DisplayMember = "ID";
        }

        private void frm_KiemKho_Load(object sender, EventArgs e)
        {
            loadMaPhieuKiem();
            btnCapNhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtSL_ThucTe.Enabled = false;
            txtSL_Ton.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cbo_PKK.SelectedValue.ToString();
            //Kiểm tra tổng số lượng tồn kho
            //Nếu null thì chưa cập nhật
            //Nếu co thì hiển thị số lượng
            int? sl = pkk.loadSL_Lech(ma);
            if (sl == null)
                label1.Text = "chưa cập nhật";
            else
                label1.Text = sl.ToString();
            dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
        }

        private void dgv_CTPKK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIMaSP.Texts = dgv_CTPKK.CurrentRow.Cells["ID_SP"].Value.ToString();
            txtSL_Ton.Texts = dgv_CTPKK.CurrentRow.Cells["SL_TONKHO"].Value.ToString();
            var sl_tt = dgv_CTPKK.CurrentRow.Cells["SL_THUCTE"].Value;
            txtSL_ThucTe.Texts = String.Format("{0}",sl_tt);
            var sl_tk = dgv_CTPKK.CurrentRow.Cells["SL_TONKHO"].Value;
            txtSL_Ton.Texts = String.Format("{0}", sl_tk);
            var sl_lech = dgv_CTPKK.CurrentRow.Cells["SL_LECH"].Value;
            txtSL_Lech.Texts = String.Format("{0}", sl_lech);
            var gt = dgv_CTPKK.CurrentRow.Cells["GIATRILECH"].Value;
            txtGiaTri.Texts = String.Format("{0}", gt);

            txtSL_ThucTe.Enabled = true;
            txtSL_Ton.Enabled = true;
            txtSL_ThucTe.BorderColor = Color.BlueViolet;
            txtSL_Ton.BorderColor = Color.BlueViolet;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
            txtSL_Ton.Focus();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSL_ThucTe.Texts))
            {
                MessageBox.Show("Vui lòng nhập số lượng thực tế !", "Thông báo");
                txtSL_ThucTe.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSL_Ton.Texts))
            {
                MessageBox.Show("Vui lòng nhập số lượng tồn !", "Thông báo");
                txtSL_ThucTe.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cbo_PKK.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu kiểm kho !", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            //Kiểm tra mã phiếu kiểm kho(nếu người dùng tự nhập)
            if (pkk.kt_MaPhieuKK(cbo_PKK.Text) == 0)
            {
                MessageBox.Show("Mã phiếu kiểm kho không tồn tại \n Vui lòng chọn lại", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            string ma_sp = txtIMaSP.Texts;
            string ma = cbo_PKK.Text;
            int sl_tt = int.Parse(txtSL_ThucTe.Texts);
            int sl_tk = int.Parse(txtSL_Ton.Texts);
            if (pkk.capNhatKiemKho(ma, ma_sp, sl_tt,sl_tk))
            {
                dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
                int? sl = pkk.loadSL_Lech(ma);
                if (sl == null)
                    label1.Text = "Chưa cập nhật";
                else
                    label1.Text = sl.ToString();
                btnCapNhat.Enabled = false;
                txtSL_ThucTe.Enabled = false;
                txtSL_Ton.Enabled = false;
                txtSL_ThucTe.BorderColor = Color.Gray;
                txtSL_Ton.BorderColor = Color.Gray;
                txtIMaSP.Texts = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
                MessageBox.Show("Cập nhật thành công !", "Thông báo");
            }
            else
                MessageBox.Show("Đã xảy ra lỗi","Lỗi");

        }

        private void txtSL_ThucTe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThemPKK_Click(object sender, EventArgs e)
        {
            frmThemPhieuKiemKho frm = new frmThemPhieuKiemKho();
            frm.ShowDialog();
            loadMaPhieuKiem();
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbo_PKK.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu kiểm kho !", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            //Người dùng nhập mã phiếu sai
            if (pkk.kt_MaPhieuKK(cbo_PKK.Text.Trim()) == 0)
            {
                MessageBox.Show("Mã phiếu kiểm kho không tồn tại", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            //Kiểm tra mã phiếu kiểm kho có tồn tại chi tiết hay không
            if (pkk.kt_CT_MaPhieuKK(cbo_PKK.Text.Trim()) > 0)
            {
                MessageBox.Show("Mã phiếu kiểm kho tồn tại chi tiết", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            if (pkk.xoa_PKK(cbo_PKK.Text.Trim()))
            {
                MessageBox.Show("Xóa phiếu kiểm kho thành công", "Thông báo");
                loadMaPhieuKiem();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo");
            }
        }

        private void txtSL_Ton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtIMaSP.Enabled = true;
            txtSL_Ton.Enabled = true;
            txtSL_ThucTe.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            txtIMaSP.Texts = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
            txtIMaSP.BorderColor = Color.BlueViolet;
            txtSL_Ton.BorderColor = Color.BlueViolet;
            txtSL_ThucTe.BorderColor = Color.Gray;
            txtIMaSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbo_PKK.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu kiểm kho !", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            //Người dùng không nhập mã sản phẩm
            if (String.IsNullOrEmpty(txtIMaSP.Texts.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm", "Thông báo");
                txtIMaSP.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtSL_Ton.Texts.Trim()))
            {
                MessageBox.Show("Vui lòng nhập số lượng tồn kho", "Thông báo");
                txtSL_Ton.Focus();
                return;
            }

            //Người dùng nhập mã phiếu sai
            if (pkk.kt_MaPhieuKK(cbo_PKK.Text.Trim()) == 0)
            {
                MessageBox.Show("Mã phiếu kiểm kho không tồn tại", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

           //Kiểm tra mã sản phẩm có tồn tại
            if (sp.isExists_MaSP(txtIMaSP.Texts.Trim()) == 0)
            {
                MessageBox.Show("Mã sản phẩm không tồn tại", "Thông báo");
                txtIMaSP.Focus();
                return;
            }

            //Kiểm tra khoa của chi tiết phiếu tồn kho
            if (pkk.kt_CTPKK(cbo_PKK.Text.Trim(), txtIMaSP.Texts.Trim()) > 0)
            {
                MessageBox.Show("Mã chi tiết phiếu đã tồn tại", "Thông báo");
                txtIMaSP.Focus();
                return;
            }


            //Thêm dữ liệu
            string ma = cbo_PKK.Text;
            string maSP= txtIMaSP.Texts;
            int sl_tk = int.Parse(txtSL_Ton.Texts);
            if (pkk.them_CTPKK(maSP, ma, sl_tk))
            {
                txtIMaSP.Enabled = false;
                txtSL_Ton.Enabled = false;
                btnLuu.Enabled = false;
                txtIMaSP.BorderColor = Color.Gray;
                txtSL_Ton.BorderColor = Color.Gray;
                txtIMaSP.Texts = txtSL_Ton.Texts = String.Empty;
                dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
                MessageBox.Show("Thêm chi tiết thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbo_PKK.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu kiểm kho !", "Thông báo");
                cbo_PKK.Focus();
                return;
            }
            //Người dùng nhập mã phiếu sai
            if (pkk.kt_MaPhieuKK(cbo_PKK.Text.Trim()) == 0)
            {
                MessageBox.Show("Mã phiếu kiểm kho không tồn tại", "Thông báo");
                cbo_PKK.Focus();
                return;
            }

            string ma = cbo_PKK.Text;
            string maSP = dgv_CTPKK.CurrentRow.Cells["ID_SP"].Value.ToString();

            if (pkk.xoa_CTPKK(maSP, ma))
            {
                btnXoa.Enabled = false;
                txtSL_ThucTe.BorderColor = Color.Gray;
                txtSL_Ton.BorderColor = Color.Gray;
                txtIMaSP.Texts = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
                dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
                MessageBox.Show("Xóa chi tiết thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo");
            }
        }
    }
}
