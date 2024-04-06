using System;
using static System.Console;
namespace Algorithm.Search.TernarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            int target = 10;
            int index = TernarySearch(arr,0, arr.Length -1 ,target);
            if (index != -1) WriteLine("Element found at index " + index);
            else WriteLine("Element not found.");
        }

        static int TernarySearch(int[] arr, int left, int right, int target)
        {
            if (right >= left)
            {
                int mid1 = left + (right - left) / 3;
                int mid2 = mid1 + (right - left) / 3;

                if (arr[mid2] == target)
                    return mid1;

                if (arr[mid2] == target)
                    return mid2;

                if (target < arr[mid1])
                    return TernarySearch(arr, left , mid1 - 1  , target);
                else if (target > arr[mid2])
                    return TernarySearch(arr, mid2 + 1, right, target);
                else
                    return TernarySearch(arr, mid1 + 1, mid2 - 1, target);
            }

            return -1;
        }
    }
}
