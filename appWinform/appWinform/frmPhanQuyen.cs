using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace appWinform
{
    public partial class frmPhanQuyen : Form
    {
        BUS_QLNND bus_qlnnd = new BUS_QLNND();
        BUS_PhanQuyen bus_phanQuyen = new BUS_PhanQuyen();

        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            drvNhomNguoiDung.DataSource = bus_qlnnd.getGrs();
        }

        private void drvNhomNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idGr = int.Parse(drvNhomNguoiDung.CurrentRow.Cells["ID"].Value.ToString());

            drvPhanQuyen.DataSource = bus_phanQuyen.getPhanQuyens(idGr);

            HandleCkAll();            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int idgr = int.Parse(drvNhomNguoiDung.CurrentRow.Cells["ID"].Value.ToString());
                foreach (DataGridViewRow pq in drvPhanQuyen.Rows)
                {
                    bus_phanQuyen.luuTT_PQ(new DTO.QL_PHANQUYEN
                    {
                        ID_GRTK = idgr,
                        ID_MH = pq.Cells["ID_PQ"].Value.ToString(),
                        COQUYEN = pq.Cells["CoQuyen"].Value == null ? false : bool.Parse(pq.Cells["CoQuyen"].Value.ToString())
                    });
                }
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.OnLoad(e);  
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
                      
        }

        private void drvPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleCkAll();
        }

        private void HandleCkAll()
        {
            ckAll.Checked = true;
            foreach (DataGridViewRow pq in drvPhanQuyen.Rows)
            {
                if (!(pq.Cells["CoQuyen"].Value == null ? false : bool.Parse(pq.Cells["CoQuyen"].Value.ToString())))
                {
                    ckAll.Checked = false;
                    return;
                }
            }
        }

        private void ckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow pq in drvPhanQuyen.Rows)
            {
                pq.Cells["CoQuyen"].Value = ckAll.Checked;
            }
        }
    }
}
