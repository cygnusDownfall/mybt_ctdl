using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class SINHVIEN
    {
        int sbd, toan, van, anh;
        public int SBD { get { return sbd; }  }
        public int Toan { get { return toan; } }   
        public int Van { get { return van; } }  
        public int Anh { get { return anh; } }  
        public SINHVIEN()
        {

        }
        public SINHVIEN(int Sbd,int dtoan,int dvan,int danh)
        {
            sbd = Sbd;
            toan = dtoan;
            van = dvan;
            anh = danh;

        }
    }
}
