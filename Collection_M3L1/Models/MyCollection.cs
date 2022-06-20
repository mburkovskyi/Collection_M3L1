using Collection_M3L1.Interfaces;

namespace Collection_M3L1.Models
{
    internal class MyCollection<T> : IMyCollection<T>, IComparable
    {
        private int _enumeratorIndexAnalog;
        private object?[] _collection;
        internal MyCollection()
        {
            Collection = new object[1];
        }

        internal object?[] Collection
        {
            get { return _collection.Where(x => x != null).ToArray(); }
            set { _collection = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Collection)
            {
                yield return (T)item;
            }
        }

        public void Remove(T item)
        {
            if (item != null)
            {
                for (int i = 0; i < Collection.Length; i++)
                {
                    if (Collection[i] != null)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        if (Collection[i].Equals(item))
                        {
                            Collection[i] = null;
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                }
            }
        }

        void IMyCollection<T>.AddRange(T[] items)
        {
            if (items != null)
            {
                object[] values = items as object[];
                AddRange(values);
            }
        }

        void IMyCollection<T>.Clear()
        {
            Collection = new object[1];
        }

        public void RemoveAt(int index)
        {
            Collection[index] = null;
        }

        public void Sort(T value)
        {
            bool swapped = default;
            var enumerator = GetEnumerator();
            int count = 0;
            do
            {
                for (_enumeratorIndexAnalog = 1; _enumeratorIndexAnalog < Collection.Length;)
                {
                    swapped = false;
                    if (Collection != null)
                    {
                        for (int i = 1; i < Collection.Length - 1; i++)
                        {
                            try
                            {
                                if (CompareTo(Collection[i]) != 1 || count == Collection.Length)
                                {
                                    object[] nonNullCollection = (object[])Collection;

                                    Swap(nonNullCollection, i - 1, i);
                                    swapped = true;
                                }
                            }
                            catch (Exception e)
                            {
                                swapped = false;
                            }
                            finally
                            {
                                _enumeratorIndexAnalog++;
                            }
                            count++;
                        }
                    }
                }
            }
            while (swapped != false);
        }

        public int CompareTo(object? obj)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            object currentItem = Collection[_enumeratorIndexAnalog];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (currentItem != null)
            {
                if (obj != null)
                {
                    if (currentItem.GetHashCode() < obj.GetHashCode())
                    {
                        return -1;
                    }

                    if (currentItem.GetHashCode() > obj.GetHashCode())
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public void Add(T item)
        {
            int? freeId = GetFreeId();

            if (freeId == -1 && Collection != null)
            {
                var resizeDArray = new object[Collection.Length + 10];
                Array.Copy(Collection, 0, resizeDArray, 0, Collection.Length);
                Collection = resizeDArray;
                freeId = GetFreeId();
            }

            if (freeId != null && Collection != null)
            {
                _collection[(int)freeId] = item;
            }
        }

        internal void AddRange(object[] someArray)
        {
            foreach (var item in someArray)
            {
                Add((T)item);
            }
        }

        private int? GetFreeId()
        {
            int result = Array.IndexOf(_collection, null);

            return result;
        }

        private void Swap(object[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = (T)items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }
    }
}
