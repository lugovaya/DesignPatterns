using DesignPatterns.Common.Models;
using System.Collections.Generic;

namespace DesignPatterns.Strategy.Strategies
{
    public class BubbleSort<T> : ISortStrategy<T>  where T : BaseEntity  // represents concrete "Strategy"
    {
        public void Sort(IList<T> source)
        {
            bool swapped;
 
            do
            {
                swapped = false;
                for (var i = 1; i < source.Count; i++) 
                {
                    if (source[i - 1].CompareTo(source[i]) <= 0) 
                        continue;
                    
                    Swap(source, i - 1, i);
                    swapped = true;
                }
            } while (swapped);
        }
        
        private static void Swap(IList<T> items, int left, int right)
        {
            if (left == right) return;
            
            var temp = items[left];
            items[left] = items[right];
            items[right] = temp;
        }
    }
}