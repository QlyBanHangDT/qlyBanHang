using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.DAL_DataSetTableAdapters;

namespace DAL
{
    public class DAL_QLKH
    {
        private DataTableQL_KHTableAdapter db = new DataTableQL_KHTableAdapter();
        private QlyBanHangDataContext qlbh = new QlyBanHangDataContext();

        public DataTable getDSKH()
        {
            return db.GetDataQLKH();
        }

        public DataTable findKHs(string pTenKH)
        {
            return db.GetDataBy(pTenKH);
        }

        public double? tongBan(string pID)
        {
            return db.TongBan(pID);
        }

        public bool capNhatThongTin(THONGTINTAIKHOAN tttk, string pID)
        {
            try
            {
                // tiến thành cập nhật thông tin khách hàng
                THONGTINTAIKHOAN _tttk = qlbh.THONGTINTAIKHOANs.Where(kh => kh.ID_TAIKHOAN == pID).FirstOrDefault();

                // cập nhật từng thuộc tính
                _tttk.HOTEN = tttk.HOTEN;
                _tttk.SDT = tttk.SDT;
                _tttk.EMAIL = tttk.EMAIL;
                _tttk.NGSINH = tttk.NGSINH;
                _tttk.GTINH = tttk.GTINH;

                // lưu sự thay đổi xuống db
                qlbh.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public KhachHang getKhachHang_sdt(string pSDT)
        {
            string id_tk = qlbh.KHACHHANGs.Where(kh =>
                kh.TAIKHOAN.THONGTINTAIKHOANs.Where(tttk => 
                    tttk.ID_TAIKHOAN == kh.ID_TK).First().SDT == pSDT)
                .Select(k => k.ID_TK).FirstOrDefault();

            return qlbh.THONGTINTAIKHOANs.Where(
                _ttkh => _ttkh.ID_TAIKHOAN == id_tk).Select(kh => new KhachHang
                {
                    Id = id_tk,
                    Ten = kh.HOTEN,
                    Sdt = kh.SDT,
                    Email = kh.EMAIL,
                    GioiTinh = kh.GTINH == true ? "Nam" : "Nữ",
                    NgaySinh = string.Format("{0:dd/MM/yyyy}", kh.NGSINH),
                    NgayTao = string.Format("{0:dd/MM/yyyy}", kh.NGTAO),
                    DiaChi = kh.DCHI
                }).Single();
        }

        public KhachHang getKhachHang(string pID)
        {
            string id_tk = qlbh.KHACHHANGs.Where(kh => kh.ID == pID).Select(k => k.ID_TK).FirstOrDefault();

            return qlbh.THONGTINTAIKHOANs.Where(
                _ttkh => _ttkh.ID_TAIKHOAN == id_tk).Select(kh => new KhachHang
                {
                    Id = id_tk,
                    Ten = kh.HOTEN,
                    Sdt = kh.SDT,
                    Email = kh.EMAIL,
                    GioiTinh = kh.GTINH == true ? "Nam" : "Nữ",
                    NgaySinh = string.Format("{0:dd/MM/yyyy}", kh.NGSINH),
                    NgayTao = string.Format("{0:dd/MM/yyyy}", kh.NGTAO)
                }).Single();
        }
        public object getChiTietHoaDon(string pIDKH)
        {
            return qlbh.sp_ChiTietDonHang_kh(pIDKH);
        }
        public bool themKhachHang(KhachHang kh)
        {
            try
            {
                // thêm thông tin tài khoản
                // tài khoản
                qlbh.sp_AddAcc_KH(
                    kh.Ten,
                    DateTime.ParseExact(kh.NgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    kh.GioiTinh,
                    kh.Email,
                    kh.Sdt,
                    kh.DiaChi);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
