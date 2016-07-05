using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    public enum Tribe { Romans = 1, Teutons, Gauls }
    sealed class Player
    {
        private static readonly Player instance = new Player();
        public static Player Instance { get { return instance; } }

        public int AllyId { get; set; }
        public Tribe Tribe { get; set; }
        public List<Village> Villages { get; set;}

        public delegate void OngoingQueueChangedHandler(ListChangedEventHandler listChanged, object sender, ListChangedEventArgs e);
        public event OngoingQueueChangedHandler OngoingQueueChanged;

        private Player()
        {
            Villages = new List<Village>();
        }
        public void AddVillage(Village village)
        {
            Villages.Add(village);

            village.OngoingQueue.OngoingQueueListChanged += new OngoingQueueList.OngoingQueueChangedHandler(ongoingQueueHandler);
        }

        private void ongoingQueueHandler(ListChangedEventHandler listChanged, object sender, ListChangedEventArgs e)
        {
            OngoingQueueChanged(listChanged, sender, e);
        }
    }
}
