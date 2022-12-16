using System;

namespace danhsachlienket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList lk = new LinkedList();
            lk.Readfromfile("DanhSachSoNguyen.csv");
            lk.duyetdanhsach();
            Console.WriteLine();
            lk.writefile("fileout.txt");


            Node tmp = lk.search(26000083);
            if (tmp != null)
            {
                Console.WriteLine("tim thay " + tmp.value);
            }
            else
            {
                Console.WriteLine("khong tim thay");
            }



            //lk.Them(7777777, 3);
            //lk.duyetdanhsach();
            //Console.WriteLine();

            //lk.ThemVaoDau(222);
            //lk.duyetdanhsach();
            //Console.WriteLine();

            //lk.ThemVaoCuoi(333);
            //lk.duyetdanhsach();
            

            lk.DaoNguoc();
            lk.writefile("fileout.txt");

            for (int i = 0; i < 10; i++)
            {
                lk.Insert(new Random().Next(0, 100));
            }
            lk.duyetdanhsach();

        }
    }
}
