using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class Farm
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PlayerId { get; set; }
        public int AllyId { get; set; }


        public double GetDistance(int x, int y)
        {
            int diffX = Math.Abs(x - this.X);
            int diffY = Math.Abs(y - this.Y);
            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }
    }
}
