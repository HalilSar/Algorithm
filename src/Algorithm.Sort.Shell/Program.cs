using System;

namespace Algorithm.Sort.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 64, 25, 12, 22, 11 };
            int n = arr.Length;

            // Kabuk sıralama
            ShellSortAlgorithm(arr);

            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        static void ShellSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            int gap = n / 2; // Başlangıçta aralık değeri dizinin yarısı olarak belirlenir.

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;

                    // Insertion Sort benzeri bir adım
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
                gap /= 2; // Aralık değeri azaltılır
            }
        }
    }
}
