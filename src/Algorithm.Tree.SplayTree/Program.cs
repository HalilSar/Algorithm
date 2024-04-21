using System;

namespace Algorithm.Tree.SplayTree
{
    class SplayTreeNode
    {
        public int key;
        public SplayTreeNode left, right;

        public SplayTreeNode(int key)
        {
            this.key = key;
            left = right = null;
        }
    }

    class SplayTree
    {
        private SplayTreeNode root;

        public SplayTree()
        {
            root = null;
        }


        public void Insert(int key)
        {
            root = InsertRecursive(root, key);
        }
 
        private SplayTreeNode InsertRecursive(SplayTreeNode node, int key)
        {
            if (node == null)
            {
                return new SplayTreeNode(key);
            }

            if (key < node.key)
            {
                node.left = InsertRecursive(node.left, key);
            }
            else if (key > node.key)
            {
                node.right = InsertRecursive(node.right, key);
            }

            return node;
        }

 
        public void Search(int key)
        {
            root = SearchRecursive(root, key);
        }


        private SplayTreeNode SearchRecursive(SplayTreeNode node, int key)
        {
            if (node == null || node.key == key)
            {
                return node;
            }

            if (key < node.key)
            {
                if (node.left == null)
                {
                    return node;
                }
                if (key < node.left.key)
                {
                    node.left.left = SearchRecursive(node.left.left, key);
                    node = RightRotate(node);
                }
                else if (key > node.left.key)
                {
                    node.left.right = SearchRecursive(node.left.right, key);
                    if (node.left.right != null)
                    {
                        node.left = LeftRotate(node.left);
                    }
                }
                if (node.left != null)
                {
                    node = RightRotate(node);
                }
                return node.left != null ? RightRotate(node) : node;
            }
            else
            {
                if (node.right == null)
                {
                    return node;
                }
                if (key < node.right.key)
                {
                    node.right.left = SearchRecursive(node.right.left, key);
                    if (node.right.left != null)
                    {
                        node.right = RightRotate(node.right);
                    }
                }
                else if (key > node.right.key)
                {
                    node.right.right = SearchRecursive(node.right.right, key);
                    node = LeftRotate(node);
                }
                if (node.right != null)
                {
                    node = LeftRotate(node);
                }
                return node.right != null ? LeftRotate(node) : node;
            }
        }


        private SplayTreeNode RightRotate(SplayTreeNode x)
        {
            SplayTreeNode y = x.left;
            x.left = y.right;
            y.right = x;
            return y;
        }

      
        private SplayTreeNode LeftRotate(SplayTreeNode x)
        {
            SplayTreeNode y = x.right;
            x.right = y.left;
            y.left = x;
            return y;
        }

    
        private void InOrderTraversal(SplayTreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Console.Write(node.key + " ");
                InOrderTraversal(node.right);
            }
        }

        static void Main(string[] args)
        {
            SplayTree splayTree = new SplayTree();

            splayTree.Insert(10);
            splayTree.Insert(5);
            splayTree.Insert(15);
            splayTree.Insert(3);
            splayTree.Insert(7);
            splayTree.Insert(12);
            splayTree.Insert(18);

            Console.WriteLine("Inorder traversal before searching:");
            splayTree.InOrderTraversal(splayTree.root);
            Console.WriteLine();


            splayTree.Search(12);

            Console.WriteLine("Inorder traversal after searching for key 12:");
            splayTree.InOrderTraversal(splayTree.root);
        }
    }
}
