using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoComplete1.Models
{
    public class Search
    {
        static private Node prefixTree;

        // prefixTree node class
        public class Node
        {
            public string Prefix { get; set; }
            public Dictionary<char, Node> ChildNode { get; private set; }
            
            public bool CheckLastCharWord;

            public Node(String prefix)
            {
                this.Prefix = prefix;
                this.ChildNode = new Dictionary<char, Node>();
            }
        }

        public Search(String[] dict)
        {
            prefixTree = new Node(string.Empty);
            for (int i = 0; i < dict.Length; i++)
            {
                AddWord(dict[i]);
            }
        }

        // Insert a word into the prefixTree
        private void AddWord(String s)
        {
            // Iterate through each character in the string. If the character is not
            // already in the prefixTree then add it
            Node current = prefixTree;
            for (int i = 0; i < s.Length; i++)
            {
                if (!current.ChildNode.ContainsKey(s[i]))
                {
                    current.ChildNode.Add(s[i], new Node(s.Substring(0, i + 1)));
                }
                current = current.ChildNode[s[i]];

                if (i == s.Length - 1)
                    current.CheckLastCharWord = true;
            }
        }

        // Find all words in prefixTree that start with prefix
        public static List<String> GetWordsForPrefix(String pre)
        {
            List<String> results = new List<String>();

            // Iterate to the end of the prefix
            Node current = prefixTree;

            var preArray = pre.ToCharArray();

            for (int i = 0; i < preArray.Length; i++)
            {
                if (current.ChildNode.ContainsKey(preArray[i]))
                {
                    current = current.ChildNode[preArray[i]];
                }
                else
                {
                    return results;
                }
            }


            // At the end of the prefix, find all child words
            FindAllChildWords(current, results);
            return results;
        }

        // Recursively find every child word
        private static void FindAllChildWords(Node n, List<String> results)
        {
            if (n.CheckLastCharWord)
                results.Add(n.Prefix);

            foreach (var c in n.ChildNode.Keys)
            {
                FindAllChildWords(n.ChildNode[c], results);
            }

        }

    }
}