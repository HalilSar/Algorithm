using System;

namespace Algorithm.Tree.Fibonnacci
{
    class Program
    {
        class FibonacciNode
        {
            public int data;
            public FibonacciNode parent, child, left, right;
            public int degree;
            public bool marked;

            public FibonacciNode(int value)
            {
                data = value;
                parent = child = left = right = null;
                degree = 0;
                marked = false;
            }
        }

        class FibonacciHeap
        {
            private FibonacciNode minNode;
            private int count;

          
            public FibonacciHeap()
            {
                minNode = null;
                count = 0;
            }

          
            public void Insert(int value)
            {
                FibonacciNode newNode = new FibonacciNode(value);
                if (minNode == null)
                {
                    minNode = newNode;
                }
                else
                {
                    newNode.right = minNode;
                    newNode.left = minNode.left;
                    minNode.left = newNode;
                    newNode.left.right = newNode;

                    if (newNode.data < minNode.data)
                    {
                        minNode = newNode;
                    }
                }
                count++;
            }

            
            private void Merge(FibonacciNode heap2)
            {
                if (minNode == null)
                {
                    minNode = heap2;
                }
                else if (heap2 != null)
                {
                    FibonacciNode temp1 = minNode.right;
                    FibonacciNode temp2 = heap2.left;

                    minNode.right = heap2;
                    heap2.left = minNode;
                    temp1.left = temp2;
                    temp2.right = temp1;

                    if (heap2.data < minNode.data)
                    {
                        minNode = heap2;
                    }
                }
            }

        
            public void Union(FibonacciHeap heap2)
            {
                Merge(heap2.minNode);
                count += heap2.count;
            }

         
            static void Main(string[] args)
            {
                FibonacciHeap fibHeap = new FibonacciHeap();

                fibHeap.Insert(5);
                fibHeap.Insert(8);
                fibHeap.Insert(3);

                FibonacciHeap fibHeap2 = new FibonacciHeap();
                fibHeap2.Insert(10);
                fibHeap2.Insert(15);

                fibHeap.Union(fibHeap2);
            }
        }

    }
}
