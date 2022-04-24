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
    }
}
