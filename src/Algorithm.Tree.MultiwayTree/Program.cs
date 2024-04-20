using System;
using System.Collections.Generic;
namespace Algorithm.Tree.MultiwayTree
{
    class MultiwayTreeNode
    {
        public int key;
        public List<MultiwayTreeNode> children;

        public MultiwayTreeNode(int key)
        {
            this.key = key;
            children = new List<MultiwayTreeNode>();
        }
    }

    class MultiwayTree
    {
        private MultiwayTreeNode root;

        public MultiwayTree()
        {
            root = null;
        }

       
        public void Insert(int key)
        {
            if (root == null)
            {
                root = new MultiwayTreeNode(key);
            }
            else
            {
                InsertRecursive(root, key);
            }
        }

       
        private void InsertRecursive(MultiwayTreeNode node, int key)
        {
            if (node.children.Count == 0)
            {
                node.children.Add(new MultiwayTreeNode(key));
            }
            else
            {
                foreach (var child in node.children)
                {
                    if (key < child.key)
                    {
                        InsertRecursive(child, key);
                        return;
                    }
                }
                node.children.Add(new MultiwayTreeNode(key));
            }
        }


        public void Traverse()
        {
            if (root != null)
            {
                TraverseRecursive(root);
            }
        }
 
        private void TraverseRecursive(MultiwayTreeNode node)
        {
            Console.Write(node.key + " ");
            foreach (var child in node.children)
            {
                TraverseRecursive(child);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MultiwayTree tree = new MultiwayTree();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(18);

            Console.WriteLine("Traversing the multiway tree:");
            tree.Traverse();
        }
    }
}

