using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SaveConfig
    {
        public static void Save(string pSrv, string pUs, string pPw, string pDb)
        {
            Properties.Settings.Default.QLDT_LKConnectionString = "Data Source=" + pSrv +
                                                    ";Initial Catalog=" + pDb +
                                                    ";User ID=" + pUs +
                                                    ";pwd=" + pPw;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }
    }
}
