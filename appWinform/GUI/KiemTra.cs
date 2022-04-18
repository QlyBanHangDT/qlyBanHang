using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GUI
{
    public class KiemTra
    {
        public static bool CK_Email(string pEmail) 
        {
            try 
	        {	        
		        MailAddress m = new MailAddress(pEmail);
                return true;
	        }
	        catch (FormatException)
	        {
		        return false;
	        }
        }
        public static bool CK_SDT(string pSDT)
        {
            // số điện thoại được định dạng theo sdt ở Việt Nam
            // - gồm 10 số
            // - 2 số đầu tiên có thể là các số: 84, 03, 05, 07, 08, 09
            Regex rg = new Regex(@"^(84|0[3|5|7|8|9])+([0-9]{8})$");

            return rg.IsMatch(pSDT);
        }
        public static bool CK_Gtinh(string pGtinh)
        {
            // nam trả về true
            return pGtinh.Trim().ToLower().Equals("nam") || pGtinh.Trim().ToLower().Equals("nữ");
        }
    }
}
