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
    public class BUS_QLSP
    {
        DAL_QLSP dal_qlsp = new DAL_QLSP();

        public DataTable getDSSP()
        {
            return dal_qlsp.getDSSP();
        }
        public int getSoLuong(string pTenSP)
        {
            return dal_qlsp.getSanPham(pTenSP).IMEICODEs.Count;
        }
        public List<LOAISP> getLoai(int pIdDaMuc)
        {
            return dal_qlsp.getLoai(pIdDaMuc);
        }
        public List<DANHMUC> getDanhMuc()
        {
            return dal_qlsp.getDanhMuc();
        }
        public List<HANG> getHang()
        {
            return dal_qlsp.getHang();
        }
        public bool capNhatGia(string pId, double pGia)
        {
            return dal_qlsp.thayDoiGia(pId, pGia);
        }
        public bool capNhatTen(string pId, string pTenSP)
        {
            return dal_qlsp.thayDoiTen(pId, pTenSP);
        }
        public DataTable timKiemSP(string pTenSP)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("TENSP", typeof(string)));
            dt.Columns.Add(new DataColumn("SOLUONG", typeof(int)));
            dt.Columns.Add(new DataColumn("GIA", typeof(double)));
            dt.Columns.Add(new DataColumn("TENHANG", typeof(string)));
            dt.Columns.Add(new DataColumn("TENLOAI", typeof(string)));
            dt.Columns.Add(new DataColumn("TENDANHMUC", typeof(string)));

            dal_qlsp.timKiemSP(pTenSP).ForEach(sp =>
            {
                DataRow r = dt.NewRow();
                r["ID"] = sp.Id;
                r["TENSP"] = sp.TenSP;
                r["SOLUONG"] = sp.SoLuong;
                r["GIA"] = sp.Gia;
                r["TENHANG"] = sp.TenHang;
                r["TENLOAI"] = sp.TenLoai;
                r["TENDANHMUC"] = sp.TenDanhMuc;

                dt.Rows.Add(r);
            });
            return dt;
        }
        public bool themSP(string pTenSP, string pTenHang, double pGia, string pImage, string pTenLoai)
        {
            return dal_qlsp.themSP(new SanPham{
                TenSP = pTenSP,
                TenLoai = pTenLoai,
                TenHang = pTenHang,
                Gia = pGia,
                Image = pImage,
            });
        }
        public bool themCauHinh(string pTenSP, string pTenCauHinh, string pNoiDung)
        {
            return dal_qlsp.themCauHinh(new CauHinh
            {
                TenSP = pTenSP,
                TenCauHinh = pTenCauHinh,
                NoiDung = pNoiDung
            });
        }

        public bool isExists(string pTenSP)
        {
            return dal_qlsp.isExists(pTenSP);
        }
        public bool isCodeExists(string pImeiCode)
        {
            return dal_qlsp.isCodeExists(pImeiCode);
        }
        public bool isCodeDaBan(string pImeiCode)
        {
            return dal_qlsp.isCodeDaBan(pImeiCode);
        }
        public string getID()
        {
            return dal_qlsp.getID();
        }
        public string getID(string pImeiCode)
        {
            return dal_qlsp.getID(pImeiCode);
        }
        public List<IMEICODE> getCode(string pId)
        {
            return dal_qlsp.getCode(pId);
        }
        public string thanhToan(string pMaHD, string pTenKhachHang, string pTenNhanVien, string pImeiCode)
        {
            dal_qlsp.Kh.Ten = pTenKhachHang;
            dal_qlsp.Nv.Ten = pTenNhanVien;
            dal_qlsp.MaHD = pMaHD;

            string mes = dal_qlsp.thanhToan(pImeiCode).Message;

            return mes;
        }
        public string getMaHD()
        {
            return dal_qlsp.getMaHD();
        }
        public List<string> getNames()
        {
            return dal_qlsp.getNames();
        }
        public string getID_name(string pName)
        {
            return dal_qlsp.getID_name(pName);
        }

        public string nhapHang(string pMaPN, string pTenNCC, string pTenNhanVien, string pImeiCode)
        {
            dal_qlsp.TenNCC = pTenNCC;
            dal_qlsp.Nv.Ten = pTenNhanVien;
            dal_qlsp.MaPN = pMaPN;

            string mes = dal_qlsp.nhapHang(pImeiCode).Message;

            return mes;
        }
        public string getMaPN()
        {
            return dal_qlsp.getMaPN();
        }
        public bool themSP(string pTenSan, string pImeiCode)
        {
            return dal_qlsp.themSP(pTenSan, pImeiCode);
        }

        public int isExists_TenSP(string pTenSP)
        {
            return dal_qlsp.isExists_TenSP(pTenSP);
        }
    }
}
