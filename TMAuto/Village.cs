﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class Village
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Population { get; set; }

        public Resources Resources { get; set; }
        public int Warehouse { get; set; }
        public int Granary { get; set; }

        public int WoodProduction { get; set; }
        public int ClayProduction { get; set; }
        public int IronProduction { get; set; }
        public int CropProduction { get; set; }
        public int FreeCrop { get; set; }

        public bool Capital { get; set; }
        public int Loyalty { get; set; }

        public Building[] Buildings { get; }
        public Army ArmyTotal { get; }
        public Army ArmyAvailable { get; }

        public Dictionary<Farm, Army> Farms { get; set; }
        public PriorityQueue BuildingQueue { get; set; }

        public Village()
        {
            Buildings = new Building[40];
            ArmyTotal = new Army();
            ArmyAvailable = new Army();
            Farms = new Dictionary<Farm, Army>();
            BuildingQueue = new PriorityQueue();


            for (int i = 0; i < 40; i++)
            {
                Buildings[i] = new Building();
            }
        }

        public override string ToString()
        {
            return Name + "(" + X + "|" + Y + ")";
        }

        public void addFarm(Farm farm)
        {
            if (!Farms.ContainsKey(farm))
            {
                Farms.Add(farm, new Army());
            }
        }

        public List<Farm> GetSortedFarms()
        {
            return Farms.Select(f => f.Key).OrderBy(f => f.GetDistance(X, Y)).ToList();
        }
    }
}