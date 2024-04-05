using static System.Console;
using System;
namespace Algorithm.Search.Fibonacci
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] arr = { 10, 22, 35, 40, 45,50,80,82,85,90,100 };
            int target = 85;
            int index = Search(arr, target);
            if (index != -1) WriteLine("Element found at index " + index);
            else WriteLine("Element not found.");
        }

        static int[] GenerateFibonacci(int size)
        {
            int[] fib = new int[size];
            fib[0] = 0;
            fib[1] = 1;
            for (int i =2; i < size; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            return fib;
        }

        static int Search(int[] arr, int target)
        {
            int n = arr.Length;
            int[] fib = GenerateFibonacci(n);
            int ofset = -1;
            int i;

            while (fib[n-1] >1)
            {
                i = Math.Min(ofset + fib[n - 2], n - 1);
                if (arr[i] == target) return i;

                if(arr[i]< target)
                {
                    fib = GenerateFibonacci(n - i);
                    n = n - i;
                    ofset = i;
                }

                else
                {
                    fib = GenerateFibonacci(i);
                    n = i;
                }


            }

            return -1;
        }
    
    }
}
