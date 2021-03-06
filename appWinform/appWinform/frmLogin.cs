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
    public partial class frmLogin : Form
    {
        public static string USERNAME;

        public frmLogin()
        {
            USERNAME = string.Empty;
            InitializeComponent();
        }

        private void login1_ButtonLogin(object sender, EventArgs e)
        {
            // đăng nhập thành công => chuyển trang
            USERNAME = sender as string; // gán Username
            Thread t = new Thread(new ThreadStart(ThreadLogin));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            this.Dispose();
        }

        private void ThreadLogin()
        {
            Application.Run(new frmMain());
        }
    }
}
