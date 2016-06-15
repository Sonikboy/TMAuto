using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class Resources
    {
        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Iron { get; set; }
        public int Crop { get; set; }

        public int FreeCrop { get; set; }
        public override string ToString()
        {
            return String.Format("Wood: {0}, Clay: {1}, Iron: {2}, Crop: {3}, FreeCrop: {4}", Wood, Clay, Iron, Crop, FreeCrop);
        }
    }
}
