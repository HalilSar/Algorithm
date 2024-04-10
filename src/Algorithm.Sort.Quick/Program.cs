using System;
using static System.Console;

namespace Algorithm.Sort.Quick
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };
            WriteLine("Orjinal Array:");
            PrintArray(array);
            Sort(array, 0, array.Length - 1);
            WriteLine("\n Sorte Array:");
            PrintArray(array);
        }


        private static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array,left,right);
                Sort(array, left, pivotIndex - 1);
                Sort(array, pivotIndex + 1, right);
                
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }



        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

        }



        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Write(item + " ");
            }
            WriteLine();
        }
    }
}
