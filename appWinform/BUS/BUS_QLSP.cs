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
    public class BUS_QLSP
    {
        private DataTable_SPTableAdapter db = new DataTable_SPTableAdapter();

        public DataTable getDSSP()
        {
            return db.GetDataSP();
        }
    }
}
