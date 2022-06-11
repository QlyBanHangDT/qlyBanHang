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
        BUS_QLNV nv = new BUS_QLNV();
        BUS_QLTK tk = new BUS_QLTK();
        BUS_QLSP sp = new BUS_QLSP();
        public frm_KiemKho()
        {
            InitializeComponent();
        }

        public void loadMaPhieuKiem()
        {
            string idTK = tk.getID_name(frmLogin.USERNAME);
            string id_nv = nv.getID(idTK);
            cbo_PKK.DataSource = pkk.loadPhieuKK(id_nv);
            cbo_PKK.DisplayMember = "ID";
        }

        private void frm_KiemKho_Load(object sender, EventArgs e)
        {
            btnLuu.Visible = btnHuy.Visible = false;

            cboTenSP.Enabled = false;

            loadMaPhieuKiem();

            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            txtSL_ThucTe.Enabled = false;
            txtSL_Ton.Enabled = false;

            if (pkk.getTrangThai_PKK(cbo_PKK.Text) == true)
            {
                btnThemChiTiet.Enabled = false;
                btnXoaPhieu.Enabled = false;
                btnHoanThanh.Enabled = false;
            }

            cboTenSP.DataSource = sp.getNames();
            cboTenSP.Text = String.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cbo_PKK.SelectedValue.ToString();
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            //Kiểm tra tổng số lượng tồn kho
            //Nếu null thì chưa cập nhật
            //Nếu co thì hiển thị số lượng
            int? sl = pkk.loadSL_Lech(ma);
            if (sl == null)
                label1.Text = "chưa cập nhật";
            else
                label1.Text = sl.ToString();

            dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
            dgv_CTPKK.ClearSelection();

            if (pkk.getTrangThai_PKK(ma) == false)
            {
                label12.Text = "Chưa hoàn thành";
                btnThemChiTiet.Enabled = true;
                btnXoaPhieu.Enabled = true;
                label12.ForeColor = Color.Red;
            }
            else 
            {
                txtSL_ThucTe.BorderColor = Color.Gray;
                txtSL_Ton.BorderColor = Color.Gray;
                txtSL_Ton.Enabled = false;
                txtSL_ThucTe.Enabled = false;
                btnThemChiTiet.Enabled = false;
                btnXoaPhieu.Enabled = false;
                label12.Text = "Đã hoàn thành";
                label12.ForeColor = Color.Green;
            }

            if (pkk.kt_TrangThai(ma) > 0)
            {
                btnHoanThanh.Enabled = false;
            }
        }

        private void dgv_CTPKK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboTenSP.Text = dgv_CTPKK.CurrentRow.Cells["ID_SP"].Value.ToString();
            txtSL_Ton.Texts = dgv_CTPKK.CurrentRow.Cells["SL_TONKHO"].Value.ToString();
            var sl_tt = dgv_CTPKK.CurrentRow.Cells["SL_THUCTE"].Value;
            txtSL_ThucTe.Texts = String.Format("{0}",sl_tt);
            var sl_tk = dgv_CTPKK.CurrentRow.Cells["SL_TONKHO"].Value;
            txtSL_Ton.Texts = String.Format("{0}", sl_tk);
            var sl_lech = dgv_CTPKK.CurrentRow.Cells["SL_LECH"].Value;
            txtSL_Lech.Texts = String.Format("{0}", sl_lech);
            var gt = dgv_CTPKK.CurrentRow.Cells["GIATRILECH"].Value;
            txtGiaTri.Texts = String.Format("{0:#,##0}", gt);

            if (pkk.getTrangThai_PKK(cbo_PKK.Text) == true)
                return;
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

            string ma_sp = sp.getID_name(cboTenSP.Text);
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
                btnXoa.Enabled = false;
                txtSL_Ton.Enabled = false;
                txtSL_ThucTe.BorderColor = Color.Gray;
                txtSL_Ton.BorderColor = Color.Gray;
                cboTenSP.Text = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
                MessageBox.Show("Cập nhật thành công !", "Thông báo");

                if (pkk.kt_TrangThai(ma) == 0)
                {
                    btnHoanThanh.Enabled = true;
                }

            }
            else
                MessageBox.Show("Đã xảy ra lỗi","Lỗi");

        }

        private void btnThemPKK_Click(object sender, EventArgs e)
        {
            frmThemPhieuKiemKho frm = new frmThemPhieuKiemKho();
            frm.ShowDialog();
            loadMaPhieuKiem();
            cboTenSP.Text = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
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

        private void checkNumber(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông báo");
                (sender as GUI.textBoxCustom).Focus();
                e.Handled = true;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            dgv_CTPKK.Enabled = false;
            cboTenSP.Enabled = true;
            btnLuu.Visible = btnHuy.Visible = true;
            txtSL_Ton.Enabled = false;
            txtSL_ThucTe.Enabled = false;

            btnHoanThanh.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;

            cboTenSP.Text = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
            txtSL_ThucTe.BorderColor = Color.Gray;
            txtSL_Ton.BorderColor = Color.Gray;
            cboTenSP.Focus();
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
            if (String.IsNullOrEmpty(cboTenSP.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo");
                cboTenSP.Focus();
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
            if (sp.isExists_TenSP(cboTenSP.Text.Trim()) == 0)
            {
                MessageBox.Show("Tên sản phẩm không tồn tại", "Thông báo");
                cboTenSP.Focus();
                return;
            }
            string maSP = sp.getID_name(cboTenSP.Text.Trim());
            //Kiểm tra khoa của chi tiết phiếu tồn kho
            if (pkk.kt_CTPKK(cbo_PKK.Text.Trim(), maSP) > 0)
            {
                MessageBox.Show("Mã chi tiết phiếu đã tồn tại", "Thông báo");
                cboTenSP.Focus();
                return;
            }


            //Thêm dữ liệu
            string ma = cbo_PKK.Text;

            int sl_tk = int.Parse(txtSL_Ton.Texts);
            int? sl_thucTe;

            if (txtSL_ThucTe.Texts == string.Empty) 
                sl_thucTe = null;
            else sl_thucTe = int.Parse(txtSL_ThucTe.Texts);

            if (pkk.them_CTPKK(maSP, ma, sl_tk, sl_thucTe))
            {
                dgv_CTPKK.Enabled = true;
                cboTenSP.Enabled = false;
                txtSL_ThucTe.Enabled = false;
                btnLuu.Visible = btnHuy.Visible = false;
                txtSL_ThucTe.BorderColor = Color.Gray;
                cboTenSP.Text = txtSL_ThucTe.Texts = txtSL_Ton.Texts = String.Empty;
                dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
                MessageBox.Show("Thêm chi tiết thành công !", "Thông báo");

                // cập nhật giá trị lệnh (nếu có)
                if (sl_thucTe != null)
                {
                    if (pkk.capNhatKiemKho(ma, maSP, sl_thucTe.Value, sl_tk))
                    {
                        dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
                        int? sl = pkk.loadSL_Lech(ma);
                        if (sl == null)
                            label1.Text = "Chưa cập nhật";
                        else
                            label1.Text = sl.ToString();
                        btnCapNhat.Enabled = false;
                        txtSL_ThucTe.Enabled = false;
                        btnXoa.Enabled = false;
                        txtSL_Ton.Enabled = false;
                        txtSL_ThucTe.BorderColor = Color.Gray;
                        txtSL_Ton.BorderColor = Color.Gray;
                        cboTenSP.Text = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;

                        if (pkk.kt_TrangThai(ma) == 0)
                        {
                            btnHoanThanh.Enabled = true;
                        }

                    }
                }
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
            string ten = dgv_CTPKK.CurrentRow.Cells["ID_SP"].Value.ToString();
            string maSP = sp.getID_name(ten);
            if (pkk.xoa_CTPKK(maSP, ma))
            {
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
                cboTenSP.Enabled = false;
                txtSL_ThucTe.BorderColor = Color.Gray;
                txtSL_Ton.BorderColor = Color.Gray;
                cboTenSP.Text = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;
                dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);
                MessageBox.Show("Xóa chi tiết thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo");
            }
        }

        private void cboTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboTenSP.DroppedDown = true;
        }

        private void cbo_PKK_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbo_PKK.DroppedDown = true;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Xác nhận để hoàn thành phiếu?", "Cập nhật",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (r == DialogResult.Yes)
            {
                if (pkk.capNhatPhieuKK(cbo_PKK.Text) && pkk.kt_TrangThai(cbo_PKK.Text) == 0)
                {
                    btnXoaPhieu.Enabled = true;
                    btnHoanThanh.Enabled = false;
                    btnThemChiTiet.Enabled = false;
                    MessageBox.Show("Cập nhật thành công", "Cập nhật");
                    if (pkk.getTrangThai_PKK(cbo_PKK.Text) == false)
                    {
                        label12.Text = "Chưa hoàn thành";
                        label12.ForeColor = Color.Red;
                    }
                    else
                    {
                        label12.Text = "Đã hoàn thành";
                        label12.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string ma = cbo_PKK.Text;

            dgv_CTPKK.Enabled = true;
            cboTenSP.Enabled = false;

            dgv_CTPKK.DataSource = pkk.loadCT_PhieuKK(ma);

            btnLuu.Visible = btnHuy.Visible = false;

            btnCapNhat.Enabled = false;
            txtSL_ThucTe.Enabled = false;
            btnXoa.Enabled = false;
            txtSL_Ton.Enabled = false;

            txtSL_ThucTe.BorderColor = Color.Gray;
            txtSL_Ton.BorderColor = Color.Gray;

            cboTenSP.Text = txtSL_Lech.Texts = txtSL_ThucTe.Texts = txtSL_Ton.Texts = txtGiaTri.Texts = String.Empty;

            if (pkk.kt_TrangThai(ma) == 0)
            {
                btnHoanThanh.Enabled = true;
            }
        }

        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenSP.Enabled)
            {
                txtSL_Ton.Texts = sp.getSoLuong(cboTenSP.Text).ToString();

                txtSL_ThucTe.Enabled = true;

                txtSL_ThucTe.BorderColor = Color.BlueViolet;

                txtSL_ThucTe.Focus();
            }
        }

        private void label12_TextChanged(object sender, EventArgs e)
        {
            btnXuatFile.Enabled = label12.Text.Equals("Đã hoàn thành");
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            List<object> _lstSp = new List<object>();
            int _tongSoLuongLech = 0;
            double _tongGTriLech = 0;
            foreach (DataGridViewRow r in dgv_CTPKK.Rows)
            {
                _lstSp.Add(new {
                    TenSP = r.Cells["ID_SP"].Value.ToString(),
                    SoLuongTK = string.Format("{0:0}", r.Cells["SL_TONKHO"].Value.ToString()),
                    SoLuongTT = string.Format("{0:0}", r.Cells["SL_THUCTE"].Value.ToString()),
                    SoLuongLech = string.Format("{0:0}", r.Cells["SL_LECH"].Value.ToString()),
                    GiaTriLech = string.Format("{0:#,##0}", double.Parse(r.Cells["GIATRILECH"].Value.ToString())),
                });

                _tongSoLuongLech += int.Parse(string.Format("{0:0}", r.Cells["SL_LECH"].Value.ToString()));
                _tongGTriLech += double.Parse(string.Format("{0:0}", r.Cells["GIATRILECH"].Value.ToString()));
            }

            List<string[]> data = new List<string[]>();
            data.Add(new string[] { "NhanVien", "TongSLLech", "TongGiaTriLech" });
            data.Add(new string[] { 
                new BUS_QLNV().getNhanVien(frmLogin.USERNAME).Ten, 
                string.Format("{0:0}", _tongSoLuongLech), 
                string.Format("{0:#,##0}", _tongGTriLech)
            });

            // Show thông tin phiếu kiểm kho
            new Reports<object>().export_Word("phieuKT.docx", "KiemKho", _lstSp, data);
        }

    }
}
