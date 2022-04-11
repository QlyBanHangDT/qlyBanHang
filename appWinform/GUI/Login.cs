using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AlertMessage(string pMessage)
        {
            MessageBox.Show(pMessage, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // txtTDN & txtPw are null
            if (string.IsNullOrEmpty(txtTDN.Texts.Trim()) && string.IsNullOrEmpty(txtPw.Texts.Trim()))
            {
                AlertMessage("Vui lòng nhập đủ thông tin đăng nhập");
                txtTDN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTDN.Texts.Trim()))
            {
                AlertMessage("Vui lòng nhập tên đăng nhập");
                txtTDN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPw.Texts.Trim()))
            {
                AlertMessage("Vui lòng nhập mật khẩu");
                txtPw.Focus();
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }


    }
}
