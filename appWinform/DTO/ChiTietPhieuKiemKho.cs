using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuKiemKho
    {
        string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        int? sl_lech, sl_thucte, sl_ton;

        public int? SL_TON
        {
            get { return sl_ton; }
            set { sl_ton = value; }
        }

        public int? SL_THUCTE
        {
            get { return sl_thucte; }
            set { sl_thucte = value; }
        }

        public int? SL_LECH
        {
            get { return sl_lech; }
            set { sl_lech = value; }
        }

        double? giatri;

        public double? GIATRI
        {
            get { return giatri; }
            set { giatri = value; }
        }
    }
}
