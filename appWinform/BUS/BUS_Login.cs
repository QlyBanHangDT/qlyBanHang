using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Login
    {
        DAL_Login dalLogin = new DAL_Login();

        public LoginResult Check_User(string pUsername, string pPw)
        {
            try
            {
                return dalLogin.Check_User(pUsername, pPw);
            }
            catch (Exception e)
            {
                throw e; // lỗi cấu hình || server
            }
        }
    }
}
