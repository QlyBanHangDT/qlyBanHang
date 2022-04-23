using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;

namespace BUS
{
    public class BUS_QLSP
    {
        DAL_QLSP dal_qlsp = new DAL_QLSP();

        public DataTable getDSSP()
        {
            return dal_qlsp.getDSSP();
        }
    }
}
