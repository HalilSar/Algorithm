using System;

namespace Algorithm.Sort.RadixSort
{
    class Program
    {
        static int FindMax(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

       
        static void CountSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int[] count = new int[10]; 

            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

 
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

       
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

       
        static void RadixSortAlgorithm(int[] arr, int n)
        {
           
            int max = FindMax(arr, n);

            
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(arr, n, exp);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };
            int n = arr.Length;

            RadixSortAlgorithm(arr, n);

            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }
    }
}
