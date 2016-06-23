using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class QueuedBuilding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Text { get { return Name + " level " + Level; } }
        public string Time { get { return "00"; } }

        public int Type { get; set; }
    }
}
