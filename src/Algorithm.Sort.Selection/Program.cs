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
            Sort(array);
            WriteLine("\n Sorte Array:");
            PrintArray(array);
        }


        private static void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n-1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;                   
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
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

