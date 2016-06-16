﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class PriorityQueue
    {
        public BuildingQueueList List = new BuildingQueueList();
        public void Enqueue(int priority, QueuedBuilding building)
        {
            List.Add(priority, building);
        }
       
        public QueuedBuilding Peek() {
            return List.First();
        }

		public void Dequeue()
        {
            RemoveAt(0);
        }

		public bool Empty()
        {
            return List.Count == 0;
        }

        public int GetOffset(int id)
        {
            return List.Count(i => i.Value.Id == id);
        }

        public void RemoveAt(int index)
        {
            Action remove = () => List.RemoveAt(index);

            BuildingManager.RemoveAction(remove);
        }
    }
}
