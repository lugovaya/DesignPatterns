using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Common.Models;
using DesignPatterns.Strategy.Strategies;

namespace DesignPatterns.Strategy
{
    // represents "Context"
    public class SortedList<T> : ICollection<T> where T : BaseEntity
    {
        private readonly IList<T> _collection;
        private readonly ISortStrategy<T> _sortStrategy;
 
        public SortedList(ISortStrategy<T> sortStrategy)
        {
            _collection = new List<T>();
            _sortStrategy = sortStrategy;
        }
 
        public void Add(T entity)
        {
            _collection.Add(entity);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public int Count => _collection.Count;
        
        public bool IsReadOnly => _collection.IsReadOnly;

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _collection.Remove(item);
        }

        public void Sort()
        {
            _sortStrategy.Sort(_collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}