using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_ThongTinSanPham
    {
        QlyBanHangDataContext qlbh = new QlyBanHangDataContext();
        public string getTenSP(string pMaSP)
        {
            return qlbh.SANPHAMs.Where(sp => sp.ID == pMaSP).Select(t => t.TENSP).FirstOrDefault();
        }

        public string getTenHang(string pMaSP)
        {
                int? id_hang = qlbh.SANPHAMs.Where(sp => sp.ID == pMaSP).Select(t => t.ID_HANG).FirstOrDefault();
                return qlbh.HANGs.Where(hg => hg.ID == id_hang).Select(t => t.TENHANG).FirstOrDefault();
        }

        public string getTenLoai(string pMaSP)
        {
            string id_loai = qlbh.SANPHAMs.Where(sp => sp.ID == pMaSP).Select(t => t.ID_LOAI).FirstOrDefault();
            return qlbh.LOAISPs.Where(loai => loai.ID == id_loai).Select(t => t.TENLOAI).FirstOrDefault();
        }

        public double getGiaBan(string pMaSP)
        {
            return qlbh.DONGIAs.Where(dg => dg.ID_SP == pMaSP).OrderByDescending(dg => dg.NGCAPNHAT).Select(dg => dg.GIA).FirstOrDefault() ?? 0;
        }

        public List<CauHinh> getCauHinh(string pMaSP)
        {
            return qlbh.CAUHINHs.Where(ch => ch.ID_SP == pMaSP).Select(t => new CauHinh
            {
                TenCauHinh = t.TENCAUHINH,
                NoiDung = t.NOIDUNGCAUHINH
            }).ToList();
        }

    }
}
