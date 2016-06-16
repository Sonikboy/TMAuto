using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    public enum Mode { NONE, CLOSEST, FURTHEST, RANDOM}
    sealed class Hero
    {
        private static readonly Hero instance = new Hero();
        public static Hero Instance { get { return instance; } }

        public int Health { get; set; }
        public int HealthNormalAdventures { get; set; }
        public int HealthHardAdventures { get; set; }
        public bool CanNormal { get { return Health >= HealthNormalAdventures; } }
        public bool CanHard { get { return Health >= HealthHardAdventures; } }
        public bool InVillage { get; set; }

        public Mode AdventureMode { get; set; }

        private Hero() {
            HealthNormalAdventures = 30;
            HealthHardAdventures = 50;
            AdventureMode = Mode.NONE;
        }
    }
}
