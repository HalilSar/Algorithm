using System;
using static System.Console;
namespace Algorithm.Search.BinarySearchTree
{
    class Node
    {
        public int key;
        public Node left, right;
        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }

    class BinarysearchTree
    {
        Node root;
        public BinarysearchTree() => root = null; 

        public  void Insert(int key) => root = InsertRec(root, key);

          Node InsertRec(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            if (key < root.key)
                root.left = InsertRec(root.left, key);
            else if (key > root.key)
                root.right = InsertRec(root.right, key);
            return root;
        }

        public void Inorder() => InorderRec(root);

        void InorderRec(Node root)
        {
           if(root != null)
            {
                InorderRec(root.left);
                WriteLine(root.key + " ");
                InorderRec(root.right);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinarysearchTree tree = new BinarysearchTree();

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            WriteLine("Inorder traversal of the binary search tree:");
            tree.Inorder();
        }
    }
}
