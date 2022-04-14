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
    public partial class FrmQL_SP : UserControl
    {
        BUS_QLSP qlsp = new BUS_QLSP();
        public FrmQL_SP()
        {
            InitializeComponent();
            dataGridView_QLSP.DataSource = qlsp.getDSSP();
        }
    }
}
