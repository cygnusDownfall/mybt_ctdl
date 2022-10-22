using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BT_020101125
{
    public class danhsachsonguyen
    {
        int[] a;
        int n;
        public danhsachsonguyen(int[] m)
        {
            a = m;
        }
        public danhsachsonguyen(string filein)
        {
            Readfromfile(filein);
        }
        void Readfromfile(string filepath)
        {
            using (StreamReader rd = new StreamReader(filepath))
            {
               
                int n = Convert.ToInt32(rd.ReadLine());
                a = new int[n];
                string s;
                for (int i = 0; (s = rd.ReadLine()) != null; i++)
                {
                    a[i] = Convert.ToInt32(rd.ReadLine());
                }
                
            }
        }
        public void writefile(string filepath)
        {
            using (StreamWriter wt = new StreamWriter(filepath))
            {
                wt.WriteLine(a.Length);
                for (int i = 0; i < a.Length; i++)
                    wt.WriteLine(a[i]);
            }
        }
        public void Search()
        {

        }
        public void Sort()
        {
            //sapxep.Quick(a);
            sapxep.heapSort(a, a.Length);

            //sapxep.RadixlSort(a,a.Length);
        }
    }
}
