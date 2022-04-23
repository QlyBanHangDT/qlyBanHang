using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_QLNND // quản lý nhóm người dùng
    {
        private QlyBanHangDataContext db = new QlyBanHangDataContext();
        DAL_QLTK qltk = new DAL_QLTK();

        public bool addToGr(int pIdGr, string pIdTK)
        {
            try
            {
                db.NHOMNGUOIDUNGs.InsertOnSubmit(new NHOMNGUOIDUNG
                {
                    ID_GR = pIdGr,
                    ID_TK = pIdTK
                });
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DelToGr(int pIdGr, string pIdTK)
        {
            try
            {
                var nnd = db.NHOMNGUOIDUNGs.Where(nd => nd.ID_GR == pIdGr && nd.ID_TK == pIdTK).Single();

                //db.NHOMNGUOIDUNGs.deAttach(nnd);
                db.NHOMNGUOIDUNGs.DeleteOnSubmit(nnd);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<GRTK> getGrs()
        {
            return db.GRTKs.ToList();
        }

        public bool themNhom(string pTenNhom)
        {
            try
            {
                db.GRTKs.InsertOnSubmit(new GRTK
                {
                    TEN = pTenNhom
                });
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool xoaNhom(string pTenNhom)
        {
            try
            {
                var gr = db.GRTKs.Where(g => g.TEN == pTenNhom).Single();

                if (qltk.getDSNhomTK(gr.ID).Count() > 0)
                {
                    throw new Exception("Còn user trong nhóm.Vui lòng thử lại");
                }

                db.GRTKs.DeleteOnSubmit(gr);
                db.SubmitChanges();
            }
            catch (Exception err)
            {
                throw err;
            }
            return true;
        }

        public bool chinhSua(int pID, string pTenNhom)
        {
            try
            {
                GRTK gr = db.GRTKs.Where(g => g.ID == pID).Single();
                gr.TEN = pTenNhom;

                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool isExists(string pTenNhom)
        {
            if (db.GRTKs.Where(g => g.TEN == pTenNhom).Count() != 0)
                return true;

            return false;
        }
    }
}
