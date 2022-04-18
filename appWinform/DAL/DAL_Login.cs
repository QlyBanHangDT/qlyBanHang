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
                string strSql = "sp_CKAcc";
                this.cmd.CommandText = strSql;
                this.cmd.Connection = this.Conn;
                this.cmd.CommandType = CommandType.StoredProcedure;

                // truyền tham số cho proc
                this.cmd.Parameters.Clear();
                this.cmd.Parameters.AddWithValue("@userName", pUsername);
                this.cmd.Parameters.AddWithValue("@pw", pPw);

                SqlDataReader rd = this.cmd.ExecuteReader();

                int ck = 1;

                if (rd.Read())
                {
                    ck = int.Parse(rd["Message"].ToString());
                }
                this.close();

                if (ck == 0)
                    return LoginResult.Invalid;
                if (ck == 2) // kiểm tra tài khoản còn hoạt động không(khóa)
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
