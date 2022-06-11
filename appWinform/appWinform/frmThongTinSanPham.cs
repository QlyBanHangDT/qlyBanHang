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
using DTO;

namespace appWinform
{
    public partial class frmThongTinSanPham : Form
    {
        BUS_TTSP ttsp = new BUS_TTSP();
        BUS_QLSP sp = new BUS_QLSP();

        public string masp;
        public frmThongTinSanPham()
        {
            InitializeComponent();
        }

        private void frmThongTinSanPham_Load(object sender, EventArgs e)
        {
            lbTenSP.Text = String.Empty;
            lbGiaBan.Text = String.Empty;
            lbTenHang.Text = String.Empty;
            lbTenLoai.Text = String.Empty;
            lbCauHinh.Text = String.Empty;

            lbTenSP.Text = ttsp.getTenSP(masp);
            lbGiaBan.Text = string.Format("{0:N0} VNĐ", ttsp.getGiaBan(masp));
            lbTenHang.Text = ttsp.getTenHang(masp);
            lbTenLoai.Text = ttsp.getTenLoai(masp);

            foreach (CauHinh item in ttsp.getCauHinh(masp))
            {
                string ten = item.TenCauHinh;
                string nd = item.NoiDung;
                string cauhinh = string.Format("{0}: {1}\n", ten, nd);
                lbCauHinh.Text += cauhinh; 
            }

            List<IMEICODE> iCode = sp.getCode(masp);
            iCode.ForEach(item =>
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewLstCode.Rows[0].Clone();
                row.Cells[1].Value = item.MA;
                ((DataGridViewImageCell)row.Cells[2]).Value = Common.getBarCode(item.MA);

                dataGridViewLstCode.Rows.Add(row);
            });
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewLstCode_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewLstCode.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnExportE_Click(object sender, EventArgs e)
        {
            if (dataGridViewLstCode.Rows.Count == 1)
            {
                MessageBox.Show("Không có thông tin về số imei", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            List<ImeiCode> lstImeiCode = new List<ImeiCode>();

            foreach (DataGridViewRow row in dataGridViewLstCode.Rows)
            {
                if (row.Cells["Code"].Value == null) break;
                ImageConverter converter = new ImageConverter();

                lstImeiCode.Add(new ImeiCode {
                    TenSP = lbTenSP.Text,
                    Ma = row.Cells["Code"].Value.ToString(),
                    Hinh = (byte[])converter.ConvertTo(row.Cells["HinhAnh"].Value, typeof(byte[]))
                });
            }

            Reports<ImeiCode>.export_Excel(lstImeiCode, "IMEICODE", "ImeiCode");
        }


    }
}
