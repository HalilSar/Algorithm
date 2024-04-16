using System;

namespace Algorithm.Tree.BinarySearchTree
{
    class Node
    {
        public int data;
        public Node left, right;

        public Node(int value)
        {
            data = value;
            left = right = null;
        }
    }

    class BinarySearchTree
    {
        Node root;

       
        Node Insert(Node node, int data)
        {
            
            if (node == null)
            {
                node = new Node(data);
                return node;
            }

            
            if (data < node.data)
            {
                node.left = Insert(node.left, data);
            }
            else if (data > node.data)
            {
                node.right = Insert(node.right, data);
            }

            return node;
        }

      
        void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Console.Write(node.data + " ");
                InOrderTraversal(node.right);
            }
        }

       
        bool Search(Node node, int key)
        {
            if (node == null)
            {
                return false;
            }

            if (node.data == key)
            {
                return true;
            }

            if (key < node.data)
            {
                return Search(node.left, key);
            }

            return Search(node.right, key);
        }

       
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.root = bst.Insert(bst.root, 50);
            bst.Insert(bst.root, 30);
            bst.Insert(bst.root, 20);
            bst.Insert(bst.root, 40);
            bst.Insert(bst.root, 70);
            bst.Insert(bst.root, 60);
            bst.Insert(bst.root, 80);

            Console.WriteLine("Inorder traversal:");
            bst.InOrderTraversal(bst.root);
            Console.WriteLine();

            int searchKey = 60;
            if (bst.Search(bst.root, searchKey))
            {
                Console.WriteLine($" {searchKey} found at tree.");
            }
            else
            {
                Console.WriteLine($"{searchKey} not found at tree.");
            }
        }
    }
}
