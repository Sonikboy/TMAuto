using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class Building
    {
        public string Name { get { return Buildings.GetName(Type); } }
        public int Type { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get { return Buildings.getMaxLevel(Type); } }

        //cost of next level
        public Resources NextLevelCost { get { return Buildings.getNextLevelCost(Type, Level); } }
        public string NextLevelBuildingTime { get { return Buildings.NextLevelBuildingTime(Type, Level); } }

        public Image BuildingImage { get { return Buildings.GetImage(Type); } }
        public override string ToString()
        {
            return String.Format("Type: {0}, Level: {1}, MaxLevel: {2}, Cost: {3}, BuildingTime: {4}", Type, Level, MaxLevel, NextLevelCost, NextLevelBuildingTime);
        }
    }
}
