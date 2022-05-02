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
    public partial class frmThongTinSanPham : Form
    {
        BUS_TTSP sp = new BUS_TTSP();
        string masp = "SP001";
        public frmThongTinSanPham()
        {
            InitializeComponent();
        }

        private void frmThongTinSanPham_Load(object sender, EventArgs e)
        {
            lbTenSP.Text = String.Empty;
            lbGiaBan.Text = String.Empty;
            lbTenHang.Text = String.Empty;
            lbTenLoai.Text = String.Empty;
            lbCauHinh.Text = String.Empty;

            lbTenSP.Text = sp.getTenSP(masp);
            lbGiaBan.Text = sp.getGiaBan(masp).ToString() + " VNĐ";
            lbTenHang.Text = sp.getTenHang(masp);
            lbTenLoai.Text = sp.getTenLoai(masp);

            foreach (CauHinh item in sp.getCauHinh(masp))
            {
                string ten = item.TenCauHinh;
                string nd = item.NoiDung;
                string cauhinh = ten + " " + nd + "\n";
                lbCauHinh.Text += cauhinh; 
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
