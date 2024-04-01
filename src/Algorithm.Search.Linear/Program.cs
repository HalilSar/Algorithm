using System;

namespace Algorithm.Search.Linear
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int target = 3;
            int num = LinearSearch(arr,target);
            if(num>0) Console.WriteLine($"Target: {num}");

        }
        static int LinearSearch(int[] arr,int target)
        {
            foreach (var item in arr)
            {
                if (item == target) return item;
            }

            return -1;
        }

    }
}
