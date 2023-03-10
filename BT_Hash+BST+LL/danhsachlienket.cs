using System;
using System.Collections.Generic;
using System.IO;


namespace _020101125
{
    public class Node<T> where T : new()
    {
        public T value;
        public Node<T> next;
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        public Node()
        {
            this.next = null;
        }
        public Node(T val)
        {
            value = val;
            this.next = null;
        }
    }

    public class danhsachlienket<T> where T : new()
    {
        Node<T> first;
        public danhsachlienket(Node<T> first)
        {
            this.first = first;
        }
        public danhsachlienket()
        {
            this.first = null;
        }
        public danhsachlienket(string input, string output)
        {

            // ReadInsertfromfile(input);
            //writefile(output);
        }
        public delegate T Scan(string s);
        public void ReadInsertfromfile<T>(string path, Comparison<T> comparison, Scan scan)
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string s;
                for (int i = 0; (s = rd.ReadLine()) != null; i++)
                {
                    //T value = scan(s);
                    //addNode(root, value, comparison);
                }
            }
        }
        public void writefile(string filepath)
        {
            Node<T> currentnode = first;
            using (StreamWriter wt = new StreamWriter(filepath))
            {


            }
        }

        public void Them(T val, int vt)
        {
            if (first == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            Node<T> cur = first;
            for (int i = 0; i < vt - 1; i++)
            {
                if (cur.next == null)
                {
                    return;
                }
                cur = cur.next;
            }
            Node<T> tmp = new Node<T>(val);
            tmp.next = cur.next;
            cur.next = tmp;
        }
        public void ThemVaoDau(T val)
        {
            Node<T> cur = first;
            Node<T> tmp = new Node<T>(val);
            tmp.next = cur;
            first = tmp;
        }
        public void ThemVaoCuoi(T val)
        {
            if (first == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            Node<T> cur = first;
            for (int i = 0; cur.next != null; i++)
            {
                cur = cur.next;
            }
            Node<T> tmp = new Node<T>(val);

            cur.next = tmp;
        }
        public void DaoNguoc()
        {
            Node<T> cur = first;
            Node<T> last = new Node<T>(cur.value);
            Node<T> tmp;
            while (cur != null)
            {
                if (cur.next == null) { break; }
                tmp = new Node<T>(cur.next.value);
                tmp.next = last;
                last = tmp;
                cur = cur.next;

            }
            first = last;
        }


        public void Insert(T val, Comparison<T> comparison)
        {
            if (first == null)
            {
                first = new Node<T>(val);
                return;
            }

            if (comparison(val, first.value) < 0)
            {
                ThemVaoDau(val);
                return;
            }
            if (first.next == null)
            {
                ThemVaoCuoi(val);
                return;
            }

            Node<T> cur = first;

            while (cur.next != null && comparison(val, cur.next.value) > 0)
            {
                cur = cur.next;
            }

            Node<T> tmp = new Node<T>(val);
            tmp.next = cur.next;
            cur.next = tmp;
        }

        public List<T> duyetds()
        {
            List<T> list = new List<T>();
            Node<T> cur = first;
            while (cur != null)
            {
                list.Add(cur.value);
                cur = cur.next;
            }
            return list;
        }

        public List<T> count()
        {
            List<T> list = new List<T>();
            Node<T> cur = first;
            while (cur != null)
            {
                list.Add(cur.value);
                cur = cur.next;
            }
            return list;
        }


    }

}

