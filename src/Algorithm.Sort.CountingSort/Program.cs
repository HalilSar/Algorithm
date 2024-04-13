using System;

namespace Algorithm.Sort.CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 2, 8, 3, 3, 1 };
            int n = arr.Length;

            // Sayım sıralama
            CountingSortAlgorithm(arr, n);

            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        static void CountingSortAlgorithm(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            int[] count = new int[max + 1];

            for (int i = 0; i < n; i++)
            {
                count[arr[i]]++;
            }

           
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }

           
            int[] output = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                count[arr[i]]--;
            }

           
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }
    }
}
