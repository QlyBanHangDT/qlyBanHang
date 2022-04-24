using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }

        public static void AlertMessage(string pMessage, MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(pMessage, "Thông báo", MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ConfirmMessage(string pMessage, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(pMessage, "Thông báo", MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button1);
        }
    }
}
