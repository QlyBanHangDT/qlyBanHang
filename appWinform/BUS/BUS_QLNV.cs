using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class BUS_QLNV
    {
        DAL_QLNV dal_nv = new DAL_QLNV();

        public NhanVien getNhanVien(string username)
        {
            return dal_nv.getNV(username);
        }

        public bool capNhatNV(THONGTINTAIKHOAN nv, string username)
        {
            return dal_nv.capNhatThongTinNV(nv, username);
        }
    }
}
