using System.Collections.Generic;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Common
{
    /// <summary>
    /// CRUD operations API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey">The type of PK</typeparam>
    public interface IRepository<T, TKey> where T : BaseEntity<TKey> // represents "Component" member
    {
        void Add(T entity);
        
        void Delete(T entity);
        
        void Update(T entity);
        
        IEnumerable<T> GetAll();
        
        T GetById(int id);
    }

    /// <inheritdoc />
    public interface IRepository<T> : IRepository<T, int> where T : BaseEntity // represents "Component" member
    {
    }
}