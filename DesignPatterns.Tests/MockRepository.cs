using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Common;
using DesignPatterns.Common.Exceptions;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Tests
{
    public class MockRepository<T> : IRepository<T> where T : BaseEntity // represents concrete "Component"
    {
        private readonly IList<T> _collection = new List<T>();
        
        public void Add(T entity)
        {
            _collection.Add(entity);
        }

        public void Delete(T entity)
        {
            var succeed = _collection.Remove(entity);
            
            if(!succeed)
                throw new FailedOperationExceptions();
        }

        public void Update(T entity)
        {
        }

        public IEnumerable<T> GetAll()
        {
            return _collection;
        }

        public T GetById(int id)
        {
            return _collection.FirstOrDefault();
        }
    }
}