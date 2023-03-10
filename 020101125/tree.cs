using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace _020101125
{
    public class TreeNode<T> where T : new()
    {
        T values;
        public TreeNode<T> Left=null;
        public TreeNode<T> Right=null;
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
        public delegate T Scan(string s);
        public virtual void ReadTreeFromFile(string path,Comparison<T> comparison,Scan scan)
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string s;
                for (int i = 0; (s = rd.ReadLine()) != null; i++)
                {
                        T value = scan(s);
                        addNode(root, value, comparison);
                }
            }
        }

        public List<T> LNR()
        {
            Stack<TreeNode<T>> st = new Stack<TreeNode<T>>();
            st.Push(root);
            TreeNode<T> cur = root;
            List<T> list = new List<T>();
            while(st.Count > 0)
            {
                cur= st.Pop();
                //list.Add(cur.Value);
                if (cur.Left != null)
                {
                    st.Push(cur);
                    st.Push(cur.Left);
                   // continue;
                }
                st.Pop();
                list.Add(cur.Value);
                if (cur.Right != null)
                {
                    st.Push(cur);
                    st.Push(cur.Right);
                    //continue;
                }

                
            }
            
            return list;
        }
    }
    public class treeTHISINH : tree<THISINH>
    {
        public treeTHISINH() { }
        public  void ReadTreeFromFile(string path) //ch xong
        {
            using (StreamReader rd = new StreamReader(path))
            {
                
            }
        }
    }
}
