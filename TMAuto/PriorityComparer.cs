using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class PriorityComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            dynamic x2 = x;
            dynamic y2 = y;
            int diff = x.CompareTo(y);

            return diff < 0 ? 1 : -1;
        }
    }
}
