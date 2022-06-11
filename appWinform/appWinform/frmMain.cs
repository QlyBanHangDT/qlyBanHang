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

namespace appWinform
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItem, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem mnu in mnuItem)
            {
                if (mnu is ToolStripMenuItem && (mnu as ToolStripMenuItem).DropDownItems.Count > 0)
                {
                    FindMenuPhanQuyen((mnu as ToolStripMenuItem).DropDownItems, pScreenName, pEnable);
                    mnu.Enabled = mnu.Visible = CheckAllMenuChildVisible((mnu as ToolStripMenuItem).DropDownItems);
                }
                else if (string.Equals(pScreenName, mnu.Tag))
                {
                    mnu.Enabled = pEnable;
                    if (pEnable)
                        mnu.Tag = pEnable; // gán màn hình đã được chọn
                    mnu.Visible = pEnable; // ẩn màn hình chức năng
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem mnuItem in mnuItems) 
            {
                if (mnuItem is ToolStripMenuItem && mnuItem.Enabled)
                    return true;
                else if (mnuItem is ToolStripSeparator)
                    continue;
            }
            return false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            BUS.BUS_QLTK bus_qltk = new BUS.BUS_QLTK();

            var lstND = bus_qltk.lstNhomNguoiDung(frmLogin.USERNAME);

            foreach (var item in lstND)
            {
                var dsQuyen = bus_qltk.lstManHinh(item.IdGr); // lấy các màn hình chức năng đã được phân quyền
                foreach (var mh in dsQuyen)
                {
                    FindMenuPhanQuyen(this.menuStrip1.Items, mh.IdMH, mh.CoQuyen);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadLogout));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            this.Dispose();
        }


        private void ThreadLogout()
        {
            Application.Run(new frmLogin());
        }

        private void quảnLýNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.MdiParent = this;

            frm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.MdiParent = this;

            frm.Show();
        }

        private void quảnLýNhómNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhomNguoiDung frm = new frmNhomNguoiDung();
            frm.MdiParent = this;

            frm.Show(); 
        }
        
        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLSP frm = new frmQLSP();
            frm.MdiParent = this;

            frm.Show(); 
        }

        private void xemThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinNhanVien frm = new frmThongTinNhanVien();
            frm.MdiParent = this;

            frm.Show();
        }

        private void quảnLýNhómNgườiDùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThemNguoiDung frm = new frmThemNguoiDung();
            frm.MdiParent = this;

            frm.Show();
        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.MdiParent = this;

            frm.Show();
        }

        private void quảnLýMànHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManHinh frm = new frmManHinh();
            frm.MdiParent = this;

            frm.Show();

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.MdiParent = this;

            frm.Show();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            frm.MdiParent = this;

            frm.Show();
        }

        private void kiểmTraTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_KiemKho frm = new frm_KiemKho();
            frm.MdiParent = this;

            frm.Show();
        }
    }
}
