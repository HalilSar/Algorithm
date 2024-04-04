using System;
using static System.Console;

namespace Algorithm.Search.Interpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10,20,30,40,50,60,70,80,90,100};
            int target = 10;
            int index = InterPolationSearch(arr, target);
            if (index != -1) WriteLine("Element found at index " + index);
            else WriteLine("Element not found.");
        }

        static int InterPolationSearch(int[] arr , int target)
        {
            int low = 0;
            int high = arr.Length -1 ;
            while (low <= high && target >= arr[low] && target <= arr[high])
            {
                int pos = low + ((target - arr[low] * (high - low)) / (arr[high] - arr[low]));
                if (arr[pos] == target) return pos;

                if (arr[pos] < target) low = pos + 1;

                else high = pos - 1;

                WriteLine("Run.");
            }

            return -1;
        }
    }
}
