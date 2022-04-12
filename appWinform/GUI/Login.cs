﻿using System;
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

        private void AlertMessage(string pMessage, MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(pMessage, "Thông báo", MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
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

            // kiểm tra username & pw
            try
            {
                //LoginResult rs = busLogin.Check_User(txtTDN.Texts.Trim(), txtPw.Texts.Trim());

                //if (rs == LoginResult.Disabled)
                //{
                //    AlertMessage("Tài khoản bị khóa");
                //    return;
                //}
                //if (rs == LoginResult.Invalid)
                //{
                //    AlertMessage("Username hoặc mật khẩu sai");
                //    return;
                //}

                ButtonLogin_Click(this, EventArgs.Empty); // đăng nhập thành công

            }
            catch (Exception err)
            {
                AlertMessage(err.Message);
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
                this.ButtonLogin(this, e);
        }
    }
}
