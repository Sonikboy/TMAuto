using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class PriorityQueue
    {
        private SortedList<int, int> list = new SortedList<int, int>(new PriorityComparer());
        public void Enqueue(int id, int priority)
        {
            list.Add(priority, id);
        }

        public object Peek()
        {
            var first = list.First();

            return new { Id = first.Value, Priority = first.Key };
        }

		public void Dequeue()
        {
            list.RemoveAt(0);
        }

		public bool Empty()
        {
            return list.Count == 0;
        }

        public int GetOffset(int id)
        {
            return list.Count(i => i.Value == id);
        }
    }
}
