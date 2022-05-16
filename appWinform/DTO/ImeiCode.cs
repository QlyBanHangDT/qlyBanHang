using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImeiCode
    {
        string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        public ImeiCode()
        {

        }
        string ma;

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        byte[] hinh;

        public byte[] Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }
    }
}
