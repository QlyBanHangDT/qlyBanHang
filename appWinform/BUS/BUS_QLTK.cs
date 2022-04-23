using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_QLTK
    {
        DAL_QLTK dal_qltk = new DAL_QLTK();

        public List<TAIKHOAN> getDSTK()
        {
            return dal_qltk.getDSTK();
        }

        public List<TaiKhoan> getDSTK(int pNhomNguoiDung)
        {
            return dal_qltk.getDSTK(pNhomNguoiDung);
        }

        public List<TaiKhoan> getDSNhomTK(int pNhomNguoiDung)
        {
            return dal_qltk.getDSNhomTK(pNhomNguoiDung);
        }


        public List<TaiKhoan> lstNhomNguoiDung(string pUsername)
        {
            return dal_qltk.lstNhomNguoiDung(pUsername);
        }
        public List<PhanQuyen> lstManHinh(int pIdGr)
        {
            return dal_qltk.lstManHinh(pIdGr);
        }


        public bool isExists(string pU)
        {
            return dal_qltk.isExists(pU);
        }

        public bool themTK(string pU, string pP)
        {
            return dal_qltk.themTK(pU, pP);
        }

        public bool capNhatTK(string pU, string pP, bool ck)
        {
            return dal_qltk.capNhatTK(pU, pP, ck);
        }


        public bool xoaTK(string pID)
        {
            return dal_qltk.xoaTK(pID);
        }
    }
}
