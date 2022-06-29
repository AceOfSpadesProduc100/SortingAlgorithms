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
            Sort.icmps++;
            return x < y ? -1 : x > y ? 1 : 0;
        }
    }
    public static class Sort
    {
        //how many comparisons were needed for the sort in total
        public static ulong comparisons;

        //how many array accesses were needed for the sort
        public static ulong reads;

        public static ulong swaps;

        public static ulong writes;

        public static ulong reversals;

        public static ulong icmps;

        //bool for the pause button && extra functionallity
        public static bool isPaused;

        public static void Swap<T>(T[] array, int a, int b)
        {

            (array[b], array[a]) = (array[a], array[b]);
            swaps++;

        }

        public static void Write<T>(T[] array, int at, T equals)
        {
            array[at] = equals;
        }

        public static void Reversal<T>(T[] array, int start, int length)
        {
            reversals++;

            for (int i = start; i < start + ((length - start + 1) / 2); i++)
            {
                Swap(array, i, start + length - i);
            }
        }

        public static void ChangeReversals(uint value)
        {
            reversals += value;
        }
    }
}
