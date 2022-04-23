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

            dataGridView_QLSP.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView_QLSP.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            // null value
            dataGridView_QLSP.DefaultCellStyle.NullValue = "no entry";
        }

        private void dataGridView_QLSP_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                btnCapNhatGia.Enabled = btnChangeName.Enabled = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                btnCapNhatGia.Enabled = btnChangeName.Enabled = false;
            }
        }
    }
}
