using System;

namespace DesignPatterns.Common.Models
{
    public abstract class BaseEntity<TId> : IComparable
    {
        public TId Id { get; set; }

        public abstract int CompareTo(object obj);
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}