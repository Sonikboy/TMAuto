using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    public enum BuildingType { Resource, Building }
    static class Buildings
    {
        private static string buildingsFolderPath = @"buildings";

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

        private static Resources[][] cost = new Resources[41][];
        private static TimeSpan[][] buildingTime = new TimeSpan[41][];

        public static TimeSpan NextLevelBuildingTime(int type, int currentLevel)
        {
            return buildingTime[type - 1][currentLevel];
        }
        public static Resources getNextLevelCost(int type, int nextLevel)
        {
            return cost[type - 1][nextLevel - 1];
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

        public static void Init()
        {
            for (int i = 0; i < 41; i++)
            {
                if (i == 11 || i == 39)
                {
                    //type 40 Wonder..
                    //type 12, blacksmith from T3.6
                    continue;
                }

                var lines = File.ReadAllLines(buildingsFolderPath + @"/" + (i + 1) + ".csv");
                var count = lines.Count();
                cost[i] = new Resources[count];
                buildingTime[i] = new TimeSpan[count];

                for (int j = 0; j < count; j++)
                {
                    var line = lines[j];
                    var values = line.Split(',');
                    var res = values.Reverse().Skip(1).Select(v => { return int.Parse(v); }).Reverse().ToArray();
                    cost[i][j] = new Resources() { Wood = res[0], Clay = res[1], Iron = res[2], Crop = res[3], FreeCrop = res[4] };

                    var time = values[5].Split(':').Select(v => { return int.Parse(v); }).ToArray();
                    var days = time[0] / 24;
                    var hours = time[0] % 24;
                    buildingTime[i][j] = new TimeSpan(days, hours, time[1], time[2]);
                }
            }
        }
    }
}
