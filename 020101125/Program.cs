using System;
using System.Diagnostics;

namespace _020101125
{
    class Program
    {
        static void Main(string[] args)
        {
            test2();
           
        }
        void test1()
        {
            //Console.Write("nhap file path input:");
            //string inputfile = Console.ReadLine();

            Console.Write("nhap file path output:");
            string outputfile = Console.ReadLine();

            DSSV ds = new DSSV(@"F:\etc\diemtest.csv", outputfile);
        }
        static void test2()
        {
           // string filein = "diemtest.txt";
            string filein = "diemthiTHPT2020TVA.csv";
            string fileout = "diemtestout.txt";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            DSSV dSSV = new DSSV(filein, fileout);
            dSSV.SapXep();
            dSSV.Writefile(fileout);
            stopwatch.Stop();
           
            Console.WriteLine("thoi gian chay: " + stopwatch.ElapsedMilliseconds);
        }
    }
}
