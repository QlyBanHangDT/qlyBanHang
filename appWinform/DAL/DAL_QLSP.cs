using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DAL_DataSetTableAdapters;
using DTO;

namespace DAL
{
    public class DAL_QLSP
    {
        private DataTable_SPTableAdapter db = new DataTable_SPTableAdapter();
        private QlyBanHangDataContext dbLq = new QlyBanHangDataContext();

        private NhanVien _nv;
        private KhachHang _kh;
        private string _maHD;

        private string _maPN;
        private string _tenNCC;

        public string MaPN
        {
            get { return _maPN; }
            set { _maPN = value; }
        }

        public string TenNCC
        {
            get { return _tenNCC; }
            set { _tenNCC = value; }
        }

        public string MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }

        public KhachHang Kh
        {
            get {
                if (_kh == null)
                    _kh = new KhachHang();
                return _kh; 
            }
            set { _kh = value; }
        }

        public NhanVien Nv
        {
            get {
                if (_nv == null)
                    _nv = new NhanVien();
                return _nv; 
            }
            set { _nv = value; }
        }

        public SANPHAM getSanPham(string pTenSP)
        {
            return dbLq.SANPHAMs.Where(sp => sp.TENSP.Equals(pTenSP)).Single();
        }

        public DataTable getDSSP()
        {
            return db.GetDataSP();
        }
        public List<LOAISP> getLoai(int pIdDaMuc)
        {
            return dbLq.LOAISPs.Where(l => l.IDDM == pIdDaMuc).ToList();
        }
        public List<DANHMUC> getDanhMuc()
        {
            return dbLq.DANHMUCs.ToList();
        }
        public List<HANG> getHang()
        {
            return dbLq.HANGs.ToList();
        }
        public List<SanPham> timKiemSP(string pTenSP)
        {
            return dbLq.SANPHAMs.Where(sp => sp.TENSP.Contains(pTenSP)).Select(sp => new SanPham
            {
                Id = sp.ID,
                TenSP = sp.TENSP,
                SoLuong = dbLq.IMEICODEs.Where(imei => imei.ID_SP == sp.ID).Count(),
                Gia = dbLq.DONGIAs.Where(dg => dg.ID_SP == sp.ID).OrderByDescending(dg => dg.NGCAPNHAT).Select(dg => dg.GIA).FirstOrDefault() ?? 0,
                TenDanhMuc = dbLq.DANHMUCs.Where(d => d.ID == sp.LOAISP.IDDM).Single().TENDANHMUC,
                TenHang = sp.HANG.TENHANG ?? string.Empty,
                TenLoai = sp.LOAISP.TENLOAI
            }).ToList();
        }

        public bool thayDoiGia(string pId, double pGia)
        {
            try
            {
                dbLq.DONGIAs.InsertOnSubmit(new DONGIA { 
                    ID_SP = pId,
                    GIA = pGia,
                    NGCAPNHAT = DateTime.Now
                });
                dbLq.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool thayDoiTen(string pId, string pTenSp)
        {
            try
            {
                var _sp = dbLq.SANPHAMs.Where(sp => sp.ID == pId).Single();

                _sp.TENSP = pTenSp;

                dbLq.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool themSP(SanPham sp)
        {
            try
            {
                dbLq.sp_AddSP(sp.TenSP, sp.TenHang, sp.Gia, string.Empty, sp.Image, sp.TenLoai);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool themCauHinh(CauHinh ch)
        {
            try
            {
                dbLq.sp_AddCauHinh(ch.TenSP, ch.TenCauHinh, ch.NoiDung);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool isExists(string TenSP)
        {
            return dbLq.SANPHAMs.Where(sp => sp.TENSP == TenSP).Count() > 0;
        }

        public int isExists_TenSP(string pTenSP)
        {
            return dbLq.SANPHAMs.Where(sp => sp.TENSP == pTenSP).Count();
        }

        public bool isCodeExists(string pImeiCode)
        {
            return dbLq.IMEICODEs.Where(sp => sp.MA == pImeiCode).Count() > 0;
        }
        public bool isCodeDaBan(string pImeiCode)
        {
            return dbLq.IMEICODEs.Where(sp => sp.MA == pImeiCode && !(sp.TRANGTHAI ?? false)).Count() > 0;
        }
        public string getID()
        {
            return dbLq.fn_autoIDSP();
        }
        public string getID(string pImeiCode)
        {
            return dbLq.IMEICODEs.Where(sp => sp.MA == pImeiCode).First().ID_SP;
        }
        public bool themSP(string pTenSan, string pImeiCode)
        {
            string maSp = dbLq.SANPHAMs.Where(sp => sp.TENSP == pTenSan).Single().ID;

            try
            {
                dbLq.IMEICODEs.InsertOnSubmit(new IMEICODE{
                    ID_SP = maSp,
                    MA = pImeiCode,
                    TRANGTHAI= true
                });
                dbLq.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public string getID_name(string pName)
        {
            var ttSP = dbLq.SANPHAMs.Where(sp => sp.TENSP.Equals(pName)).FirstOrDefault();
            return ttSP == null ? string.Empty : ttSP.ID;
        }
        public List<IMEICODE> getCode(string pId)
        {
            return dbLq.IMEICODEs.Where(code => code.ID_SP == pId && (code.TRANGTHAI ?? false)).ToList();
        }
        public sp_AddHDResult thanhToan(string pImeiCode)
        {
            return dbLq.sp_AddHD(_maHD, Kh.Ten, Nv.Ten, pImeiCode).Single();
        }
        public string getMaHD()
        {
            string maHD = string.Empty;
            dbLq.sp_GetMaHD(ref maHD);
            return maHD;
        }

        public List<string> getNames()
        {
            return dbLq.SANPHAMs.Select(sp => sp.TENSP).ToList(); 
        }

        public sp_AddPNResult nhapHang(string pImeiCode)
        {
            return dbLq.sp_AddPN(MaPN, TenNCC, Nv.Ten, pImeiCode).Single();
        }
        public string getMaPN()
        {
            string maPN = string.Empty;
            dbLq.sp_GetMaPN(ref maPN);
            return maPN;
        }
    }
}
