using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanQuyen
    {
        private int _idGr;
        private string _idMH;
        private bool _coQuyen;

        public PhanQuyen()
        {

        }

        public bool CoQuyen
        {
            get { return _coQuyen; }
            set { _coQuyen = value; }
        }

        public string IdMH
        {
            get { return _idMH; }
            set { _idMH = value; }
        }

        public int IdGr
        {
            get { return _idGr; }
            set { _idGr = value; }
        }
    }
}
