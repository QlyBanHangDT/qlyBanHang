using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq;
using DTO;
using DAL;
using System.Collections;

namespace BUS
{
    public class BUS_QLKH
    {
        DAL_QLKH dal_qlkh = new DAL_QLKH();

        public DataTable getDSKH()
        {
            return dal_qlkh.getDSKH();
        }

        public DataTable findKHs(string pTenKH)
        {
            return dal_qlkh.findKHs(pTenKH);
        }

        public double? tongBan(string pID)
        {
            return dal_qlkh.tongBan(pID);
        }

        public bool capNhatThongTin(THONGTINTAIKHOAN tttk, string pID)
        {
            return dal_qlkh.capNhatThongTin(tttk, pID);
            
        }

        public KhachHang getKhachHang(string pID)
        {
            return dal_qlkh.getKhachHang(pID);
        }
        public KhachHang getKhachHang_sdt(string pSDT)
        {
            return dal_qlkh.getKhachHang_sdt(pSDT);
        }
        public object getChiTietHoaDon(string pIDKH)
        {
            return dal_qlkh.getChiTietHoaDon(pIDKH);
        }
        public bool themKhachHang(KhachHang kh)
        {
            return dal_qlkh.themKhachHang(kh);
        }
    }
}
