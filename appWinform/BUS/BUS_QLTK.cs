using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_DataSetTableAdapters;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_QLTK
    {
        private QlyBanHangDataContext db = new QlyBanHangDataContext();

        public List<TAIKHOAN> getDSTK()
        {
            return db.TAIKHOANs.Where(tk => tk.USERNAME != string.Empty).ToList();
        }

        public List<GrTaiKhoan> lstNhomNguoiDung(string pUsername)
        {
            return db.TAIKHOANs.Join(
                db.NHOMNGUOIDUNGs,
                tk => tk.ID,
                nnd => nnd.ID_TK,
                (tk, nnd) => new GrTaiKhoan
                {
                    Id = nnd.ID_GR
                }).ToList();
        }
        public List<PhanQuyen> lstManHinh(int pIdGr)
        {
            return db.QL_PHANQUYENs.Where(pq => pq.ID_GRTK == pIdGr).Select(pq => new PhanQuyen
            {
                IdGr = pq.ID_GRTK,
                IdMH = pq.ID_MH,
                CoQuyen = pq.COQUYEN
            }).ToList();
        }


        public bool isExists(string pU)
        {
            if (db.TAIKHOANs.Where(tk => tk.USERNAME == pU).Count() != 0)
                return true;

            return false;
        }

        public bool themTK(string pU, string pP)
        {
            try
            {
                db.sp_AddAcc(pU, pP, pU, DateTime.Now.Date, "nam", string.Empty, string.Empty, string.Empty, "NV");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool capNhatTK(string pU, string pP, bool ck)
        {
            try
            {
                db.sp_ChangeAcc(pU, pP);
                TAIKHOAN tk = db.TAIKHOANs.Where(t => t.USERNAME == pU).FirstOrDefault();
                tk.HOATDONG = ck;

                db.SubmitChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool xoaTK(string pID)
        {
            try
            {
                NHANVIEN ttnv = db.NHANVIENs.Where(nv => nv.ID_TK == pID).FirstOrDefault();
                ttnv.TINHTRANG = "Đã nghỉ";
                ttnv.TAIKHOAN.USERNAME = null;
                ttnv.TAIKHOAN.PW = null;                

                db.SubmitChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
