using System;
using static System.Console;
namespace Algorithm.Search.Exponential
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            int target = 10;
            int index = Search(arr, target);
            if (index != -1) WriteLine("Element found at index " + index);
            else WriteLine("Element not found.");
        }

        static int Search(int[] arr , int target)
        {
            int n = arr.Length;

            if (arr[0] == target)
            {
                return 0;
            }

            int i = 1;

            while (i < n && arr[i] <= target)
                i = i * 2;

            return BinarySearch(arr,target,i/2,Math.Min(i,n-1));
        }
        static int BinarySearch(int[] arr, int target, int low, int high)
        {

            if (high >= low)
            {
   
                int mid = low + (high - low) / 2;

                if (arr[mid] == target)
                    return mid;

                if (arr[mid] > target)
                    return BinarySearch(arr, target, low, mid - 1);

                return BinarySearch(arr, target, mid+1, high);
            }
            return -1;
        }
    }
}
