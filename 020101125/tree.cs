using System;
using System.Collections.Generic;
using System.IO;

namespace _020101125
{
    public class TreeNode<T> where T : new()
    {
        T values;
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public T Value { get => values; }

        public TreeNode()
        {

        }
        public TreeNode(T val)
        {
            values = val;
        }
        public TreeNode(T val, TreeNode<T> L, TreeNode<T> R)
        {
            values = val;
            Left = L;
            Right = R;
        }
    }
    public class tree<T> where T : new()
    {
        protected TreeNode<T> root;

        public tree() { }
        public bool addNode(TreeNode<T> aRoot, T key,Comparison<T> cmp)
        {
            if (aRoot == null)
            {
                aRoot = new TreeNode<T>(key);
                root = aRoot;
                return true;
            }
            for (TreeNode<T> cur = aRoot; cur != null;)
            {

                if (cmp(key , cur.Value) <0)
                {
                    if (cur.Left == null)
                    {
                        TreeNode<T> newnode = new TreeNode<T>(key);
                        cur.Left = newnode;
                        break;
                    }
                    else
                    {
                        cur = cur.Left;
                    }
                }
                else
                {
                    if (cur.Right == null)
                    {
                        TreeNode<T> newnode = new TreeNode<T>(key);
                        cur.Right = newnode;
                        break;
                    }
                    else
                    {
                        cur = cur.Right;
                    }
                }
            }
            return true;
        }
        public virtual void ReadTreeFromFile(string path)
        {
            using (StreamReader rd = new StreamReader(path))
            {
               
            }
        }

        public List<T> LNR()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(root);
            TreeNode<T> val = root;
            List<T> list = new List<T>();
            while(stack.Count > 0)
            {
               
            }
            
            return list;
        }
    }
    public class treeTHISINH : tree<THISINH>
    {
        public treeTHISINH() { }
        public override void ReadTreeFromFile(string path) //ch xong
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string[] infos = new string[4];
                int sbd;
                float toan, van, anh;
                string s;
                for (int i = 0; (s = rd.ReadLine()) != null; i++)
                {
                    infos = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (infos.Length > 0)
                    {
                        sbd = Convert.ToInt32(infos[0]);
                        toan = float.Parse(infos[1]);
                        van = float.Parse(infos[2]);
                        anh = float.Parse(infos[3]);

                        THISINH sv = new THISINH(sbd, toan, van, anh);
                        addNode(root,sv,THISINH.sosanhtheoSBD);
                    }

                }
            }
        }
    }
}
