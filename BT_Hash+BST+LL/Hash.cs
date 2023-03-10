using _020101125;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BT_Hash_BST_LL
{
    class Tree_Text : tree<TextNode>
    {
        public Tree_Text(string text, int page)
        {
            addNode(root, text, page);

        }

        public bool addNode(TreeNode<TextNode> aRoot, string key, int page)
        {
            if (aRoot == null)
            {
                aRoot = new TreeNode<TextNode>(new TextNode(key, page));
                root = aRoot;
                return true;
            }
            for (TreeNode<TextNode> cur = aRoot; cur != null;)
            {

                if (string.Compare(key, cur.Value.text) < 0)
                {
                    if (cur.Left == null)
                    {
                        TreeNode<TextNode> newnode = new TreeNode<TextNode>(new TextNode(key, page));
                        cur.Left = newnode;
                        break;
                    }
                    else
                    {
                        cur = cur.Left;
                    }
                }
                else if (string.Compare(key, cur.Value.text) > 0)
                {
                    if (cur.Right == null)
                    {
                        TreeNode<TextNode> newnode = new TreeNode<TextNode>(new TextNode(key, page));
                        cur.Right = newnode;
                        break;
                    }
                    else
                    {
                        cur = cur.Right;
                    }
                }
                else //trung text
                {
                    cur.Value.pages.Insert(page, (a, b) => a - b);
                    break;
                }
            }
            return true;
        }
    }
    class TextNode
    {
        public string text = null;
        public danhsachlienket<int> pages = new danhsachlienket<int>();
        public TextNode() { }
        public TextNode(string Text)
        {
            this.text = Text;
        }
        public TextNode(string Text, int val)
        {
            this.text = Text;
            pages.Insert(val, (a, b) => a - b);
        }
        public static int cmp(TextNode node1, TextNode node2)
        {
            return string.Compare(node1.text, node2.text);
        }

    }
    internal class Hash
    {
        Tree_Text[] HashTable = new Tree_Text[26];
        public Hash()
        {
            //for (int i = 0; i <26; i++)
            //{
            //    HashTable[i] = new Tree_Text();
            //}
        }

        public int Hashing(string key)
        {
            key = key.ToLower();
            if (key.Length == 0)
            {
                return -1;
            }

            if (key[0] < 'a' || key[0] > 'z')
            {
                return -1;
            }

            int code = key[0] - 'a';
            return code;
        }
        void addText(string text, int page)
        {
            int id = Hashing(text);
            if (id < 0) return;
            Tree_Text cur = HashTable[id];
            if (HashTable[id] == null)
            {
                HashTable[id] = new Tree_Text(text, page);
                return;
            }
            cur.addNode(cur.root, text, page);
        }
        public string[] scan(string s)
        {
            string[] words = s.Split(',', '.');
            return words;
        }
        public void ReadTreeFromFile(string path, bool haveHeader)
        {
            using (StreamReader rd = new StreamReader(path))
            {
                if (haveHeader)
                {
                    rd.ReadLine();
                }
                string s;
                for (int i = 0; (s = rd.ReadLine()) != null; i++) //i = so dong hien tai
                {
                    string[] words = scan(s);
                    addText(words[1], Convert.ToInt32(words[0]));
                }
            }
        }
        public List<int> search(string text)
        {
            int id = Hashing(text);
            if (id < 0) return null;
            var cur = HashTable[id];
            if (cur == null) return null;
            var x = cur.search(new TextNode(text), TextNode.cmp);
            if (x == null) return null;
            var pages = x.Value.pages.duyetds();
            return pages;

        }
        public void writeFile(string path)
        {
            using (StreamWriter wr = new StreamWriter(path))
                for (int hashid = 0, length = HashTable.Length; hashid < length; hashid++)
                {
                    if (HashTable[hashid] == null) continue;
                    char title = (char)(hashid + 'A');
                    wr.WriteLine(title);
                    List<TextNode> textnodes = new List<TextNode>();
                    HashTable[hashid].duyetLNR(ref textnodes);
                    for (int textid = 0, n = textnodes.Count; textid < n; textid++)
                    {
                        List<int> pages = textnodes[textid].pages.duyetds();
                        wr.Write(textnodes[textid].text);
                        for (int pageid = 0, m = pages.Count; pageid < m; pageid++)
                        {
                            wr.Write("," + pages[pageid]);
                        }
                        wr.WriteLine();
                    }
                    wr.WriteLine();
                }
        }
    }
}
