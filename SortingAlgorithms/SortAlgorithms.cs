using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SortAlgorithms
    {

        public static async Task BubbleSort(int[] values, int delay)
        {
            int temp = 0;
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length - i - 1; j++)
                {
                    await Task.Delay(delay);
                    if (values[j] > values[j + 1])
                    {
                        temp = values[j + 1]; 
                        values[j + 1] = values[j];
                        values[j] = temp;
                    }
                }
            }
        }

        public async static Task SelectionSort(int[] values, int delay)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                int min = i;
                await Task.Delay(delay);
                for (int j = i + 1; j < values.Length; j++)
                {
                    if (values[j] < values[min])
                    {
                        min = j;
                    }
                    int temp = values[min];
                    values[min] = values[i];
                    values[i] = temp;
                }

            }
        }

        public static async Task InsertionSort(int[] values, int delay)
        {
            int n = values.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = values[i];
                int j = i - 1;

                while (j >= 0 && values[j] > key)
                {
                    await Task.Delay(delay);
                    values[j + 1] = values[j];
                    j = j - 1;
                }
                values[j + 1] = key;
            }
        }

        public async static Task QuickSort(int[] values, int start, int end, int delay)
        {

            if (start < end)
            {
                int i = await Partition(values, start, end, delay);

                QuickSort(values, start, i - 1, delay);
                QuickSort(values, i + 1, end, delay);
            }
        }

        private static async Task<int> Partition(int[] values, int start, int end, int delay)
        {
            int temp;
            int p = values[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (values[j] <= p)
                {
                    await Task.Delay(delay);
                    i++;
                    temp = values[i];
                    values[i] = values[j];
                    values[j] = temp;
                }
            }

            temp = values[i + 1];
            values[i + 1] = values[end];
            values[end] = temp;
            return i + 1;
        }

        public static async Task HeapSort(int[] arr, int delay)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                await Task.Delay(delay);
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                await Task.Delay(delay);
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; 
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 

            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
    }
}
