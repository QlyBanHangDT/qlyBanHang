using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class BUS_QLNND
    {
        DAL_QLNND dal_qlnnd = new DAL_QLNND();
        
        public bool addToGr(int pIdGr, string pIdTK)
        {
            return dal_qlnnd.addToGr(pIdGr, pIdTK);
        }

        public bool DelToGr(int pIdGr, string pIdTK)
        {
            return dal_qlnnd.DelToGr(pIdGr, pIdTK);
        }

        public List<GRTK> getGrs()
        {
            return dal_qlnnd.getGrs();
        }

        public bool isExists(string pTenNhom)
        {
            return dal_qlnnd.isExists(pTenNhom);
        }

        public bool chinhSua(int pID, string pTenNhom) 
        {
            return dal_qlnnd.chinhSua(pID, pTenNhom);
        }

        public bool themNhom(string pTenNhom)
        {
            return dal_qlnnd.themNhom(pTenNhom);
        }
        public bool xoaNhom(string pTenNhom)
        {
            try
            {
                return dal_qlnnd.xoaNhom(pTenNhom);
            }
            catch (Exception err)
            {
                
                throw err;
            }
        }
    }
}
