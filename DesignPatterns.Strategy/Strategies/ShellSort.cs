using System.Collections.Generic;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Strategy.Strategies
{
    public class ShellSort<T> : ISortStrategy<T> where T : BaseEntity // represents concrete "Strategy"
    {
        public void Sort(IList<T> source)
        {
            var n = source.Count;
            var gap = n / 2;

            while (gap > 0)
            {
                for (var i = 0; i + gap < n; i++)
                {
                    var j = i + gap;
                    var temp = source[j];
 
                    while (j - gap >= 0 && temp.CompareTo(source[j - gap]) < 0)
                    {
                        source[j] = source[j - gap];
                        j = j - gap;
                    }
 
                    source[j] = temp;
                }
 
                gap = gap / 2;
            }
        }
    }
}