using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Strategy.Strategies
{
    public class MergeSort<T> : ISortStrategy<T> where T : BaseEntity  // represents concrete "Strategy"
    {
        public void Sort(IList<T> source)
        {
            var arraySource = source?.ToArray() ?? new T[0];
            
            if (arraySource.Length <= 1)
                return;

            var leftSize = arraySource.Length / 2;
            var rightSize = arraySource.Length - leftSize;
            
            var left = new T[leftSize];
            var right = new T[rightSize];
            
            Array.Copy(arraySource, 0, left, 0, leftSize);
            Array.Copy(arraySource, leftSize, right, 0, rightSize);
            
            Sort(left);
            Sort(right);
            
            Merge(arraySource, left, right);
        }
        
        private static void Merge(IList<T> items, IReadOnlyList<T> left, IReadOnlyList<T> right)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            var targetIndex = 0;
            var remaining = left.Count + right.Count;
            
            while(remaining > 0)
            {
                if (leftIndex >= left.Count)
                    items[targetIndex] = right[rightIndex++];
                else if (rightIndex >= right.Count)
                    items[targetIndex] = left[leftIndex++];
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                    items[targetIndex] = left[leftIndex++];
                else
                    items[targetIndex] = right[rightIndex++];
 
                targetIndex++;
                remaining--;
            }
        }
    }
}