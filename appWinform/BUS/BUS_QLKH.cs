using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_DataSetTableAdapters;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUS_QLKH
    {
        private DataTableQL_KHTableAdapter db = new DataTableQL_KHTableAdapter();

        public DataTable getDSKH()
        {
            return db.GetDataQLKH();
        }

        public DataTable findKHs(string pTenKH)
        {
            return db.GetDataBy(pTenKH);
        }
    }
}
