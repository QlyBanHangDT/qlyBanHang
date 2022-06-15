using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_ThongKeCMT
    {
        public List<BinhLuan> getBinhLuan(string pMaSP)
        {
            return new DAL_ThongKeCMT().getBinhLuan(pMaSP);
        }

        public List<BinhLuan> PhanTichBinhLuan(string pMaSP)
        {
            return getBinhLuan(pMaSP).Select(bl => new BinhLuan
             {
                 CauBinhLuan = bl.CauBinhLuan,
                 DanhGia = new BUS_AI().getResult(bl.CauBinhLuan)
             }).ToList();
        }
    }
}
