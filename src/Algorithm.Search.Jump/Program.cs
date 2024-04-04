using System;
using static System.Console;
namespace Algorithm.Search.Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2,3,4,5,6,7,8 };
            int target = 7;
            int index = JumpSearch(arr, target);
            if(index != -1) WriteLine("Element found at index " + index);
            else WriteLine("Element not found.");
        }


        static int JumpSearch(int[] arr, int target)
        {
            int n = arr.Length;
            int step = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;
            while (arr[Math.Min(step,n) - 1]<target)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n) return -1;
            }

            while (arr[prev] < target)
            {
                prev++;
                if (prev == Math.Min(step, n)) return -1;
            }

            if (arr[prev] == target) return prev;

            return -1;
        }
    }
}
