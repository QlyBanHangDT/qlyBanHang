using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        string _sdt, _email, _id, _ten;

        public KhachHang() { }

        public KhachHang(string pId, string pTen, string pSDT=null, string pEmail=null)
        {
            Id = pId;
            Ten = pTen;
            Sdt = pSDT;
            Email = pEmail;
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Sdt
        {
            get { return _sdt; }
            set { _sdt = value; }
        }

        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }

        public string Id
        {
            get { return _id; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Giá trị truyền vào rỗng");
                _id = value; 
            }
        }
    }
}
