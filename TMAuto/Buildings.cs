using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    static class Buildings
    {
        private static string[] names = new string[41] {
            "Woodcutter", "Clay Pit", "Iron Mine", "Cropland", "Sawmill",
            "Brickyard", "Iron Foundry", "Grain Mill", "Bakery", "Warehouse",
            "Granary", "", "Smithy", "Tournament Square", "Main Building",
            "Rally Point", "Marketplace", "Embassy", "Barracks", "Stable",
            "Workshop", "Academy", "Cranny", "Town Hall", "Residence", "Palace",
            "Treasury", "Trade Office", "Great Barracks", "Great Stable",
            "City Wall", "Earth Wall", "Palisade", "Stonemason's Lodge",
            "Brewery", "Trapper", "Hero's Mansion", "Great Warehouse",
            "Great Granary", "Wonder of the World", "Horse Drinking Trough"
        };
        public static string NextLevelBuildingTime(int type, int currentLevel)
        {
            return null;
        }
        public static Resources getNextLevelCost(int type, int currentLevel)
        {
            return new Resources();
        }
        public static int getMaxLevel(int type)
        {
            return 0;
        }

        public static Image GetImage(int type)
        {
            return Image.FromFile(@"images\buildings\" + type + ".png").GetThumbnailImage(50, 50, null, IntPtr.Zero);
        }
      
        public static string GetName(int type)
        {
            return names[type - 1];
        }

        public static int GetBuildingType(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    return i + 1;
                }
            }

            return 0;
        }
    }
}
