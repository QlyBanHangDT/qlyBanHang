using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        string _sdt, _email, _ten, _gioiTinh, _ngaySinh, _ngayTao, _tinhTrang, _diaChi;


        public NhanVien(string pTen, string ngaySinh = null, string gioiTinh = null, string pSDT = null, string pEmail = null, string pTinhTrang = null, string pNgayTao=null, string pDiaChi = null)
        {
            Ten = pTen;
            Sdt = pSDT;
            Email = pEmail;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            TinhTrang = pTinhTrang;
            NgayTao = pNgayTao;
            DiaChi = pDiaChi;
        }

        public NhanVien()
        {
            // TODO: Complete member initialization
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public string TinhTrang
        {
            get { return _tinhTrang; }
            set { _tinhTrang = value; }
        }

        public string NgayTao
        {
            get { return _ngayTao; }
            set { _ngayTao = value; }
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

        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
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
    }
}
