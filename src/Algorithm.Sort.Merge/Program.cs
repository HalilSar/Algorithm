using static System.Console;
namespace Algorithm.Sort.Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 34,25, 12, 22, 11, 90 };
            WriteLine("Orjinal Array:");
            PrintArray(array);
            MergeSort(array,0,array.Length - 1);
            WriteLine("\n Sorte Array:");
            PrintArray(array);
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array,left,middle,right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; ++i)
            {
                L[i] = array[left + i];
            }

            for (int j= 0; j < n2; ++j)
            {
                R[j] = array[middle + 1 + j];
            }

            int k = left;
            int l = 0;
            int r = 0;

            while (l<n1 && r<n2)
            {
                if (L[l] <= R[r])
                {
                    array[k] = L[l];
                    l++;
                }

                else
                {
                    array[k] = R[r];
                    r++;
                }
                k++;
            }

            while (l<n1)
            {
                array[k] = L[l];
                l++;
                k++;
            }

            while (r < n2)
            {
                array[k] = R[r];
                r++;
                k++;
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
