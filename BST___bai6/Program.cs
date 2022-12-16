using System;

namespace BST___bai6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 5, 8, 8, 5, 0, 8, 8, 9, 5, 1, 1, 1, 1, 1, 1 };
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.createTree(a);
            Console.WriteLine("So luong gia tri phan biet la:"+ binaryTree.demNode());
            Console.WriteLine();
            Console.WriteLine("Cac gia tri phan biet la:" );
            binaryTree.duyetLNR();

            Console.WriteLine();
            Console.WriteLine("gia tri phan biet va so lan ");
            binaryTree.InKeyCount();
        }
    }
}
