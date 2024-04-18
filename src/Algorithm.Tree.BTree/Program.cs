using System;
using System.Collections.Generic;
namespace Algorithm.Tree.BTree
{

    class BTreeNode
    {
        public List<int> keys;
        public List<BTreeNode> children;
        public bool isLeaf;

        public BTreeNode(bool leaf)
        {
            keys = new List<int>();
            children = new List<BTreeNode>();
            isLeaf = leaf;
        }
    }

    class BTree
    {
        private BTreeNode root;
        private int t; 

        public BTree(int degree)
        {
            root = null;
            t = degree;
        }

        
        public void Insert(int key)
        {
            if (root == null)
            {
                root = new BTreeNode(true);
                root.keys.Add(key);
            }
            else
            {
                if (root.keys.Count == (2 * t) - 1)
                {
                    BTreeNode newRoot = new BTreeNode(false);
                    newRoot.children.Add(root);
                    SplitChild(newRoot, 0);
                    int i = 0;
                    if (newRoot.keys[0] < key)
                    {
                        i++;
                    }
                    InsertNonFull(newRoot.children[i], key);
                    root = newRoot;
                }
                else
                {
                    InsertNonFull(root, key);
                }
            }
        }

       
        private void SplitChild(BTreeNode parent, int index)
        {
            BTreeNode newChild = parent.children[index];
            BTreeNode newSibling = new BTreeNode(newChild.isLeaf);
            parent.children.Insert(index + 1, newSibling);
            parent.keys.Insert(index, newChild.keys[t - 1]);

            newSibling.keys.AddRange(newChild.keys.GetRange(t, t - 1));
            newChild.keys.RemoveRange(t - 1, t);

            if (!newChild.isLeaf)
            {
                newSibling.children.AddRange(newChild.children.GetRange(t, t));
                newChild.children.RemoveRange(t, t);
            }
        }

        
        private void InsertNonFull(BTreeNode node, int key)
        {
            int i = node.keys.Count - 1;

            if (node.isLeaf)
            {
                node.keys.Add(0);
                while (i >= 0 && key < node.keys[i])
                {
                    node.keys[i + 1] = node.keys[i];
                    i--;
                }
                node.keys[i + 1] = key;
            }
            else
            {
                while (i >= 0 && key < node.keys[i])
                {
                    i--;
                }
                i++;
                if (node.children[i].keys.Count == (2 * t) - 1)
                {
                    SplitChild(node, i);
                    if (key > node.keys[i])
                    {
                        i++;
                    }
                }
                InsertNonFull(node.children[i], key);
            }
        }

       
        private void InOrderTraversal(BTreeNode node)
        {
            if (node != null)
            {
                int i;
                for (i = 0; i < node.keys.Count; i++)
                {
                    if (!node.isLeaf)
                    {
                        InOrderTraversal(node.children[i]);
                    }
                    Console.Write(node.keys[i] + " ");
                }

                if (!node.isLeaf)
                {
                    InOrderTraversal(node.children[i]);
                }
            }
        }

        // Ana fonksiyon
        static void Main(string[] args)
        {
            BTree bTree = new BTree(3);

            bTree.Insert(1);
            bTree.Insert(3);
            bTree.Insert(7);
            bTree.Insert(10);
            bTree.Insert(11);
            bTree.Insert(13);
            bTree.Insert(14);
            bTree.Insert(15);
            bTree.Insert(18);
            bTree.Insert(16);
            bTree.Insert(19);
            bTree.Insert(24);
            bTree.Insert(25);
            bTree.Insert(26);
            bTree.Insert(21);
            bTree.Insert(4);
            bTree.Insert(5);
            bTree.Insert(20);
            bTree.Insert(22);
            bTree.Insert(2);
            bTree.Insert(17);
            bTree.Insert(12);
            bTree.Insert(6);

            Console.WriteLine("Inorder traversal:");
            bTree.InOrderTraversal(bTree.root);
        }
    }
}
