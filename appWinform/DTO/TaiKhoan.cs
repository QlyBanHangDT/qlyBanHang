using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan : GrTaiKhoan
    {
        string _idTK, _username;

        public TaiKhoan()
        {

        }
        public string IdTK
        {
            get { return _idTK; }
            set { _idTK = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}
