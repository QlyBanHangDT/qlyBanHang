﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_PhieuKiemKho
    {
        QlyBanHangDataContext qlbh = new QlyBanHangDataContext();
        public List<string> getPhieuKiemKho()
        {
            return qlbh.PHIEUKIEMKHOs.Select(k=>k.ID).ToList();
        }

        public int? getTongSoLuongLech(string pMaPKK)
        {
            return qlbh.PHIEUKIEMKHOs.Where(k => k.ID == pMaPKK).Select(t => t.TONGSLLECH).FirstOrDefault();
        }

        public List<ChiTietPhieuKiemKho> getCT_PKK(string pMa)
        {
            return qlbh.CT_PHIEUKIEMKHOs.Where(k => k.ID_PKK == pMa).Select(t => new ChiTietPhieuKiemKho{
                ID_SP = t.ID_SP,
                SL_LECH = t.SL_LECH,
                SL_THUCTE = t.SL_THUCTE,
                SL_TON = t.SL_TONKHO,
                GIATRI = t.GIATRILECH
            }).ToList();
        }

        //Cập nhật phiếu kiểm kho và chi tiết phiếu kiểm kho
        public bool capNhatPhieuKiemKho(string pMa, string pMa_SP, int sl_tt, int sl_tk)
        {
            try
            {
                //Cập nhật chi tiết phiếu kiểm kho
                double? giaBan = qlbh.DONGIAs.Where(dg => dg.ID_SP == pMa_SP).Select(t => t.GIA).FirstOrDefault();
                CT_PHIEUKIEMKHO ct = qlbh.CT_PHIEUKIEMKHOs.Where(k => k.ID_PKK == pMa && k.ID_SP == pMa_SP).FirstOrDefault();
                ct.SL_TONKHO = sl_tk;
                ct.SL_THUCTE = sl_tt;
                int? sl_lech = sl_tk - sl_tt;
                ct.SL_LECH = sl_lech;
                ct.GIATRILECH = sl_lech * giaBan;
                qlbh.SubmitChanges();

                //Cập nhật phiếu kierm kho
                PHIEUKIEMKHO pkk = qlbh.PHIEUKIEMKHOs.Where(pk => pk.ID == pMa).FirstOrDefault();
                pkk.TONGSLLECH = qlbh.CT_PHIEUKIEMKHOs.Where(k => k.ID_PKK == pMa).Sum(t=>t.SL_LECH);
                DateTime dt = DateTime.Now;
                pkk.THOIGIANLAP = dt.TimeOfDay;
                pkk.NGLAP = DateTime.Today;
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int kt_MaPhieuKiemKho(string pMa)
        {
            return qlbh.PHIEUKIEMKHOs.Where(t => t.ID == pMa).Count();
        }

        //Kiểm tra có tồn tại chi tiết hay không
        public int kt_CT_MaPhieuKiemKho(string pMa)
        {
            return qlbh.CT_PHIEUKIEMKHOs.Where(t => t.ID_PKK == pMa).Count();
        }

        public bool themPhieuKiemKho(string pMa)
        {
            try
            {
                DateTime dt = DateTime.Now;
                PHIEUKIEMKHO pk = new PHIEUKIEMKHO
                {
                    ID = pMa,
                    NGLAP = DateTime.Today,
                    THOIGIANLAP = DateTime.Now.TimeOfDay,
                    TONGSLLECH = null,
                };
                qlbh.PHIEUKIEMKHOs.InsertOnSubmit(pk);
                qlbh.SubmitChanges();
            return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool xoaPhieu(string pMa)
        {
            try
            {
                PHIEUKIEMKHO pk = qlbh.PHIEUKIEMKHOs.Where(t => t.ID == pMa).FirstOrDefault();
                qlbh.PHIEUKIEMKHOs.DeleteOnSubmit(pk);
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int kt_khoa_CTPKK(string pMa, string pMaSP)
        {
            return qlbh.CT_PHIEUKIEMKHOs.Where(t => t.ID_SP == pMaSP && t.ID_PKK == pMa).Count();
        }

        public bool them_CT_PhieuKiemKho(string id_sp, string id_pkk, int sl_ton)
        {
            try
            {
                CT_PHIEUKIEMKHO ctpk = new CT_PHIEUKIEMKHO
                {
                    ID_PKK = id_pkk,
                    ID_SP = id_sp,
                    SL_TONKHO = sl_ton,
                    SL_LECH = null,
                    SL_THUCTE = null
                };
                qlbh.CT_PHIEUKIEMKHOs.InsertOnSubmit(ctpk);
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool xoa_CTPKK(string pMa, string pMaSP)
        { 
            try{
                CT_PHIEUKIEMKHO ct = qlbh.CT_PHIEUKIEMKHOs.Where(t => t.ID_SP == pMaSP && t.ID_PKK == pMa).FirstOrDefault();
                qlbh.CT_PHIEUKIEMKHOs.DeleteOnSubmit(ct);
                qlbh.SubmitChanges();
                return true;
              }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
