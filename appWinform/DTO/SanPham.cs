using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public SanPham()
        {

        }
        string _id, _tenSP, _tenHang, _tenLoai, _tenDanhMuc, _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string TenDanhMuc
        {
            get { return _tenDanhMuc; }
            set { _tenDanhMuc = value; }
        }

        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }

        public string TenHang
        {
            get { return _tenHang; }
            set { _tenHang = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        double? _gia;

        public double? Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }
    }
}
