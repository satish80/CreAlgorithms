using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class Tries
    {

    }

    public class TrieNode
    {
        public TrieNode[] nodes = new TrieNode[26];
        public bool isEnd = false;
        public char Current;
        public string Value;

        public TrieNode(char c)
        {
            this.Current = c;
        }

        public TrieNode Contains(char ch)
        {
            return nodes[ch];
        }

        private void Add(TrieNode node)
        {
            this.nodes[node.Current] = node;
        }

        public void Insert(string str, string value, TrieNode root)
        {
            for (int idx = 0; idx < str.Length; idx++)
            {
                var node = nodes[str[idx]];
                if (node == null)
                {
                    TrieNode child = new TrieNode(str[idx]);
                    root.Add(child);

                    if (idx == str.Length - 1)
                    {
                        child.Value = value;
                    }

                    root = child;
                }
                else
                {
                    root = node;
                }
            }

            root.isEnd = true;
        }
    }
}
