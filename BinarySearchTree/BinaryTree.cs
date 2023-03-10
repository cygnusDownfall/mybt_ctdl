using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        public Node root;
        public BinaryTree(Node root) { this.root = root; }
        public BinaryTree()
        {
            root = null;
        }
        public bool addNode(ref Node aRoot, int key)
        {
            if (aRoot == null)
            {
                aRoot = new Node(key);
                root = aRoot;
                return true;
            }
            for (Node cur = aRoot; cur != null;)
            {

                if (key < cur.value)
                {
                    if (cur.left == null)
                    {
                        Node newnode = new Node(key);
                        cur.left = newnode;
                        break;
                    }
                    else
                    {
                        cur = cur.left;
                    }
                }
                else
                {
                    if (cur.right == null)
                    {
                        Node newnode = new Node(key);
                        cur.right = newnode;
                        break;
                    }
                    else
                    {
                        cur = cur.right;
                    }
                }
            }
            return true;
        }
        public bool createTree(int[] a)
        {
            root = null;
            for (int i = 0, n = a.Length; i < n; i++)
            {
                addNode(ref root, a[i]);
            }
            return true;
        }
        public void TravelLevel()
        {
            Queue<QueueElement> queue = new Queue<QueueElement>();
            int level = 0, oldlevel = 0;
            queue.Enqueue(new QueueElement(ref root, level));
            while (queue.Count > 0)
            {
                QueueElement queueElement = queue.Dequeue();
                if (queueElement.level > oldlevel)
                {
                    Console.WriteLine();
                    oldlevel = queueElement.level;
                }
                Console.Write(queueElement.node.value + " ");

                if (queueElement.node.left != null)
                {
                    queue.Enqueue(new QueueElement(ref queueElement.node.left, queueElement.level + 1));
                }
                if (queueElement.node.right != null)
                {
                    queue.Enqueue(new QueueElement(ref queueElement.node.right, queueElement.level + 1));
                }
            }
        }
        public void NLR(Node node)
        {
            
            if (node == null)
            {
                return;
            }
            Console.Write("{0} ", node.value);
            NLR(node.left);
            NLR(node.right);
            
        }
        public void NLRnoRes()
        {
            Stack<Node> st = new Stack<Node>();
            Node cur = root;
            st.Push(root);
            while (st.Count != 0)
            {
                cur = st.Pop();
                Console.Write("{0} ", cur.value);
                
                if (cur.right != null)
                {
                    st.Push(cur.right);
                }
                if (cur.left != null)
                {
                    st.Push(cur.left);
                }
            }
        }
        public void LNR(Node node)
        {
            if (node == null)
            {
                return;
            }
            LNR(node.left);
            Console.Write("{0} ", node.value);
            LNR(node.right);
        }
        public void LRN(Node node)
        {
            if (node == null)
            {
                return;
            }
            LRN(node.left);
            LRN(node.right);
            Console.Write("{0} ", node.value);
        }
        public void duyetNLR()
        {
            NLR(root);
        }
        public void duyetLNR()
        {
            LNR(root);
        }
        public void duyetLRN()
        {
            LRN(root);
        }
        public Node Search(Node node, int X)
        {
            if (node == null) { return null; }
            if (node.value == X) { return node; }
            if (node.value > X) { return Search(node.left, X); }
            else
            {
                return Search(node.right, X);
            }
        }
        public Node Search(int X)
        {
            return Search(root, X);
        }
        public Node searchNonRev(int X)
        {
            Node cur = root;
            while (cur != null)
            {
                if (cur.value == X)
                {
                    return cur;
                }
                else if (cur.value < X)
                {
                    cur = cur.right;

                }
                else
                {
                    cur = cur.left;
                }
            }
            return null;
        }
        public Node findMax()
        {
            if (root == null) { return null; }
            Node cur = root;
            while (cur.right != null)
            {
                cur = cur.right;
            }
            return cur;
        }
        public Node findMin()
        {
            if (root == null) { return null; }
            Node cur = root;
            while (cur.left != null)
            {
                cur = cur.left;
            }
            return cur;
        }
        public Node ganbang(int X)
        {
            Node cur = root;
            while (cur != null)
            {
                if (cur.value == X)
                {
                    return cur;
                }
                else if (cur.value < X)
                {
                    cur = cur.right;

                }
                else
                {
                    cur = cur.left;
                }
            }
            return cur;
        }
        public int demNode(Node node)
        {
            if (node == null) { return 0; }
            return 1 + demNode(node.left) + demNode(node.right);
        }
        public int demNode()
        {
            return demNode(root);
        }
        public int demNutLa(Node node)
        {
            if (node == null) { return 0; }
            if ((node.left == null) && (node.right == null)) return 1;
            return demNutLa(node.left) + demNutLa(node.right);

        }
        public int demNutLa()
        {
            return demNutLa(root);
        }
        public int demNutLe(Node node)
        {
            if (node == null) { return 0; }
            return ((node.value % 2 != 0) ? 1 : 0) + demNutLe(node.left) + demNutLe(node.right);
        }
        public int demNutLe()
        {
            return demNutLe(root);
        }
        public int demNutChan(Node node)
        {
            if (node == null) { return 0; }
            return ((node.value % 2 == 0) ? 1 : 0) + demNutChan(node.left) + demNutChan(node.right);
        }
        public int demNutChan()
        {
            return demNutChan(root);
        }
        public int demNutDuong(Node node)
        {
            if (node == null) { return 0; }
            return ((node.value >= 0) ? 1 : 0) + demNutDuong(node.left) + demNutDuong(node.right);
        }
        public int demNutDuong()
        {
            return demNutDuong(root);
        }
        public int demNutAm(Node node)
        {
            if (node == null) { return 0; }
            return ((node.value < 0) ? 1 : 0) + demNutAm(node.left) + demNutAm(node.right);
        }
        public int demNutAm()
        {
            return demNutAm(root);
        }
        public int demNutCoMotCon(Node node)
        {
            if (node == null) { return 0; }
            bool x = (node.left == null) ^ (node.right == null);


            return ((x) ? 1 : 0) + demNutCoMotCon(node.left) + demNutCoMotCon(node.right);
        }
        public int demNutCoMotCon()
        {
            return demNutCoMotCon(root);
        }
        public int demNutCoHaiCon(Node node)
        {
            if (node == null) { return 0; }
            bool x = (node.left != null) && (node.right != null);


            return ((x) ? 1 : 0) + demNutCoHaiCon(node.left) + demNutCoHaiCon(node.right);
        }
        public int demNutCoHaiCon()
        {
            return demNutCoHaiCon(root);
        }
        public int Tong(Node x)
        {
            if (x == null) { return 0; }
            return x.value + Tong(x.left) + Tong(x.right);
        }
        public int Tong()
        {
            return Tong(root);
        }
        public int TongLa(Node node)
        {
            if (node == null) { return 0; }
            bool condition = !((node.left == null) ^ (node.right == null));
            return ((condition) ? node.value : 0) + TongLa(node.left) + TongLa(node.right);
        }
        public int TongLa()
        {
            return TongLa(root);
        }
        public void DemTong(Node node, ref int count, ref int sum)
        {
            if (node == null) { return; }
            count++;
            sum += node.value;
            DemTong(node.left, ref count, ref sum);
            DemTong(node.right, ref count, ref sum);
        }
        public void DemTong()
        {
            int count = 0, sum = 0;
            DemTong(root, ref count, ref sum);
            Console.WriteLine("So nut:{0}  Tong nut:{1}", count, sum);
        }
        public int ChieuCao(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(ChieuCao(node.left), ChieuCao(node.right));

        }
        public int ChieuCao()
        {
            if (root == null) return 0;
            return ChieuCao(root);
        }
    }
    public class QueueElement
    {
        public Node node;
        public int level;
        public QueueElement(ref Node node, int level)
        {
            this.node = node;
            this.level = level;
        }
    }
}
