using System;
using System.Collections.Generic;
using System.Text;

namespace BST___bai6
{
    public class Node
    {
        public int count;
        public int key;
        public Node left;
        public Node right;
        public Node(int key)
        {
            this.key = key;
            this.count = 1;
            this.left = null;
            this.right = null;
        }

    }
}
