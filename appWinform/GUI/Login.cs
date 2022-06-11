using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class Login : UserControl
    {
        BUS_Login busLogin = new BUS_Login();

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // txtTDN & txtPw are null
            if (string.IsNullOrEmpty(txtTDN.Texts.Trim()) && string.IsNullOrEmpty(txtPw.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập đủ thông tin đăng nhập");
                txtTDN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTDN.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập tên đăng nhập");
                txtTDN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPw.Texts.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập mật khẩu");
                txtPw.Focus();
                return;
            }

            // kiểm tra username & pw
            try
            {
                LoginResult rs = busLogin.Check_User(txtTDN.Texts.Trim(), txtPw.Texts.Trim());

                if (rs == LoginResult.Disabled)
                {
                    Program.AlertMessage("Tài khoản bị khóa");
                    return;
                }
                if (rs == LoginResult.Invalid)
                {
                    Program.AlertMessage("Username hoặc mật khẩu sai");
                    return;
                }
                Program.AlertMessage("Xin chào " + txtTDN.Texts.Trim(), MessageBoxIcon.Information);
                ButtonLogin_Click(txtTDN.Texts.Trim(), EventArgs.Empty); // đăng nhập thành công

            }
            catch (Exception err)
            {
                Program.AlertMessage(err.Message);
                new frmConfig().ShowDialog();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("after click button login")]
        public event EventHandler ButtonLogin;

        protected virtual void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (this.ButtonLogin != null)
                this.ButtonLogin(sender, e);
        }

        private void txtTDN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KPress.ENTER_KEY)
                btnDangNhap.PerformClick();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtTDN.Focus();
        }
    }
}
