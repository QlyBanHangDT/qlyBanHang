using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NCC
    {
        DAL_NCC dal_ncc = new DAL_NCC();

        public List<NCC> getNCCs()
        {
            return dal_ncc.getNCCs();
        }
        public bool IsExists(string pTenNCC)
        {
            return dal_ncc.IsExists(pTenNCC);
        }
        public bool themNCC(string pTenNCC)
        {
            return dal_ncc.themNCC(pTenNCC);
        }
    }
}
