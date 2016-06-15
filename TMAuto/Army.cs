using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    //Unit count for army
    class Army
    {
        //Barracks
        public int Spear { get; set; }
        public int Sword { get; set; }
        public int Axe { get; set; }
        public int Archer { get; set; }
        //Stables
        public int Light { get; set; }
        public int Spy { get; set; }
        public int Marcher { get; set; }
        public int Heavy { get; set; }
        //Workshop?
        public int Ram { get; set; }
        public int Catapult { get; set; }

        public int Knight { get; set; }

        public int Snob { get; set; }
    }
}
