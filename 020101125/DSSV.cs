﻿using System;
using System.Collections.Generic;
using System.IO;

namespace _020101125
{
    public class DSSV
    {
        List<THISINH> ds;
        public int count { get => ds.Count; }
        public List<THISINH> DanhsachSV { get => ds; set { } }
        public DSSV()
        {
            ds = new List<THISINH>();

        }
        public DSSV(string input)
        {
            ds = new List<THISINH>();
            Readfromfile(input);

        }
        public DSSV(string input, string output)
        {
            ds = new List<THISINH>();
            Readfromfile(input);
            Writefile(output);
        }
        void Readfromfile(string filepath, bool haveheader = true)
        {
            using(StreamReader rd = new StreamReader(filepath))
            {
                string[] infos = new string[4];
                int sbd;
                float toan, van, anh;
                string s;
                for (int i = 0; (s = rd.ReadLine() )!= null; i++)
                {
                    if (i == 0)
                    {
                        if (haveheader)
                            continue;
                    }
                    infos =s.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (infos.Length > 0)
                    {
                        sbd = Convert.ToInt32(infos[0]);
                        toan = float.Parse(infos[1]);
                        van = float.Parse(infos[2]);
                        anh = float.Parse(infos[3]);

                        THISINH sv = new THISINH(sbd, toan, van, anh);
                        ds.Add(sv);
                    }

                }
            }
        }
        public void Writefile(string filepath)
        {
            using (StreamWriter wt = new StreamWriter(filepath))
            {
                THISINH sv;
                for (int i = 0; i < count; i++)
                {
                    sv = ds[i];
                    wt.WriteLine("{0},{1},{2},{3}", sv.SBD, sv.Toan, sv.Van, sv.Anh);
                }
            }
        }

        public void SapXep()
        {
            //Sapxep.Quick<THISINH>(ds, THISINH.sosanhtheoToan);
            //Sapxep.heapSort<THISINH>(ds,count,THISINH.sosanhtheoSBD);
            Sapxep.MergeSort<THISINH>(ds, THISINH.sosanhtheoSBD);
        }
    }
}
