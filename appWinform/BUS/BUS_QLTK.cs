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
    public class BUS_QLTK
    {
        private QLTAIKHOANTableAdapter db = new QLTAIKHOANTableAdapter();

        public DataTable getDSTK()
        {
            return db.GetDataTK();
        }
    }
}
