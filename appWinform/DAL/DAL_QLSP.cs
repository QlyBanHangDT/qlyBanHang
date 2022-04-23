using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DAL_DataSetTableAdapters;

namespace DAL
{
    public class DAL_QLSP
    {
        private DataTable_SPTableAdapter db = new DataTable_SPTableAdapter();

        public DataTable getDSSP()
        {
            return db.GetDataSP();
        }
    }
}
