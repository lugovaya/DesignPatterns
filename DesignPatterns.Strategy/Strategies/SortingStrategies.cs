using System.Collections.Generic;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Strategy.Strategies
{
    // represents "Strategy"
    public interface ISortStrategy<T, TKey> where T : BaseEntity<TKey>
    {
        void Sort(IList<T> source);
    }

    // also represents "Strategy"
    public interface ISortStrategy<T> : ISortStrategy<T, int> where T : BaseEntity
    {
    }
}