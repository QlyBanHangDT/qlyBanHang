using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NCC
    {
        QlyBanHangDataContext db = new QlyBanHangDataContext();

        public List<NCC> getNCCs()
        {
            return db.NCCs.ToList();
        }

        public bool IsExists(string pTenNCC)
        {
            return db.NCCs.Where(ncc => ncc.TENNCC.ToLower() == pTenNCC.ToLower()).Count() > 0;
        }

        public bool themNCC(string pTenNCC)
        {
            try
            {
                db.NCCs.InsertOnSubmit(new NCC {
                    TENNCC = pTenNCC
                });

                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
