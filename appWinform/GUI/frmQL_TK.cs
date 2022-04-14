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
    public partial class frmQL_TK : UserControl
    {
        BUS_QLTK bus_qltk = new BUS_QLTK();
        public frmQL_TK()
        {
            InitializeComponent();

            dataGridView_TaiKhoan.DataSource = bus_qltk.getDSTK();
        }
    }
}
