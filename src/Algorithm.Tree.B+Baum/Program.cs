using System;
using System.Collections.Generic;
namespace Algorithm.Tree.BPlusBaum
{
    class BPlusTree
    {
        private class Node
        {
            public List<int> keys;
            public List<Node> children;
            public Node parent;
            public bool isLeaf;

            public Node(bool leaf)
            {
                keys = new List<int>();
                children = new List<Node>();
                parent = null;
                isLeaf = leaf;
            }
        }

        private Node root;
        private int order; // Düğümün maksimum anahtar sayısı (order-1)

        public BPlusTree(int order)
        {
            root = new Node(true);
            this.order = order;
        }

        // Anahtar ekleme
        public void Insert(int key)
        {
            Node leaf = FindLeaf(key);
            InsertIntoLeaf(leaf, key);

            if (leaf.keys.Count == order)
            {
                SplitLeaf(leaf);
            }
        }

        // Anahtarın bulunması
        private Node FindLeaf(int key)
        {
            Node current = root;
            while (!current.isLeaf)
            {
                int i = 0;
                while (i < current.keys.Count && key >= current.keys[i])
                {
                    i++;
                }
                current = current.children[i];
            }
            return current;
        }

        // Anahtarın yaprağa eklenmesi
        private void InsertIntoLeaf(Node leaf, int key)
        {
            int i = 0;
            while (i < leaf.keys.Count && key > leaf.keys[i])
            {
                i++;
            }
            leaf.keys.Insert(i, key);
        }

        // Yaprağın bölünmesi
        private void SplitLeaf(Node leaf)
        {
            Node newLeaf = new Node(true);
            int mid = (order - 1) / 2;
            newLeaf.keys.AddRange(leaf.keys.GetRange(mid, order - mid));
            leaf.keys.RemoveRange(mid, order - mid);
            if (leaf.parent == null)
            {
                Node parent = new Node(false);
                parent.keys.Add(newLeaf.keys[0]);
                parent.children.Add(leaf);
                parent.children.Add(newLeaf);
                leaf.parent = parent;
                newLeaf.parent = parent;
                root = parent;
            }
            else
            {
                Node parent = leaf.parent;
                int index = parent.children.IndexOf(leaf);
                parent.keys.Insert(index, newLeaf.keys[0]);
                parent.children.Insert(index + 1, newLeaf);
                newLeaf.parent = parent;
            }
        }

        // Inorder traversal (Sıralı gezinti)
        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                if (!node.isLeaf)
                {
                    for (int i = 0; i < node.children.Count; i++)
                    {
                        InOrderTraversal(node.children[i]);
                        if (i < node.keys.Count)
                        {
                            Console.Write(node.keys[i] + " ");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < node.keys.Count; i++)
                    {
                        Console.Write(node.keys[i] + " ");
                    }
                }
            }
        }

        // Ana fonksiyon
        static void Main(string[] args)
        {
            BPlusTree bPlusTree = new BPlusTree(4);

            bPlusTree.Insert(1);
            bPlusTree.Insert(3);
            bPlusTree.Insert(7);
            bPlusTree.Insert(10);
            bPlusTree.Insert(11);
            bPlusTree.Insert(13);
            bPlusTree.Insert(14);
            bPlusTree.Insert(15);
            bPlusTree.Insert(18);
            bPlusTree.Insert(16);
            bPlusTree.Insert(19);
            bPlusTree.Insert(24);
            bPlusTree.Insert(25);
            bPlusTree.Insert(26);
            bPlusTree.Insert(21);
            bPlusTree.Insert(4);
            bPlusTree.Insert(5);
            bPlusTree.Insert(20);
            bPlusTree.Insert(22);
            bPlusTree.Insert(2);
            bPlusTree.Insert(17);
            bPlusTree.Insert(12);
            bPlusTree.Insert(6);

            Console.WriteLine("Inorder traversal:");
            bPlusTree.InOrderTraversal(bPlusTree.root);
        }
    }
}
