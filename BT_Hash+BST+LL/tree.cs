using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

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
        public TreeNode<T> root;

        public tree() { }
        public bool addNode( T key, Comparison<T> cmp)
        {
           return addNode(root, key, cmp);
        }
        public void Search()
        {

        }
        public virtual bool addNode(TreeNode<T> aRoot, T key,Comparison<T> cmp)
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

       
        public TreeNode<T> search(T X,Comparison<T> cmp)
        {
            TreeNode<T> cur = root;
            while (cur != null)
            {
                if (cmp(cur.Value, X) == 0)
                {
                    return cur;
                }
                else if (cmp(cur.Value, X) < 0)
                {
                    cur = cur.Right;

                }
                else
                {
                    cur = cur.Left;
                }
            }
            return null;
        }
        public void duyetLNR(ref List<T> listval)
        {
            LNR(root, ref listval);
        }
        public void LNR(TreeNode<T> node,ref List<T> listval)
        {
            if (node == null)
            {
                return;
            }
            LNR(node.Left,ref listval);
            listval.Add(node.Value);
            LNR(node.Right,ref listval);
        }
        public List<T> LNR() //ch xong
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
   
}
