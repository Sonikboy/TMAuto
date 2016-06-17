using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class OngoingQueueBuilding
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Time { get; set; }
        public string Level { get; set; }
        public string Name { get { return Buildings.GetName(Type); } } 
        public System.Threading.Timer Timer { get { return null; } }
    }
}
