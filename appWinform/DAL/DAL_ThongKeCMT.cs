using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ThongKeCMT
    {
        QlyBanHangDataContext db = new QlyBanHangDataContext();

        public List<BinhLuan> getBinhLuan(string pMaSP)
        {
            return db.THONGKECMTs.Where(bl => bl.ID_SP.Equals(pMaSP))
                .Select(bl => new BinhLuan
                {
                    CauBinhLuan = bl.NOIDUNG
                }).ToList();
        }
    }
}
