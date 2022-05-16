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
    public partial class frmBanHang : Form
    {
        BUS_QLSP bus_qlsp = new BUS_QLSP();
        BUS_TTSP bus_ttsp = new BUS_TTSP();
        BUS_QLNV bus_nv = new BUS_QLNV();
        DataTable tbSanPham = new DataTable();
        private int? currentSelectionStart;
        private object val;
        public string GiaTien
        {
            get
            {
                return string.Format("{0:#,##0}", val);
            }
        }

        public frmBanHang()
        {
            InitializeComponent();
            // khởi tạo table
            tbSanPham.Columns.Add(new DataColumn("ma", typeof(string)));
            tbSanPham.Columns.Add(new DataColumn("TenSP", typeof(string)));
            tbSanPham.Columns.Add(new DataColumn("SoLuong", typeof(int)));
            tbSanPham.Columns.Add(new DataColumn("Gia", typeof(string)));
            tbSanPham.Columns.Add(new DataColumn("imeicode", typeof(string)));
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            dataGridView_hd.DataSource = tbSanPham;
            txtFind.SelectAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTienKhach__TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhach.Texts != string.Empty)
            {
                txtTienKhach.Texts = GiaTien;
                txtTienKhach.Select(currentSelectionStart ?? txtTienKhach.Texts.Length, 0);

                // tiền thừa
                double tienHD = double.Parse(txtTongTien.Texts.Trim().Replace(",", null));
                txtTienThua.Texts = string.Format("{0:#,##0}", (double)val - tienHD);
            }
        }

        private void txtTienKhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kiểm tra nhập số 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                e.Handled = true;
                return;
            }
            string soTien = txtTienKhach.Texts.Trim().Replace(",", null);

            if (char.IsDigit(e.KeyChar))
                val = double.Parse(soTien + e.KeyChar);
            else if (e.KeyChar == KPress.BACKSPACE_KEY && val.ToString() != string.Empty) // ấn nút xóa
            {
                if (soTien.Length <= 1)
                    val = 0;
                else val = double.Parse(soTien.Remove(soTien.Length - 1));
            }
            currentSelectionStart = null;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            // xử lí nhập sản phẩm (mã imei)
            if (ckMayQuet.Checked) // dùng máy quét
            {
                xuLy(e);
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ckMayQuet.Checked)
            {
                e.Handled = true;
                return;
            }
            // kiểm tra nhập số 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Mã imei bao gồm chữ số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                e.Handled = true;
            }
        }

        private void dataGridView_hd_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView_hd.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();

            btnThanhToan.Enabled = e.RowIndex + 1 > 0; // có hàng là hiện btn

            double tongGia = 0;
            foreach (DataRow row in tbSanPham.Rows)
            {
                tongGia += double.Parse(row["Gia"].ToString()) * int.Parse(row["SoLuong"].ToString());
            }
            txtTongTien.Texts = tongGia.ToString("#,##0");
        }

        private void xuLy(object e)
        {
            if (txtFind.Text.Trim().Length == 15)
            {
                #region kiểm tra thông tin imeicode
                // kiểm tra tồn tại
                if (!bus_qlsp.isCodeExists(txtFind.Text.Trim()))
                {
                    MessageBox.Show("Mã không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtFind.SelectAll();
                    return;
                }
                // kiểm tra sản phẩm chưa bán
                if (bus_qlsp.isCodeDaBan(txtFind.Text.Trim()))
                {
                    MessageBox.Show("Sản phẩm đã bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtFind.SelectAll();
                    return;
                }
                #endregion

                // add vào hóa đơn
                // kiểm tra đã có sản phẩm
                string maSP = bus_qlsp.getID(txtFind.Text.Trim());

                #region Thêm sản phẩm vào bảng hóa đơn
                if (tbSanPham.Rows.Count != 0)
                {
                    bool flag = false;
                    foreach (DataRow row in tbSanPham.Rows)
                    {
                        // kiểm tra imei đã dc thêm
                        if (row["imeicode"].ToString().IndexOf(txtFind.Text.Trim()) != -1)
                        {
                            MessageBox.Show("Sản phẩm đã được thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            flag = true;
                            break;
                        }
                        if (row["ma"].ToString().Equals(maSP))
                        {
                            flag = true;
                            row["SoLuong"] = int.Parse(row["SoLuong"].ToString()) + 1;
                            row["imeicode"] = string.Format("{0}, {1}", row["imeicode"].ToString(), txtFind.Text.Trim());
                            break;
                        }
                    }

                    if (flag)
                    {
                        txtFind.SelectAll();
                        return;
                    }
                }
                DataRow r = tbSanPham.NewRow();
                r["ma"] = maSP;
                r["TenSP"] = bus_ttsp.getTenSP(maSP);
                r["SoLuong"] = 1;
                r["Gia"] = string.Format("{0:#,##0}", bus_ttsp.getGiaBan(maSP));
                r["imeicode"] = txtFind.Text.Trim();
                tbSanPham.Rows.Add(r);
                #endregion

                this.OnLoad((EventArgs)e);
            }
            else
            {
                MessageBox.Show("Mã imei không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (ckMayQuet.Checked) return;
            xuLy(e);
        }

        private void ckMayQuet_CheckedChanged(object sender, EventArgs e)
        {
            txtFind.Focus();
            txtFind.SelectAll();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTienKhach.Texts.ToString()))
            {
                MessageBox.Show("Vui lòng nhập số tiền của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            NhanVien nv = bus_nv.getNhanVien(frmLogin.USERNAME);
            btnThanhToan.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            // xử lý thanh toán
            // lấy thông tin khách hàng
            ThongTinKhachHang frm = new ThongTinKhachHang();
            frm.ShowDialog();

            if (frm.kh != null)
            {
                // thêm hóa đơn vào csdl
                string maHD = bus_qlsp.getMaHD();
                foreach (DataGridViewRow cthd in dataGridView_hd.Rows)
                {
                    // chi tiết hóa đơn
                    var lstImeiCode = cthd.Cells["imeicode"].Value.ToString().Split(',');
                    foreach (string imeiCode in lstImeiCode)
                    {
                        bus_qlsp.thanhToan(maHD, frm.kh.Ten, nv.Ten, imeiCode.Trim());
                    }
                }


                this.Cursor = Cursors.Default;
                // xuất bill
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                // show report
                frmReportBill rpBill = new frmReportBill();
                rpBill.MaHD = maHD;
                rpBill.TienKhach = txtTienKhach.Texts.Trim();
                rpBill.TienThua = txtTienThua.Texts.Trim();

                rpBill.ShowDialog();

                #region clear form
                ckMayQuet.Checked = false;
                this.txtFind.Clear();
                tbSanPham.Clear();
                this.txtTienKhach.Clear();
                this.txtTienThua.Clear();
                this.txtTongTien.Clear();
                #endregion
            }
                
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // xóa sản phẩm ra hóa đơn
            dataGridView_hd.Rows.RemoveAt(dataGridView_hd.CurrentRow.Index);
            btnThanhToan.Enabled = !(dataGridView_hd.Rows.Count == 0);
        }

    }
}
