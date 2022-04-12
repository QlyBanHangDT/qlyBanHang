using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Login : DBConnect
    {
        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        public LoginResult Check_User(string pUsername, string pPw)
        {
            try
            {
                string strLogin = "select * from TaiKhoan where username='" + pUsername + "' and pw='" + pPw + "'";

                SqlDataAdapter daUser = new SqlDataAdapter(strLogin, Conn);
                DataTable tb = new DataTable();
                daUser.Fill(tb);

                if (tb.Rows.Count == 0)
                    return LoginResult.Invalid;
                if (tb.Rows[0][3] == null || tb.Rows[0][3] == "False") // kiểm tra tài khoản còn hoạt động không(khóa)
                    return LoginResult.Disabled;
                return LoginResult.Success;
            }
            catch (Exception e)
            {
                throw e; // lỗi cấu hình -> yếu cầu cấu hình lại
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
        }
    }
}
