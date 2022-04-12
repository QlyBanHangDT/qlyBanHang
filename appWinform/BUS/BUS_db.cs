using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_db 
    {
        public static DataTable GetServername()
        {
            return DAL.DBConnect.GetServername();
        }

        public static DataTable GetDBName(string pServerName, string pUsername, string pPw)
        {

            return DAL.DBConnect.GetDBName(pServerName, pUsername, pPw);
        }
        public static void SaveConfig(string pSrv, string pUs, string pPw, string pDb)
        {
            DAL.DBConnect.SaveConfig(pSrv, pUs, pPw, pDb);
        }
    }
}
