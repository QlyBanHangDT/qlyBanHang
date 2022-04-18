using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace appWinform
{
    public partial class frmThongTinKhachHang : Form
    {
        KhachHang _kh;
        GUI.ThongTinKH ttkh;

        public frmThongTinKhachHang(KhachHang kh)
        {
            _kh = kh;
            InitializeComponent();
        }
        
        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void thongTinKH3_Load(object sender, EventArgs e)
        {
            ttkh = (sender as GUI.ThongTinKH);
            ttkh.Kh = _kh;

            ttkh.LoadData();
        }

        private void frmThongTinKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ttkh.IsEdit)
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
                
            }
        }
    }
}
