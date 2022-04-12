using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace DAL
{
    public class DBConnect
    {
        private SqlConnection _conn;

        protected SqlConnection Conn
        {
            get {
                if (Properties.Settings.Default.SQLConnect == string.Empty)
                    throw new Exception("Chuỗi cấu hình không tồn tại");

                _conn = new SqlConnection(Properties.Settings.Default.SQLConnect);
                try
                {
                    if (_conn.State == System.Data.ConnectionState.Closed)
                        _conn.Open();
                }
                catch (Exception)
                {
                    throw new Exception("Chuỗi cấu hình không phù hợp"); ;
                }
                return _conn; 
            }
        }


        public static DataTable GetServername()
        {
            DataTable tb = new DataTable();
            tb = SqlDataSourceEnumerator.Instance.GetDataSources();
            return tb;
        }

        public static DataTable GetDBName(string pServerName, string pUsername, string pPw)
        {
            DataTable tb = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("select name from sys.Databases", "Data Source=" + pServerName + ";Initial Catalog=master;User ID=" + pUsername + ";pwd=" + pPw);
            da.Fill(tb);
            return tb;
        }

        public static void SaveConfig(string pSrv, string pUs, string pPw, string pDb)
        {
            Properties.Settings.Default.SQLConnect = "Data Source=" + pSrv +
                                                    ";Initial Catalog=" + pDb +
                                                    ";User ID=" + pUs +
                                                    ";pwd=" + pPw;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }
    }
}
