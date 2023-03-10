using _020101125;
using System;
using System.Collections.Generic;

namespace BT_Hash_BST_LL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int index = new Hash().Hashing("dc");
            //Console.Write(index);
            Hash test= new Hash();
            // test.ReadTreeFromFile("dic.txt");
            //test.ReadTreeFromFile("dic.txt");
            test.ReadTreeFromFile("PageWordIndex.csv",true);
            string finftext=Console.ReadLine();
            List<int> pages = test.search(finftext); //sai tim thay => bug
            if (pages==null||pages.Count == 0)
            {
                Console.WriteLine("khong tim thay");
                return;
            }
           // tree<int> tree = new tree<int>();
            

            foreach(int x in pages)
            {
                Console.WriteLine(x);
            }
            test.writeFile("output.txt");
		Console.ReadKey();
        }
    }
}
