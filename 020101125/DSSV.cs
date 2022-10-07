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
        public DSSV(string input)
        {
            ds = new List<SINHVIEN>();
            Readfromfile(input);
            
        }
        public DSSV(string input,string output)
        {
            ds = new List<SINHVIEN>();
            Readfromfile(input);
            Writefile(output);
        }
        void Readfromfile(string filepath,bool haveheader=true)
        {
            using (StreamReader rd = new StreamReader(filepath))
            {
                string[] infos;
                int sbd,toan, van, anh;
                for (int i= 0;rd.EndOfStream ; i++)
                {
                    if (i == 1)
                    {
                        if (haveheader)
                            continue;
                    }
                    infos = rd.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (infos.Length > 0)
                    {
                        sbd = Convert.ToInt32(infos[0]);
                        toan = Convert.ToInt32(infos[1]);
                        van = Convert.ToInt32(infos[2]);
                        anh = Convert.ToInt32(infos[3]);

                        SINHVIEN sv = new SINHVIEN(sbd, toan, van, anh);
                        ds.Add(sv);
                    }
                    
                }
            }
        }
        void Writefile(string filepath)
        {
            using (StreamWriter wt = new StreamWriter(filepath))
            {
                SINHVIEN sv;
                for (int i = 0; i < count; i++)
                {
                    sv = ds[i];
                    wt.WriteLine("{0},{1},{2},{3}",sv.SBD,sv.Toan,sv.Van,sv.Anh);
                }
            }
        }

        void SapXep()
        {

        }
    }
}
