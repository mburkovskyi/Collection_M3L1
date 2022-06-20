namespace Collection_M3L1.Interfaces
{
    internal interface IMyCollection<T> : IEnumerable<T>
    {
        public void Add(T item);
        public void Remove(T item);
        public void AddRange(T[] items);
        public void Clear();
        public void RemoveAt(int index);
        public void Sort(T value);
    }
}
