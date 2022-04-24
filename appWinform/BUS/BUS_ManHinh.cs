using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class BUS_ManHinh
    {
        DAL_ManHinh dal_mh = new DAL_ManHinh();
        public List<MANHINH> getManHinh()
        {
            return dal_mh.getMH();
        }

        public bool themManHinh(string pMaMH, string pTenMH)
        {
           return dal_mh.themMH(pMaMH,pTenMH);
        }

        public bool xoaManHinh(string pMaMH)
        {
            return dal_mh.xoaMH(pMaMH);
        }

        public bool suaManHinh(string pMaMH, string pTenMH)
        {
            return dal_mh.suaMH(pMaMH, pTenMH);
        }

        public bool kt_KhoaManHinh(string pMaMH)
        {
            return dal_mh.kt_KhoaMH(pMaMH);
        }
    }
}
