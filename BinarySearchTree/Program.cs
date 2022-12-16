using System;
using System.Diagnostics.CodeAnalysis;

namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 20,50,30,40,60,80,70};

            BinaryTree tree = new BinaryTree();
            tree.createTree(a);
            Console.WriteLine("Duyet theo level:");
            tree.TravelLevel();

            Console.WriteLine("\n");
            Console.WriteLine("Duyet NLR:");
            tree.duyetNLR();
            Console.WriteLine();
            Console.WriteLine("Duyet LNR:");
            tree.duyetLNR();
            Console.WriteLine();
            Console.WriteLine("Duyet LRN:");
            tree.duyetLRN();

            int X = 30;
            //Node x = tree.Search(X);
            Node x = tree.searchNonRev(X);
            Console.WriteLine("\n");
            if (x==null) { Console.WriteLine("khong tim thay!"); }
            else
            {
                Console.WriteLine("tim thay!");
            }
            Console.WriteLine();
            Node max;
            if ((max = tree.findMax())!=null) { Console.WriteLine("max node: "+max.value); }

            Console.WriteLine("So nut cua cay la:"+tree.demNode());
            Console.WriteLine("So nut la cua cay la:" + tree.demNutLa());
            Console.WriteLine("So nut le cua cay la:" + tree.demNutLe());
            Console.WriteLine("So nut chan cua cay la:" + tree.demNutChan());
            Console.WriteLine("So nut duong cua cay la:" + tree.demNutDuong());
            Console.WriteLine("So nut am cua cay la:" + tree.demNutAm());
            Console.WriteLine("So nut co mot con cua cay la:" + tree.demNutCoMotCon());
            Console.WriteLine("So nut co hai con cua cay la:" + tree.demNutCoHaiCon());
            Console.WriteLine("Tong cac nut cua cay la:" + tree.Tong());
            Console.WriteLine("Tong nut la cua cay la:" + tree.TongLa());

           
            tree.DemTong();
            Console.WriteLine("Chieu cao la cua cay la:" + tree.ChieuCao());
        }
    }
}
