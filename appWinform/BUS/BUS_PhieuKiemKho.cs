using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class BUS_PhieuKiemKho
    {
        DAL_PhieuKiemKho pkk = new DAL_PhieuKiemKho();
        public List<string> loadPhieuKK()
        {
            return pkk.getPhieuKiemKho();
        }
        public int? loadSL_Lech(string pMa)
        {
            return pkk.getTongSoLuongLech(pMa);
        }
        public List<ChiTietPhieuKiemKho> loadCT_PhieuKK(string pMa)
        {
            return pkk.getCT_PKK(pMa);
        }
        public bool capNhatKiemKho(string pMa, string pMa_SP, int sl_tt, int sl_tk)
        {
            return pkk.capNhatPhieuKiemKho(pMa, pMa_SP, sl_tt, sl_tk);
        }

        public int kt_MaPhieuKK(string pMa)
        {
            return pkk.kt_MaPhieuKiemKho(pMa);
        }

        public int kt_CT_MaPhieuKK(string pMa)
        {
            return pkk.kt_CT_MaPhieuKiemKho(pMa);
        }

        public bool them_PKK(string pMa)
        {
            return pkk.themPhieuKiemKho(pMa);
        }
        public bool xoa_PKK(string pMa)
        {
            return pkk.xoaPhieu(pMa);
        }
        public int kt_CTPKK(string pMa, string pMaSP)
        {
            return pkk.kt_khoa_CTPKK(pMa, pMaSP);
        }

        public bool them_CTPKK(string id_sp, string id_pkk, int sl_tk)
        {
            return pkk.them_CT_PhieuKiemKho(id_sp, id_pkk, sl_tk);
        }

        public bool xoa_CTPKK(string id_sp, string id_pkk)
        {
            return pkk.xoa_CTPKK(id_pkk,id_sp);
        }
    }
}
