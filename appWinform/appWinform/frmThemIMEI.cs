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
    public partial class frmThemIMEI : Form
    {
        BUS_QLSP bus_qlsp = new BUS_QLSP();

        public string dataImei;
        public string dataAllNewImei;

        public frmThemIMEI()
        {
            InitializeComponent();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (txtFind.TextLength == 15)
            {
                // kiểm tra trùng trong csdl
                if (bus_qlsp.isCodeExists(txtFind.Text.Trim()) || dataAllNewImei.IndexOf(txtFind.Text.Trim()) != -1)
                {
                    MessageBox.Show("Mã đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtFind.SelectAll();
                    return;
                }
                // kiểm tra nhập trùng bảng imei
                foreach (DataGridViewRow r in dataGridViewLstCode.Rows)
                {
                    if (r.Cells["Code"].Value == null) break;

                    // kiểm tra imei đã dc thêm
                    if (r.Cells["Code"].Value.ToString().IndexOf(txtFind.Text.Trim()) != -1)
                    {
                        MessageBox.Show("Sản phẩm đã được thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtFind.SelectAll();
                        return;
                    }
                }

                DataGridViewRow row = (DataGridViewRow)dataGridViewLstCode.Rows[0].Clone();
                row.Cells[1].Value = txtFind.Text.Trim();
                ((DataGridViewImageCell)row.Cells[2]).Value = Common.getBarCode(txtFind.Text.Trim());

                dataGridViewLstCode.Rows.Add(row);

                txtFind.SelectAll();
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kiểm tra nhập số 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Mã imei bao gồm chữ số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                e.Handled = true;
            }
        }

        private void dataGridViewLstCode_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewLstCode.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }

        private void frmThemIMEI_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dataImei))
            {
                var lstImei = dataImei.Trim().Split(',').ToList();

                lstImei.ForEach(imei =>
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridViewLstCode.Rows[0].Clone();
                    row.Cells[1].Value = imei;
                    ((DataGridViewImageCell)row.Cells[2]).Value = Common.getBarCode(imei);

                    dataGridViewLstCode.Rows.Add(row);
                });
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            dataImei = string.Empty;

            foreach (DataGridViewRow r in dataGridViewLstCode.Rows) 
            {
                if (r.Cells["Code"].Value == null) break;

                dataImei += r.Cells["Code"].Value.ToString() + " ";
            }
            dataImei = dataImei.Trim().Replace(' ', ',');

            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dataGridViewLstCode.Rows.RemoveAt(dataGridViewLstCode.CurrentRow.Index);
        }

        
    }
}
