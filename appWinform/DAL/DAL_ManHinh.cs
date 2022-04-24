using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_ManHinh
    {
        QlyBanHangDataContext qlbh = new QlyBanHangDataContext();

        public List<MANHINH> getMH()
        {
            return qlbh.MANHINHs.ToList();
        }

        public bool themMH(string pMaMH, string pTenMH)
        {
            try
            {
                MANHINH mh = new MANHINH();
                mh.ID = pMaMH;
                mh.TENMH = pTenMH;

                qlbh.MANHINHs.InsertOnSubmit(mh);
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool xoaMH(string pMaMH)
        {
            try
            {
                MANHINH mh = qlbh.MANHINHs.Where(m => m.ID == pMaMH).FirstOrDefault();
                qlbh.MANHINHs.DeleteOnSubmit(mh);
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool suaMH(string pMaMH, string pTenMH)
        {
            try
            {
                MANHINH mh = qlbh.MANHINHs.Where(m => m.ID == pMaMH).FirstOrDefault();
                mh.TENMH = pTenMH;
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool kt_KhoaMH(string pMaMH)
        {
            if (qlbh.MANHINHs.Where(mh => mh.ID == pMaMH).Count() > 0)
                return false;
            return true;
        }
    }
}
