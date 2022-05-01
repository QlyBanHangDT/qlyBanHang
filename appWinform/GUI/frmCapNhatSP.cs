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

namespace GUI
{
    public partial class frmCapNhatSP : Form
    {
        public bool flg_capNhatTen;
        private int? currentSelectionStart;
        public bool ckUpdate;
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
                return flg_capNhatTen ? val : string.Format("{0:#,##0}", val);
            }
            set
            {
                val = value;
            }
        }

        public frmCapNhatSP()
        {
            InitializeComponent();
            ckUpdate = false;
        }

        private void frmTTSP_Load(object sender, EventArgs e)
        {
            if (flg_capNhatTen)
            {
                btnCapNhat.Text = "Xác nhận";
                btnCapNhat.BackColor = Color.White;
                btnCapNhat.ForeColor = Color.FromArgb(255, 192, 128);
                btnCapNhat.BorderColor = Color.FromArgb(255, 192, 128);
            }
            else
            {
                txtCapNhat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                btnCapNhat.Text = "Cập nhật";
                btnCapNhat.BackColor = Color.Aqua;
                btnCapNhat.ForeColor = Color.White;
                btnCapNhat.BorderColor = Color.FromArgb(128, 255, 255);
            }

            txtCapNhat.Texts = Value.ToString();

            txtCapNhat.Select();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ckUpdate = true;
            this.Dispose();            
        }

        private void txtCapNhat__TextChanged(object sender, EventArgs e)
        {
            if (txtCapNhat.Texts != string.Empty)
            {
                txtCapNhat.Texts = Value.ToString();
                txtCapNhat.Select(currentSelectionStart ?? txtCapNhat.Texts.Length, 0);
            }
        }

        private void txtCapNhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KPress.ENTER_KEY) // nhấn enter
            {
                btnCapNhat.PerformClick();
            }

            if (!flg_capNhatTen) 
            {
                // kiểm tra nhập số 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    MessageBox.Show("Vui lòng nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    e.Handled = true;
                    return;
                }

                if (txtCapNhat.SelectionStart == 0 && txtCapNhat.SelectionLength == txtCapNhat.Texts.Length)
                {
                    if (e.KeyChar == KPress.BACKSPACE_KEY)
                        val = 0;
                    else val = double.Parse(e.KeyChar.ToString());
                    return;
                }

                string soTien = txtCapNhat.Texts.Trim().Replace(",", null);

                if (char.IsDigit(e.KeyChar))
                    val = double.Parse(soTien + e.KeyChar);
                else if (e.KeyChar == KPress.BACKSPACE_KEY && val.ToString() != string.Empty) // ấn nút xóa
                {
                    if (soTien.Length <= 1)
                        val = 0;
                    else val = double.Parse(soTien.Remove(soTien.Length - 1));
                }
                currentSelectionStart = null;
                return;    
            }

            if (e.KeyChar == KPress.BACKSPACE_KEY && txtCapNhat.SelectionLength == 0)
            {
                val = val.ToString().Remove(txtCapNhat.SelectionStart - 1, 1);
                currentSelectionStart = txtCapNhat.SelectionStart - 1;
                return;
            }
            else
            {
                val = val.ToString().Remove(txtCapNhat.SelectionStart, txtCapNhat.SelectionLength);

                if (e.KeyChar != KPress.BACKSPACE_KEY)
                {
                    val = val.ToString().Insert(txtCapNhat.SelectionStart, e.KeyChar.ToString());
                }
                currentSelectionStart = txtCapNhat.SelectionStart + 1;
            }

        }

    }
}
