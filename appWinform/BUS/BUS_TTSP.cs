using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class BUS_TTSP
    {
        DAL_ThongTinSanPham _ttsp = new DAL_ThongTinSanPham();
        public List<CauHinh> getCauHinh(string pMaSP)
        {
            return _ttsp.getCauHinh(pMaSP);
        }

        public string getTenSP(string pMaSP)
        {
            return _ttsp.getTenSP(pMaSP);
        }

        public string getTenHang(string pMaSP)
        {
            return _ttsp.getTenHang(pMaSP);
        }

        public string getTenLoai(string pMaSP)
        {
            return _ttsp.getTenLoai(pMaSP);
        }

        public double? getGiaBan(string pMaSP)
        {
            return _ttsp.getGiaBan(pMaSP);
        }
    }
}
