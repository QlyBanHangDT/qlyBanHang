using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GrTaiKhoan
    {
        private string ten;
        private int _id;

        public GrTaiKhoan()
        {

        }

        public GrTaiKhoan(int pId, string pTen)
        {
            this._id = pId;
            this.ten = pTen;
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public int IdGr
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
