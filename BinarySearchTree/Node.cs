using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node()
        {
            left = right = null;
        }
        public Node(int value) { this.value = value; }

    }

}
