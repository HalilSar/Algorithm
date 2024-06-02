using System;
using System.Collections.Generic;
namespace Algorithm.Sort.Bucket
{
    class Program
    {
        public static void Sort(float[] arr)
        {
            int n = arr.Length;
            if (n <= 0) return;

            // Create empty buckets
            List<float>[] buckets = new List<float>[n];
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<float>();
            }

            // Add elements into the buckets
            for (int i = 0; i < n; i++)
            {
                int bucketIndex = (int)(n * arr[i]);
                buckets[bucketIndex].Add(arr[i]);
            }

            // Sort the elements of each bucket
            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort();
            }

            // Concatenate all buckets into arr[]
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                foreach (float value in buckets[i])
                {
                    arr[index++] = value;
                }
            }
        }

        public static void Main(string[] args)
        {
            float[] arr = { (float)0.897, (float)0.565, (float)0.656, (float)0.1234, (float)0.665, (float)0.3434 };

            Console.WriteLine("Unsorted array:");
            foreach (float num in arr)
            {
                Console.Write(num + " ");
            }

            Sort(arr);

            Console.WriteLine("\nSorted array:");
            foreach (float num in arr)
            {
                Console.Write(num + " ");
            }
        }
    }
}
