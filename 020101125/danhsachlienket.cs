using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace _020101125
{
    public class Node
    {
        public THISINH value;
        public Node next;
        public Node(THISINH value, Node next)
        {
            this.value = value;
            this.next = next;
        }
        public Node()
        {
            this.next = null;
        }
        public Node(THISINH val)
        {
            value = val;
            this.next = null;
        }
    }

    public class danhsachlienket
    {
        Node first;
        public danhsachlienket(Node first)
        {
            this.first = first;
        }
        public danhsachlienket()
        {
            this.first = null;
        }
        public danhsachlienket(string input, string output)
        {
           
            ReadInsertfromfile(input);
            writefile(output);
        }
        public void ReadInsertfromfile(string filepath,bool haveheader=true)
        {
            using (StreamReader rd = new StreamReader(filepath))
            {
                string[] infos = new string[4];
                int sbd;
                float toan, van, anh;
                string s;
                for (int i = 0; (s = rd.ReadLine()) != null; i++)
                {
                    if (i == 0)
                    {
                        if (haveheader)
                            continue;
                    }
                    infos = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (infos.Length > 0)
                    {
                        sbd = Convert.ToInt32(infos[0]);
                        toan = float.Parse(infos[1]);
                        van = float.Parse(infos[2]);
                        anh = float.Parse(infos[3]);

                        THISINH sv = new THISINH(sbd, toan, van, anh);
                        Insert(sv, THISINH.sosanhtheoSBD);
                    }

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
                    THISINH sv = currentnode.value;
                    wt.WriteLine("{0},{1},{2},{3}", sv.SBD, sv.Toan, sv.Van, sv.Anh);
                    currentnode = currentnode.next;
                }

            }
        }

        public void Them(THISINH val, int vt)
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
        public void ThemVaoDau(THISINH val)
        {
            Node cur = first;
            Node tmp = new Node(val);
            tmp.next = cur;
            first = tmp;
        }
        public void ThemVaoCuoi(THISINH val)
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
                if (cur.next == null) { break; }
                tmp = new Node(cur.next.value);
                tmp.next = last;
                last = tmp;
                cur = cur.next;

            }
            first = last;
        }


        public void Insert(THISINH val,Comparison<THISINH> comparison)
        {
            if (first == null)
            {
                first = new Node(val);
                return;
            }

            if (comparison(val,first.value)<0)
            {
                ThemVaoDau(val);
            }
            if (first.next == null)
            {
                ThemVaoCuoi(val);
            }

            Node cur = first;

            while (cur.next != null&&comparison( val,  cur.next.value) >0)
            {
                cur = cur.next;
            }

            Node tmp = new Node(val);
            tmp.next = cur.next;
            cur.next = tmp;
        }



    }
   
}

