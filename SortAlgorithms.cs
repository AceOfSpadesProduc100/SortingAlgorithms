using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWPF
{
    public class SortAlgorithms
    {

        public static void BubbleSort<T>(T[] values, IComparer<T> cmp)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length - i - 1; j++)
                {
                    if (cmp.Compare(values[j], values[j + 1]) > 0)
                    {
                        (values[j], values[j + 1]) = (values[j + 1], values[j]);
                    }
                }
            }
        }
    }
}
