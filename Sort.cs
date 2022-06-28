using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWPF
{
    public class Comparer : IComparer<ArrayInt>
    {
        

        public int Compare(ArrayInt x, ArrayInt y)
        {
            Sort.comparisons++;
            return x < y ? -1 : x > y ? 1 : 0;
        }
    }
    public static class Sort
    {
        //how many comparisons were needed for the sort in total
        public static long comparisons;

        //how many array accesses were needed for the sort
        public static long reads;

        public static long swaps;

        public static long writes;

        public static long reversals;

        //bool for the pause button && extra functionallity
        public static bool isPaused;

        public static void Swap<T>(T[] array, int a, int b, bool auxwr)
        {

            (array[b], array[a]) = (array[a], array[b]);
            swaps++;

        }

        public static void Write<T>(T[] array, int at, T equals, bool auxwr)
        {
            array[at] = equals;
        }

        public static void Reversal<T>(T[] array, int start, int length, bool aux)
        {
            reversals++;

            for (int i = start; i < start + ((length - start + 1) / 2); i++)
            {
                Swap(array, i, start + length - i, aux);
            }
        }

        public static void ChangeReversals(int value)
        {
            reversals += value;
        }
    }
}
