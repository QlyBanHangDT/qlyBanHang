using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_PhanQuyen
    {
        private DAL_PhanQuyen dal_phanQuyen = new DAL_PhanQuyen();

        public List<fn_PhanQuyenResult> getPhanQuyens(int pIDNhomNguoiDung)
        {
            return dal_phanQuyen.getPhanQuyens(pIDNhomNguoiDung);
        }
        public bool luuTT_PQ(QL_PHANQUYEN pq)
        {
            return dal_phanQuyen.luuTT_PQ(pq);
        }
    }
}
