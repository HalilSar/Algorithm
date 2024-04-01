using System;
using static System.Console;
namespace Algorithm.Search.Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int target = 7;
            int result = BinarySearch(arr, target);
            if (result != -1)
            {
                WriteLine($"Target: {result}");
            }

            else WriteLine($"Target: {result}");


        }

        static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;

                if (arr[mid] < target)
                    left = mid + 1;

                else right = mid - 1;

            }
            return -1;
        }
    }
}
