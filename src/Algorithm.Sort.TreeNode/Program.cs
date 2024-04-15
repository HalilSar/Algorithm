using System;

namespace Algorithm.Sort.TreeNode
{
    class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }


    class Program
    {
        static Node root;
        static void TreeSortAlgorithm(Node root)
        {
            if (root != null)
            {
                
                TreeSortAlgorithm(root.left);

               
                Console.Write(root.data + " ");

                
                TreeSortAlgorithm(root.right);
            }
        }

       
        static Node Insert(Node node, int key)
        {
            
            if (node == null)
            {
                return new Node(key);
            }

            
            if (key < node.data)
            {
                node.left = Insert(node.left, key);
            }
            else if (key >= node.data)
            {
                node.right = Insert(node.right, key);
            }


            return node;
        }
        static void Main(string[] args)
        {
            int[] arr = { 5, 4, 7, 2, 11, 1 };
 
            foreach (int num in arr)
            {
                root = Insert(root, num);
            }

 
            TreeSortAlgorithm(root);
        }
    }
}
