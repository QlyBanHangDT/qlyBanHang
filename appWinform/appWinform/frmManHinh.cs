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
            loadManHinh();
        }

        private void dgvManHinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDMH.Texts = dgvManHinh.CurrentRow.Cells[0].Value.ToString();
            txtTenMH.Texts = dgvManHinh.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
