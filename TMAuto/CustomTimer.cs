using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TMAuto
{
    class CustomTimer : Timer
    {
        private int from;
        private int to;
        private Random random;

        /// <summary>
        /// values in seconds
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public CustomTimer(int from, int to)
        {
            this.from = 1000 * from;
            this.to = 1000 * to;
            this.random = new Random();
            this.Elapsed += new ElapsedEventHandler((sender, e) => setRandomInterval());

            setRandomInterval();
        }

        private void setRandomInterval()
        {
            Interval = random.Next(from, to);
        }

        public void setRandomInterval(int from, int to)
        {
            if (this.from == (1000 * from) && (this.to == 1000 * to))
            {
                return;
            }

            this.from = 1000 * from;
            this.to = 1000 * to;
            setRandomInterval();
        }
    }
}
