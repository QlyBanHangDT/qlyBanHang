using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang : TaiKhoan
    {
        string _sdt, _email, _id, _ten, _gioiTinh, _ngaySinh, _ngayTao, _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public KhachHang() { }

        public KhachHang(string pId, string pTen, string ngaySinh=null, string gioiTinh=null, string pSDT=null, string pEmail=null)
        {
            Id = pId;
            Ten = pTen;
            Sdt = pSDT;
            Email = pEmail;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
        }

        public string NgayTao
        {
            get { return _ngayTao; }
            set { _ngayTao = value; }
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

        public string NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }

        public string ToString()
        {
            return this._ten;
        }
    }
}
