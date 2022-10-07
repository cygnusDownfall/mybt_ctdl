using System;
using System.Collections.Generic;
using System.IO;

namespace _020101125
{
    public  class DSSV
    {
        List<SINHVIEN> ds;
        public int count { get => ds.Count; }
        public List<SINHVIEN> DanhsachSV { get => ds; set { } }  
        public DSSV()
        {
            ds = new List<SINHVIEN> ();

        }
        void Readfromfile(string filepath)
        {
            using (StreamReader rd = new StreamReader(filepath))
            {
                int i = 0;
                while (rd.EndOfStream)
                {

                    ds[i] = new SINHVIEN();
                    i++;
                }
            }
        }
        void Writefile(string filepath)
        {
            using (StreamWriter wt = new StreamWriter(filepath))
            {

            }
        }
        void SapXep()
        {

        }
    }
}
