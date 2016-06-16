using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    sealed class Player
    {
        private static readonly Player instance = new Player();
        public static Player Instance { get { return instance; } }

        public int AllyId { get; set; }
        public int Tribe { get; set; }
        public List<Village> Villages { get; set;}

        private Player()
        {
            Villages = new List<Village>();
        }
        public void AddVillage(Village village)
        {
            Villages.Add(village);
        }
    }
}
