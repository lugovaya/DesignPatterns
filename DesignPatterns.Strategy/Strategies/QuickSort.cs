using DesignPatterns.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Strategy.Strategies
{
    public class QuickSort<T> : ISortStrategy<T> where T : BaseEntity  // represents concrete "Strategy"
    {
        public void Sort(IList<T> source)
        {
            var list = source?.ToList() ?? new List<T>();
            
            list.Sort();
        }
    }
}