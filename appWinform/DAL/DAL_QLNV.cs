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

        public bool capNhatThongTinNV(THONGTINTAIKHOAN nv, string username)
        {
            try
            {
                string id_tk = qlbh.TAIKHOANs.Where(tk => tk.USERNAME == username).Select(t => t.ID).FirstOrDefault();
                THONGTINTAIKHOAN _tttk = qlbh.THONGTINTAIKHOANs.Where(tt => tt.ID_TAIKHOAN == id_tk).FirstOrDefault();

                _tttk.HOTEN = nv.HOTEN;
                _tttk.NGSINH = nv.NGSINH;
                _tttk.SDT = nv.SDT;
                _tttk.EMAIL = nv.EMAIL;
                _tttk.DCHI = nv.DCHI;
                _tttk.GTINH = nv.GTINH;

                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string getID(string pID)
        {
            return qlbh.NHANVIENs.Where(nv => nv.ID_TK.Equals(pID)).First().ID;
        } 
    }
}
