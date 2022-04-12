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
    public partial class ConfigSQL : UserControl
    {
        public ConfigSQL()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập UserName !", "Thông báo");
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập Password !", "Thông báo");
                txtPass.Focus();
                return;
            }

        }
    }
}
