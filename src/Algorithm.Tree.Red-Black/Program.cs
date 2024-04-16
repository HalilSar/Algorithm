using System;

namespace Algorithm.Tree.Red_Black
{


enum Color
    {
        RED,
        BLACK
    }

    class Node
    {
        public int data;
        public Node left, right, parent;
        public Color color;

        public Node(int value)
        {
            data = value;
            left = right = parent = null;
            color = Color.RED;
        }
    }

    class RedBlackTree
    {
        private Node root;


        private void LeftRotate(Node x)
        {
            Node y = x.right;
            x.right = y.left;

            if (y.left != null)
            {
                y.left.parent = x;
            }

            y.parent = x.parent;

            if (x.parent == null)
            {
                root = y;
            }
            else if (x == x.parent.left)
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y;
            }

            y.left = x;
            x.parent = y;
        }

        private void RightRotate(Node y)
        {
            Node x = y.left;
            y.left = x.right;

            if (x.right != null)
            {
                x.right.parent = y;
            }

            x.parent = y.parent;

            if (y.parent == null)
            {
                root = x;
            }
            else if (y == y.parent.right)
            {
                y.parent.right = x;
            }
            else
            {
                y.parent.left = x;
            }

            x.right = y;
            y.parent = x;
        }

        public void Insert(int data)
        {
            Node newNode = new Node(data);
            Node parent = null;
            Node current = root;

            while (current != null)
            {
                parent = current;

                if (newNode.data < current.data)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            newNode.parent = parent;

            if (parent == null)
            {
                root = newNode;
            }
            else if (newNode.data < parent.data)
            {
                parent.left = newNode;
            }
            else
            {
                parent.right = newNode;
            }

            FixInsert(newNode);
        }


        private void FixInsert(Node newNode)
        {
            while (newNode != root && newNode.parent.color == Color.RED)
            {
                if (newNode.parent == newNode.parent.parent.left)
                {
                    Node uncle = newNode.parent.parent.right;

                    if (uncle != null && uncle.color == Color.RED)
                    {
                        newNode.parent.color = Color.BLACK;
                        uncle.color = Color.BLACK;
                        newNode.parent.parent.color = Color.RED;
                        newNode = newNode.parent.parent;
                    }
                    else
                    {
                        if (newNode == newNode.parent.right)
                        {
                            newNode = newNode.parent;
                            LeftRotate(newNode);
                        }

                        newNode.parent.color = Color.BLACK;
                        newNode.parent.parent.color = Color.RED;
                        RightRotate(newNode.parent.parent);
                    }
                }
                else
                {
                    Node uncle = newNode.parent.parent.left;

                    if (uncle != null && uncle.color == Color.RED)
                    {
                        newNode.parent.color = Color.BLACK;
                        uncle.color = Color.BLACK;
                        newNode.parent.parent.color = Color.RED;
                        newNode = newNode.parent.parent;
                    }
                    else
                    {
                        if (newNode == newNode.parent.left)
                        {
                            newNode = newNode.parent;
                            RightRotate(newNode);
                        }

                        newNode.parent.color = Color.BLACK;
                        newNode.parent.parent.color = Color.RED;
                        LeftRotate(newNode.parent.parent);
                    }
                }
            }

            root.color = Color.BLACK;
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Console.Write(node.data + "(" + node.color + ") ");
                InOrderTraversal(node.right);
            }
        }


        static void Main(string[] args)
        {
            RedBlackTree rbTree = new RedBlackTree();
            rbTree.Insert(10);
            rbTree.Insert(20);
            rbTree.Insert(30);
            rbTree.Insert(40);
            rbTree.Insert(50);
            rbTree.Insert(60);
            rbTree.Insert(70);

            Console.WriteLine("Inorder traversal:");
            rbTree.InOrderTraversal(rbTree.root);
        }
    }
}
