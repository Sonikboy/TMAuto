using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class BuildingQueueList : SortedList<int, QueuedBuilding>, IBindingList
    {
        public BuildingQueueList() : base(new PriorityComparer())
        {
        }
        public new void Add(int priority, QueuedBuilding building)
        {
            base.Add(priority, building);

            ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, Count - 1));
        }
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);

            ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        public QueuedBuilding First()
        {
            return Values[0];
        }
        object IList.this[int index]
        {
            get
            {
                return Values[index];
            }
            set
            {
                return;
            }
        }

        public bool AllowEdit
        {
            get
            {
                return false; 
            }
        }

        public bool AllowNew
        {
            get
            {
                return true;
            }
        }

        public bool AllowRemove
        {
            get
            {
                return true;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSorted
        {
            get
            {
                return true;
            }
        }

        public ListSortDirection SortDirection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PropertyDescriptor SortProperty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool SupportsChangeNotification
        {
            get
            {
                return true;
            }
        }

        public bool SupportsSearching
        {
            get
            {
                return false;
            }
        }

        public bool SupportsSorting
        {
            get
            {
                return false;
            }
        }

        public event ListChangedEventHandler ListChanged;

        public int Add(object value)
        {
            throw new NotImplementedException();
        }
        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public object AddNew()
        {
            return null;
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            RemoveAt(Values.IndexOf((QueuedBuilding)value));
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }
    }
}
