using static System.Console;
namespace Algorithm.Sort.Bubble
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 34, 23, 12, 22, 11, 90 };
            WriteLine("Orjinal Array:");
            PrintArray(array);
            BubbleSort(array);
            WriteLine("\n Sorte Array:");
            PrintArray(array);
        }

        private static void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n-i-1; j++)
                {
                    if (array[j]> array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
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
