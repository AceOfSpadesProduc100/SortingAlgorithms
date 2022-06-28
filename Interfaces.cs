using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoWPF
{
    public interface ISorter<T>
    {
        public void Sort(T[] array, int start, int end, int choice, IComparer<T> cmp);
    }

}
