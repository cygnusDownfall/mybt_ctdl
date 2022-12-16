using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace danhsachlienket
{
    public class LinkedList
    {
        Node first;
        public LinkedList(Node first)
        {
            this.first = first;
        }
        public LinkedList()
        {
            this.first = null;
        }
        public void Readfromfile(string filepath)
        {

            using (StreamReader rd = new StreamReader(filepath))
            {
                string s;
                //Node last = new Node(Convert.ToInt32(rd.ReadLine()));
                //first = last;
                first = new Node(Convert.ToInt32(rd.ReadLine()));
                for (; (s = rd.ReadLine()) != null;)
                {
                    //last.next = new Node(Convert.ToInt32(s));
                    //last = last.next;
                    Insert(Convert.ToInt32(s));
                }


            }

        }
        public void writefile(string filepath)
        {
            Node currentnode = first;
            using (StreamWriter wt = new StreamWriter(filepath))
            {
                for (; currentnode != null;)
                {
                    wt.WriteLine(currentnode.value);
                    currentnode = currentnode.next;
                }

            }
        }
        public void duyetdanhsach()
        {
            if (first == null)
            {
                Console.WriteLine("Danh sach rong!!!!");

            }
            else
            {

                Node cur = first;
                while (cur != null)
                {
                    Console.Write(cur.value);
                    if (cur.next != null)
                    {
                        Console.Write(" -> ");
                    }
                    cur = cur.next;
                }
            }
        }
        public Node search(int val)
        {
            Node cur = first;
            while (cur != null)
            {
                if (cur.value == val)
                {
                    return cur;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return null;
        }
        public void Them(int val, int vt)
        {
            if (first == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            Node cur = first;
            for (int i = 0; i < vt - 1; i++)
            {
                if (cur.next == null)
                {
                    return;
                }
                cur = cur.next;
            }
            Node tmp = new Node(val);
            tmp.next = cur.next;
            cur.next = tmp;
        }
        public void ThemVaoDau(int val)
        {
            Node cur = first;
            Node tmp = new Node(val);
            tmp.next = cur;
            first = tmp;
        }
        public void ThemVaoCuoi(int val)
        {
            if (first == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            Node cur = first;
            for (int i = 0; cur.next != null; i++)
            {
                cur = cur.next;
            }

            Node tmp = new Node(val);

            cur.next = tmp;
        }
        public void DaoNguoc()
        {
            Node cur = first;
            Node last = new Node(cur.value);
            Node tmp;
            while (cur != null)
            {
                if(cur.next == null) { break; }
                tmp = new Node(cur.next.value);
                tmp.next = last;
                last = tmp;
                cur = cur.next;
                
            }
            first = last;
        }
        public void Insert(int val) //dung cho insertion sort
        {
            if (first == null)
            {
                first = new Node(val);
                return;
            }

            if (val < first.value)
            {
                ThemVaoDau(val);
            }
            if(first.next == null)
            {
                ThemVaoCuoi(val);
            }

            Node cur = first;
            while (val > cur.next.value && cur.next != null)
            {
                cur = cur.next;
            }

            Node tmp = new Node(val);
            tmp.next = cur.next;
            cur.next = tmp;
        }
        double trungbinhcong()
        {
            int count = 0;
            int sum=0;
            Node cur = first;
            while (cur != null)
            {
                count++;
                if (cur.next == null) { break; }
                sum += cur.value;
                cur= cur.next;

            }
            return sum/count;
        }

        void insertionsort()
        {
            Node cur = first;
            LinkedList newLinkedList = null;
            while (cur != null)
            {
                newLinkedList.Insert(cur.value);
                cur= cur.next;
            }
            first = newLinkedList.first;
        }
        void naturalmergesort()
        {
            Node cur = first;
            List<Node> RUN=new List<Node>();
            RUN.Add(cur);


            while(cur!=null)
            {
                if (cur.next == null) break;
                while(cur.value<=cur.next.value)
                {
                    cur= cur.next;
                }
                RUN.Add(cur.next);
            }

            for (int i = RUN.Count; RUN.Count > 0 ;i/=2)
            {
                for(int j = 0; j < i; j += 2)
                {
                    RUN[j]=merge(RUN[j], RUN[j+1]);
                    RUN.RemoveAt(j+1);
                }
            }
        }

        Node merge(Node cur1,Node cur2)
        {
            Node cur ;

            if (cur1.value <= cur2.value)
            {
                cur = cur1;
                cur1 = cur1.next;
                cur.next = cur2;
            }
            else
            {
                cur = cur2;
                cur2 = cur2.next;
                cur.next = cur1;
            }
            Node f = cur;


            while (cur1 != null&&cur2!=null)
            {
                if(cur1.value <= cur2.value)
                {
                    cur= cur1;
                    cur1 = cur1.next;
                    cur.next = cur2;
                }
                else
                {
                    cur = cur2;
                    cur2 = cur2.next;
                    cur.next = cur1;
                }
            }
            return f;
        }
    }
}
