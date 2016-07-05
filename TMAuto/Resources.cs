using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class Resources
    {
        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Iron { get; set; }
        public int Crop { get; set; }

        public int FreeCrop { get; set; }

        public static Resources operator +(Resources resources1, Resources resources2)
        {
            return new Resources()
            {
                Wood = resources1.Wood + resources2.Wood,
                Clay = resources1.Clay + resources2.Clay,
                Iron = resources1.Iron + resources2.Iron,
                Crop = resources1.Crop + resources2.Crop,
                FreeCrop = resources1.FreeCrop + resources2.FreeCrop
            };
        }

        public static Resources operator -(Resources resources1, Resources resources2)
        {
            return new Resources()
            {
                Wood = resources1.Wood - resources2.Wood,
                Clay = resources1.Clay - resources2.Clay,
                Iron = resources1.Iron - resources2.Iron,
                Crop = resources1.Crop - resources2.Crop,
                FreeCrop = resources1.FreeCrop - resources2.FreeCrop
            };
        }

        public static bool operator >=(Resources resources1, Resources resources2)
        {
            return resources1.Wood >= resources2.Wood &&
                resources1.Clay >= resources2.Clay &&
                resources1.Iron >= resources1.Iron &&
                resources1.Crop >= resources2.Crop &&
                (resources2.FreeCrop == 0 || resources1.FreeCrop >= resources2.FreeCrop);
        }

        public static bool operator <=(Resources resources1, Resources resources2)
        {
            return resources1.Wood <= resources2.Wood &&
                resources1.Clay <= resources2.Clay &&
                resources1.Iron <= resources1.Iron &&
                resources1.Crop <= resources2.Crop &&
                resources1.FreeCrop <= resources2.FreeCrop;
        }

        public static bool operator ==(Resources resources1, Resources resources2)
        {
            return resources1.Wood == resources2.Wood &&
                resources1.Clay == resources2.Clay &&
                resources1.Iron == resources2.Iron &&
                resources1.Crop == resources2.Crop &&
                resources1.FreeCrop == resources2.FreeCrop;
        }

        public static bool operator !=(Resources resources1, Resources resources2)
        {
            return !(resources1 == resources2);
        }
        //not implemented
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //not implemented
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return String.Format("Wood: {0}, Clay: {1}, Iron: {2}, Crop: {3}, FreeCrop: {4}", Wood, Clay, Iron, Crop, FreeCrop);
        }
    }
}
