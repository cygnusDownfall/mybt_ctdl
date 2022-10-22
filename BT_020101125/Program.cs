using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;
namespace BT_020101125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            string filein = "filein.txt";
            string fileout ="fileout.txt";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            danhsachsonguyen a = new danhsachsonguyen(filein);
            a.Sort();
            a.writefile(fileout);
            
            stopwatch.Stop();
            a.writefile(fileout);
            Console.WriteLine("thoi gian chay: "+stopwatch.ElapsedMilliseconds);
        }
       
    }
}
