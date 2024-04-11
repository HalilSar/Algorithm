using static System.Console;
namespace Algorithm.Sort.Insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 34, 23, 12, 22, 11, 90 };
            WriteLine("Orjinal Array:");
            PrintArray(array);
            InsertionSort(array);
            WriteLine("\n Sorte Array:");
            PrintArray(array);
        }

        private static void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n ; ++i)
            {
                int key = array[i];
                int j = i - 1;
                while (j>= 0  && array[j]> key)
                {
                                           
                    array[j + 1] = array[j];
                    j = j - 1;

                }
                array[j + 1] = key;
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
