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
    public partial class frmThongTinNhanVien : Form
    {
        BUS_QLNV bus_nv = new BUS_QLNV();
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            
        }

        public void loadThongTinNhanVien()
        {
            NhanVien nv = bus_nv.getNhanVien("leductai");
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
    }
}
