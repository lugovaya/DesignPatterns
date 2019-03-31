using System;

namespace DesignPatterns.Common.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public override int CompareTo(object obj)
        {
            if (obj is Customer customer)
            {
                return string.Compare(Name, customer.Name, StringComparison.Ordinal);
            }
            
            throw new InvalidCastException();
        }
    }
}