using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauHinh : SanPham
    {
        private string _tenCauHinh, _noiDung;

        public string TenCauHinh
        {
            get { return _tenCauHinh; }
            set { _tenCauHinh = value; }
        }

        public string NoiDung
        {
            get { return _noiDung; }
            set { _noiDung = value; }
        }
    }
}
