using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BinhLuan
    {
        private string _cauBinhLuan;

        public string CauBinhLuan
        {
            get { return _cauBinhLuan; }
            set { _cauBinhLuan = value.Trim().ToLower(); }
        }
        private bool _danhGia;

        public bool DanhGia
        {
            get { return _danhGia; }
            set { _danhGia = value; }
        }
    }
}
