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
namespace GUI
{
    public partial class frmQL_KH : UserControl
    {
        BUS_QLKH bus = new BUS_QLKH();
        public frmQL_KH()
        {
            InitializeComponent();
            dataGridView1.DataSource = bus.getDSKH();
        }
    }
}
