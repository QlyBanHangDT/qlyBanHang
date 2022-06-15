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
    public partial class frmNhapHang : Form
    {
        BUS_QLSP bus_qlsp = new BUS_QLSP();
        BUS_TTSP bus_ttsp = new BUS_TTSP();
        DataTable tbSanPham = new DataTable();
        BUS_NCC bus_ncc = new BUS_NCC();
        BUS_QLNV bus_nv = new BUS_QLNV();

        public frmNhapHang()
        {
            InitializeComponent();
            tbSanPham.Columns.Add(new DataColumn("ma", typeof(string)));
            tbSanPham.Columns.Add(new DataColumn("TenSP", typeof(string)));
            tbSanPham.Columns.Add(new DataColumn("SoLuong", typeof(int)));
            tbSanPham.Columns.Add(new DataColumn("Gia", typeof(string)));
            tbSanPham.Columns.Add(new DataColumn("imeicode", typeof(string)));
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maPN = bus_qlsp.getMaPN();
            NhanVien nv = bus_nv.getNhanVien(frmLogin.USERNAME);

            int _tongSoLuong = 0;

            List<object> _lstSp = new List<object>();

            foreach (DataGridViewRow r in dataGridView_pn.Rows)
            {
                var lstImei = r.Cells["imeicode"].Value.ToString().Split(',').ToList();

                _tongSoLuong += int.Parse(r.Cells["SoLuong"].Value.ToString());

                if (int.Parse(r.Cells["SoLuong"].Value.ToString()) == 0)
                    continue;

                _lstSp.Add(new
                {
                    TenSP = r.Cells["TenSP"].Value.ToString().Trim(),
                    SoLuong = r.Cells["SoLuong"].Value.ToString(),
                    Gia = double.Parse(r.Cells["Gia"].Value.ToString()).ToString("#,##0")
                });

                // thêm vào bảng imei
                lstImei.ForEach(imei =>
                {
                    bus_qlsp.themSP(r.Cells["TenSP"].Value.ToString().Trim(), imei);

                    // xác nhận nhập hàng // line 543 sql
                    bus_qlsp.nhapHang(maPN, cboNCC.Text, nv.Ten, imei);
                });
            }
            List<string[]> data = new List<string[]>();
            data.Add(new string[] { "TenNhanVien", "TenNCC", "TongSoLuong", "TongGia" });
            data.Add(new string[] { nv.Ten, cboNCC.Text, string.Format("{0}", _tongSoLuong), txtTongTien.Texts });

            // Show thông tin phiếu nhập
            new Reports<object>().export_Word("reportPhieuNhap.docx", "ListSP", _lstSp, data);

            // clear view 
            txtTongTien.Clear();
            tbSanPham.Clear();
            cboNCC.Text = string.Empty;
            btnThanhToan.Enabled = false;
            MessageBox.Show("Nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            loadNCC();

            cboSearch.DataSource = bus_qlsp.getNames();
            cboSearch.Text = string.Empty;

            dataGridView_pn.DataSource = tbSanPham;
            cboSearch.Focus();
        }

        private void loadNCC()
        {
            cboNCC.DataSource = bus_ncc.getNCCs();
            cboNCC.DisplayMember = "TENNCC";
        }

        private void cboSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboSearch.DroppedDown = true;
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (tbSanPham.Rows.Count != 0)
            {
                bool flag = false;
                foreach (DataRow row in tbSanPham.Rows)
                {
                    // kiểm tra imei đã dc thêm
                    if (row["TenSP"].ToString().Equals(cboSearch.Text.Trim()))
                    {
                        MessageBox.Show("Sản phẩm đã được thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    cboSearch.SelectAll();
                    return;
                }
            }
            string maSP = bus_qlsp.getID_name(cboSearch.Text.Trim());
            if (maSP == string.Empty)
            {
                MessageBox.Show("Thông tin sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                cboSearch.Text = string.Empty;

                return;   
            }

            DataRow r = tbSanPham.NewRow();
            r["ma"] = maSP;
            r["TenSP"] = bus_ttsp.getTenSP(maSP);
            r["SoLuong"] = 0;
            r["Gia"] = string.Format("{0:#,##0}", bus_ttsp.getGiaBan(maSP));
            r["imeicode"] = string.Empty;
            tbSanPham.Rows.Add(r);

            this.OnLoad((EventArgs)e);
        }

        private void dataGridView_pn_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView_pn.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();

            btnThanhToan.Enabled = e.RowIndex + 1 > 0; // có hàng là hiện btn

            double tongGia = 0;
            foreach (DataRow row in tbSanPham.Rows)
            {
                tongGia += double.Parse(row["Gia"].ToString()) * int.Parse(row["SoLuong"].ToString());
            }
            txtTongTien.Texts = tongGia.ToString("#,##0");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // xóa sản phẩm ra hóa đơn
            dataGridView_pn.Rows.RemoveAt(dataGridView_pn.CurrentRow.Index);
            btnThanhToan.Enabled = !(dataGridView_pn.Rows.Count == 0);
        }

        private void dataGridView_pn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // thêm imei
            frmThemIMEI frm = new frmThemIMEI();
            frm.dataImei = dataGridView_pn.CurrentRow.Cells["imeicode"].Value.ToString();
            frm.dataAllNewImei = string.Empty;
            foreach (DataGridViewRow r in dataGridView_pn.Rows)
            {
                frm.dataAllNewImei += r.Cells["imeicode"].Value.ToString() + ",";
            }

            frm.ShowDialog();

            // cập nhật thông tin nhập
            dataGridView_pn.CurrentRow.Cells["imeicode"].Value = frm.dataImei;
            dataGridView_pn.CurrentRow.Cells["SoLuong"].Value = string.IsNullOrEmpty(frm.dataImei.Trim()) ? 0 : frm.dataImei.Trim().Split(',').Count();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            frmNhapNCC frm = new frmNhapNCC();

            frm.ShowDialog();

            loadNCC();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            btnXoa.Enabled = dataGridView_pn.RowCount != 0;
        }
    }
}
