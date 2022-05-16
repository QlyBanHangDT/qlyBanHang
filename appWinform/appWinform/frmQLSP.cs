using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appWinform
{
    public partial class frmQLSP : Form
    {
        public frmQLSP()
        {
            InitializeComponent();
        }

        private void frmQL_SP1_SelectedRow(object sender, EventArgs e)
        {
            frmThongTinSanPham frm = new frmThongTinSanPham();
            frm.masp = sender.ToString();
            frm.ShowDialog();
        }
    }
}
