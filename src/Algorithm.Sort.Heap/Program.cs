using System;

namespace Algorithm.Sort.Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 64, 25, 12, 22, 11 };
            int n = arr.Length;

            // Heap sort
            HeapSortAlgorithm(arr);

            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        static void HeapSortAlgorithm(int[] arr)
        {
            int n = arr.Length;

            // Diziyi bir maksimum heap haline getir
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Maksimum heap üzerinde sıralama işlemi
            for (int i = n - 1; i > 0; i--)
            {
                // Kök ile son elemanı değiştir
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Yeniden maksimum heap oluştur
                Heapify(arr, i, 0);
            }
        }

        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Kökü en büyük eleman olarak kabul et
            int left = 2 * i + 1; // Sol çocuk indeksi
            int right = 2 * i + 2; // Sağ çocuk indeksi

            // Sol çocuk kökten daha büyükse
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            // Sağ çocuk kökten daha büyükse
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // Kök değiştiyse
            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                // Alt ağaçları yeniden düzenle
                Heapify(arr, n, largest);
            }
        }
    }
}
