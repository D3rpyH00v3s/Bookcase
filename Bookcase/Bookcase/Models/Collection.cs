using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Bookcase.Models
{
    public class UCollection<T> : ICollection<T>, IEnumerator<T>, INotifyCollectionChanged where T : Item
    {
        T[] items = new T[0];

        protected int position = -1;
        bool IEnumerator.MoveNext()
        {
            if (position < items.Length - 1)
            { position++; return true; }
            return false;
        }
        object IEnumerator.Current => items[position];
        IEnumerator IEnumerable.GetEnumerator() => this;
        void IEnumerator.Reset() => position = -1;
        public IEnumerator<T> GetEnumerator() => this;
        public T Current => items[position];
        public void Dispose() => ((IEnumerator)this).Reset();


        public int Count => items.Length;

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            T[] newItems = new T[Count + 1];
            for (int i = 0; i < Count; i++)
                newItems[i] = items[i];
            newItems[Count] = item;
            items = newItems;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void Clear()
        {
            items = new T[0];
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
                if (items[i] == item) return true;
            return false;
        }

        int Max(int a, int b) => a > b ? a : b;

        public void CopyTo(T[] array, int arrayIndex)
        {
            T[] newArray = new T[Max(arrayIndex + Count, array.Length)];
            for (int i = 0; i < Count; i++)
                array[arrayIndex + i] = items[i];
        }

        public bool Remove(T item)
        {
            T[] newItems = new T[Count - 1];
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    for (int j = i; j < Count - 1; j++)
                        newItems[j] = items[j + 1];
                    items = newItems;
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
                    return true;
                }
                newItems[i] = items[i];
            }
            return false;
        }

        //public UCollection<T> FromCollection(IOrderedEnumerable<T> ts)
        //{
        //    UCollection<T> ans = new UCollection<T>();
        //    foreach (T item in ts)
        //        ans.Add(item);
        //    return ans;
        //}
    }
}
