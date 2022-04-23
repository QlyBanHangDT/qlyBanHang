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
    public partial class frmThemNguoiDung : Form
    {
        BUS.BUS_QLTK bus_qltk = new BUS.BUS_QLTK();
        BUS.BUS_QLNND bus_qlnnd = new BUS.BUS_QLNND();

        public frmThemNguoiDung()
        {
            InitializeComponent();

            // set background for data gridview
            drvTK.RowsDefaultCellStyle.BackColor = Color.FromArgb(217, 226, 243);
            drvTK.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            drvNhom.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            drvNhom.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 217, 217);

            // null value
            drvTK.DefaultCellStyle.NullValue = drvNhom.DefaultCellStyle.NullValue = "no entry";
        }

        private void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            this.cbNhoms.ValueMember = "ID";
            this.cbNhoms.DisplayMember = "Ten";
            this.cbNhoms.DataSource = bus_qlnnd.getGrs();
        }

        private void drvTK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            drvTK.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }

        private void cbNhoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDrv();
        }

        private void drvNhom_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            drvNhom.Rows[e.RowIndex].Cells["No_grA"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in drvTK.SelectedRows)
            {
                bus_qlnnd.addToGr(int.Parse(cbNhoms.SelectedValue.ToString()), item.Cells["ID"].Value.ToString());
            }

            LoadDrv();
        }

        private void LoadDrv()
        {
            int idGr = int.Parse(cbNhoms.SelectedValue.ToString());
            drvTK.DataSource = bus_qltk.getDSTK(idGr);
            drvNhom.DataSource = bus_qltk.getDSNhomTK(idGr);
        }

        private void btnDelOne_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in drvNhom.SelectedRows)
            {
                bus_qlnnd.DelToGr(int.Parse(cbNhoms.SelectedValue.ToString()), item.Cells["IDTK_grA"].Value.ToString());
            }

            LoadDrv();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in drvTK.Rows)
            {
                bus_qlnnd.addToGr(int.Parse(cbNhoms.SelectedValue.ToString()), item.Cells["ID"].Value.ToString());
            }

            LoadDrv();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in drvNhom.Rows)
            {
                bus_qlnnd.DelToGr(int.Parse(cbNhoms.SelectedValue.ToString()), item.Cells["IDTK_grA"].Value.ToString());
            }

            LoadDrv();
        }


    }
}
