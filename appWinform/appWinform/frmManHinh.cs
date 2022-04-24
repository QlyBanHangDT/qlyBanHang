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
    public partial class frmManHinh : Form
    {
        BUS_ManHinh bus_mh = new BUS_ManHinh();
        public frmManHinh()
        {
            InitializeComponent();
        }

        public void loadManHinh()
        {
            dgvManHinh.DataSource = bus_mh.getManHinh();
        }

        private void frmManHinh_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = btnSua.Enabled = false;
            loadManHinh();
        }

        private void dgvManHinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = btnSua.Enabled = true;
            txtIDMH.Texts = dgvManHinh.CurrentRow.Cells[0].Value.ToString();
            txtTenMH.Texts = dgvManHinh.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtIDMH.Texts.Equals(String.Empty))
            {
                MessageBox.Show("Vui lòng nhập " + label2.Text.ToLower(), "Thông báo");
                txtIDMH.Focus();
                return;
            }

            if (txtTenMH.Texts.Equals(String.Empty))
            {
                MessageBox.Show("Vui lòng nhập " + label3.Text.ToLower(), "Thông báo");
                txtTenMH.Focus();
                return;
            }

            if (!bus_mh.kt_KhoaManHinh(txtIDMH.Texts))
            {
                MessageBox.Show("Trùng khóa !", "Thông báo");
                return;
            }

            if (bus_mh.themManHinh(txtIDMH.Texts, txtTenMH.Texts))
            {
                MessageBox.Show("Thêm màn hình " + txtIDMH.Texts + " thành công !", "Thông báo");
                loadManHinh();
                return;
            }
            MessageBox.Show("Đã xãy ra lỗi !", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bus_mh.xoaManHinh(txtIDMH.Texts))
            {
                MessageBox.Show("Xóa màn hình " + txtIDMH.Texts + " thành công !", "Thông báo");
                loadManHinh();
                return;
            }
            MessageBox.Show("Đã xãy ra lỗi !", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenMH.Texts.Equals(String.Empty))
            {
                MessageBox.Show("Vui lòng nhập " + label3.Text.ToLower(), "Thông báo");
                txtTenMH.Focus();
                return;
            }

            if (bus_mh.suaManHinh(txtIDMH.Texts,txtTenMH.Texts))
            {
                MessageBox.Show("Sửa màn hình " + txtIDMH.Texts + " thành công !", "Thông báo");
                loadManHinh();
                return;
            }
            MessageBox.Show("Đã xãy ra lỗi !", "Thông báo");
        }
    }
}
