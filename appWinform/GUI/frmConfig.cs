using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void cbServername_DropDown(object sender, EventArgs e)
        {
            cbServername.DataSource = BUS.BUS_db.GetServername();
            cbServername.DisplayMember = "Servername";
        }

        private void cbDb_DropDown(object sender, EventArgs e)
        {
            cbDb.DataSource = BUS.BUS_db.GetDBName(cbServername.Text, txtUsername.Text, txtPw.Text);
            cbDb.DisplayMember = "name";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BUS.BUS_db.SaveConfig(cbServername.Text, txtUsername.Text, txtPw.Text, cbDb.Text);
            this.Close();
        }
    }
}
