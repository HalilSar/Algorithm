using System;

namespace Algorithm.Tree.DoubleEndedTree
{
    class DoubleEndedTreeNode
    {
        public int key;
        public DoubleEndedTreeNode left, right;

        public DoubleEndedTreeNode(int key)
        {
            this.key = key;
            left = right = null;
        }
    }

    class DoubleEndedTree
    {
        private DoubleEndedTreeNode root;

        public DoubleEndedTree()
        {
            root = null;
        }


        public void Insert(int key)
        {
            if (root == null)
            {
                root = new DoubleEndedTreeNode(key);
            }
            else
            {
                InsertRecursive(root, key);
            }
        }


        private void InsertRecursive(DoubleEndedTreeNode node, int key)
        {
            if (node.left == null)
            {
                node.left = new DoubleEndedTreeNode(key);
            }
            else if (node.right == null)
            {
                node.right = new DoubleEndedTreeNode(key);
            }
            else
            {
            
                InsertRecursive(node.right, key);
            }
        }


        public void Traverse()
        {
            if (root != null)
            {
                TraverseRecursive(root);
            }
        }

       
        private void TraverseRecursive(DoubleEndedTreeNode node)
        {
            Console.Write(node.key + " ");
            if (node.left != null)
            {
                TraverseRecursive(node.left);
            }
            if (node.right != null)
            {
                TraverseRecursive(node.right);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoubleEndedTree tree = new DoubleEndedTree();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(18);

            Console.WriteLine("Traversing the double-ended tree:");
            tree.Traverse();
        }
    }
}
