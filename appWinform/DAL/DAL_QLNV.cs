using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_QLNV
    {
        QlyBanHangDataContext qlbh = new QlyBanHangDataContext();
        public NhanVien getNV(string username)
        {
            string pID = qlbh.TAIKHOANs.Where(tk => tk.USERNAME == username).Select(k => k.ID).FirstOrDefault();
            string tinhTrang = qlbh.NHANVIENs.Where(nv => nv.ID_TK == pID).Select(k => k.TINHTRANG).FirstOrDefault();
            return qlbh.THONGTINTAIKHOANs.Where(
                _ttnv => _ttnv.ID_TAIKHOAN == pID).Select(nv => new NhanVien
                {
                    Ten = nv.HOTEN,
                    Sdt = nv.SDT,
                    Email = nv.EMAIL,
                    GioiTinh = nv.GTINH == true ? "Nam" : "Nữ",
                    NgaySinh = string.Format("{0:dd/MM/yyyy}", nv.NGSINH),
                    NgayTao = string.Format("{0:dd/MM/yyyy}", nv.NGTAO),
                    TinhTrang = tinhTrang,
                    DiaChi = nv.DCHI
                }).Single();
        }
    }
}
