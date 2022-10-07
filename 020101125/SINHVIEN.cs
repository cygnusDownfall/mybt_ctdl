using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class SINHVIEN
    {
        float  toan, van, anh;
        int sbd;
        public int SBD { get { return sbd; }  }
        public float Toan { get { return toan; } }   
        public float Van { get { return van; } }  
        public float Anh { get { return anh; } }  
        public float diemtong { get => toan + van + anh; }
        public SINHVIEN()
        {

        }
        public SINHVIEN(int Sbd,float dtoan,float dvan,float danh)
        {
            sbd = Sbd;
            toan = dtoan;
            van = dvan;
            anh = danh;

        }
    }
}
