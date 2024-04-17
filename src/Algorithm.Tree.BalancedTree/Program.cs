using System;

namespace Algorithm.Tree.BalancedTree
{
    class Node
    {
        public int data;
        public Node left, right;
        public int height;

        public Node(int value)
        {
            data = value;
            left = right = null;
            height = 1;
        }
    }

    class BalancedTree
    {
        private Node root;

     
        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.height;
        }
        
        private int BalanceFactor(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return Height(node.left) - Height(node.right);
        }

        private Node RightRotate(Node y)
        {
            Node x = y.left;
            Node T = x.right;

       
            x.right = y;
            y.left = T;

            y.height = Math.Max(Height(y.left), Height(y.right)) + 1;
            x.height = Math.Max(Height(x.left), Height(x.right)) + 1;

            return x;
        }

     
        private Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node T = y.left;

           
            y.left = x;
            x.right = T;

          
            x.height = Math.Max(Height(x.left), Height(x.right)) + 1;
            y.height = Math.Max(Height(y.left), Height(y.right)) + 1;

            return y;
        }


        public Node Insert(Node node, int data)
        {
           
            if (node == null)
            {
                return new Node(data);
            }

            if (data < node.data)
            {
                node.left = Insert(node.left, data);
            }
            else if (data > node.data)
            {
                node.right = Insert(node.right, data);
            }
            else
            {
                return node; 
            }

           
            node.height = 1 + Math.Max(Height(node.left), Height(node.right));

            
            int balance = BalanceFactor(node);

           
            if (balance > 1 && data < node.left.data)
            {
                return RightRotate(node);
            }

          
            if (balance < -1 && data > node.right.data)
            {
                return LeftRotate(node);
            }

           
            if (balance > 1 && data > node.left.data)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }

           
            if (balance < -1 && data < node.right.data)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }

            return node;
        }
 
        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Console.Write(node.data + " ");
                InOrderTraversal(node.right);
            }
        }

        static void Main(string[] args)
        {
            BalancedTree balancedTree = new BalancedTree();

            balancedTree.root = balancedTree.Insert(balancedTree.root, 10);
            balancedTree.root = balancedTree.Insert(balancedTree.root, 20);
            balancedTree.root = balancedTree.Insert(balancedTree.root, 30);
            balancedTree.root = balancedTree.Insert(balancedTree.root, 40);
            balancedTree.root = balancedTree.Insert(balancedTree.root, 50);
            balancedTree.root = balancedTree.Insert(balancedTree.root, 25);

            Console.WriteLine("Inorder traversal:");
            balancedTree.InOrderTraversal(balancedTree.root);
        }
    }
}
