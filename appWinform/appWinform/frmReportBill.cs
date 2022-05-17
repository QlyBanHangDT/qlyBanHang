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
using BUS.Reporting;
namespace appWinform
{
    public partial class frmReportBill : Form
    {
        private string _maHD, _tienKhach, _tienThua;

        public string TienThua
        {
            get { return _tienThua; }
            set { _tienThua = value; }
        }

        public string TienKhach
        {
            get { return _tienKhach; }
            set { _tienKhach = value; }
        }

        public string MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }
        public frmReportBill()
        {
            InitializeComponent();
        }

        private void frmReportBill_Load(object sender, EventArgs e)
        {
            CrystalReportBill reportHD = new CrystalReportBill();

            reportHD.Refresh();
            reportHD.SetParameterValue("@idHD", MaHD);

            reportHD.SetParameterValue("TienKhach", TienKhach);
            reportHD.SetParameterValue("TienThua", TienThua);
            

            this.rpBill.ReportSource = reportHD;
        }

        private void rpBill_Load(object sender, EventArgs e)
        {

        }
    }
}
