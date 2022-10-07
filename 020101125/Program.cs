using System;

namespace _020101125
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
        }
        void test()
        {
            //Console.Write("nhap file path input:");
            //string inputfile = Console.ReadLine();

            Console.Write("nhap file path output:");
            string outputfile = Console.ReadLine();

            DSSV ds = new DSSV(@"F:\etc\diemtest.csv", outputfile);
        }
    }
}
