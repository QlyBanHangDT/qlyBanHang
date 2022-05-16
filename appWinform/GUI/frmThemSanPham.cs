using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class frmThemSanPham : Form
    {
        BUS_QLSP bus_qlsp = new BUS_QLSP();
        string iName;
        string filepath;
        string folSave = @"\Image\";
        private int? currentSelectionStart;
        bool isAddImage;

        public frmThemSanPham()
        {
            InitializeComponent();

            cboDanhMuc.DisplayMember = "TENDANHMUC";
            cboDanhMuc.ValueMember = "ID";

            cboHang.DisplayMember = "TENHANG";
            cboHang.ValueMember = "ID";

            cboLoai.DisplayMember = "TENLOAI";
            cboLoai.ValueMember = "ID";
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            drvCauHinh.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }

        private void imageSP_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                isAddImage = true;
                iName = opFile.SafeFileName.Substring(opFile.SafeFileName.LastIndexOf('.'));
                filepath = opFile.FileName;

                this.imageSP.Image = new Bitmap(opFile.OpenFile());
                this.imageSP.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (string.IsNullOrEmpty(txtTen.Text.Trim()) && string.IsNullOrEmpty(txtGia.Text.Trim()))
            {
                Program.AlertMessage("Vui lòng nhập đủ thông tin sản phẩm");
                return;
            }

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + folSave;
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            // thêm thông tin sản phẩm
            if (bus_qlsp.isExists(txtTen.Text.Trim())) 
            {
                Program.AlertMessage("Sản phẩm bị trùng vui lòng nhập lại");
                return;
            }
            iName = bus_qlsp.getID() + iName;
            if (bus_qlsp.themSP(
                pTenSP: txtTen.Text.Trim(),
                pGia: double.Parse(txtGia.Text.Trim()),
                pTenHang: cboHang.Text.Trim(),
                pTenLoai: cboLoai.Text.Trim(),
                pImage: isAddImage ? iName : string.Empty
                ))
            {
                try
                {
                    if (isAddImage)
                        File.Copy(filepath, appPath + iName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }

                // thêm cấu hình
                if (drvCauHinh.Rows.Count > 1) // kiểm tra xem có cấu hình không
                {
                    foreach (DataGridViewRow row in drvCauHinh.Rows)
                    {
                        if (row.Cells["TenCauHinh"].Value == null || row.Cells["NoiDung"].Value == null) break;
                        if (row.Cells["TenCauHinh"].Value.ToString() != string.Empty && row.Cells["NoiDung"].Value.ToString() != string.Empty)
                            bus_qlsp.themCauHinh(txtTen.Text.Trim(), row.Cells["TenCauHinh"].Value.ToString(), row.Cells["NoiDung"].Value.ToString());
                    }
                }
            }

            Program.AlertMessage("Thêm thành công", MessageBoxIcon.Information);
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThemSanPham_Load(object sender, EventArgs e)
        {
            cboDanhMuc.DataSource = bus_qlsp.getDanhMuc();

            cboHang.DataSource = bus_qlsp.getHang();
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLoai.DataSource = bus_qlsp.getLoai(int.Parse(cboDanhMuc.SelectedValue.ToString()));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtGia.Text != string.Empty)
            {
                txtGia.Text = Value.ToString();
                txtGia.Select(currentSelectionStart ?? txtGia.Text.Length, 0);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kiểm tra nhập số 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                e.Handled = true;
                return;
            }

            if (txtGia.SelectionStart == 0 && txtGia.SelectionLength == txtGia.Text.Length)
            {
                if (e.KeyChar == KPress.BACKSPACE_KEY)
                    val = 0;
                else val = double.Parse(e.KeyChar.ToString());
                return;
            }

            string soTien = txtGia.Text.Trim().Replace(",", null);

            if (char.IsDigit(e.KeyChar))
                val = double.Parse(soTien + e.KeyChar);
            else if (e.KeyChar == KPress.BACKSPACE_KEY && val.ToString() != string.Empty) // ấn nút xóa
            {
                if (soTien.Length <= 1)
                    val = 0;
                else val = double.Parse(soTien.Remove(soTien.Length - 1));
            }
            currentSelectionStart = null;
        }

        private object val;
        public double GiaTien
        {
            get
            {
                return double.Parse(Value.ToString().Replace(",", null));
            }
        }
        public object Value
        {
            get
            {
                return string.Format("{0:#,##0}", val);
            }
            set
            {
                val = value;
            }
        }
    }
}
