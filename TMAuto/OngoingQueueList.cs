using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class OngoingQueueList : List<OngoingQueueBuilding>, IBindingList
    {
        public delegate void OngoingQueueChangedHandler(ListChangedEventHandler listChanged, object sender, ListChangedEventArgs e);
        public event OngoingQueueChangedHandler OngoingQueueListChanged;

        public new void Clear()
        {
            base.Clear();

            if (ListChanged != null)
            {
                OngoingQueueListChanged(ListChanged, this, new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
        }
        public void AddRange(OngoingQueueList queue)
        {
            base.AddRange(queue);

            if (ListChanged != null)
            {
                OngoingQueueListChanged(ListChanged, this, new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
        }
        public bool AllowEdit
        {
            get
            {
                return true;
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

        public bool IsSorted
        {
            get
            {
                return false;
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

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
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
