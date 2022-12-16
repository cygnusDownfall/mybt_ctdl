using System;
using System.Collections.Generic;
using System.Text;

namespace danhsachlienket
{
    public class Node
    {
        public int value;
        public Node next;
        public Node()
        {
            next = null;
            value =-1;
        }
        public Node(int Val)
        {
            next = null;
            value = Val;
        }
    }
}
