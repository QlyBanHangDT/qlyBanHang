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
    }
}
