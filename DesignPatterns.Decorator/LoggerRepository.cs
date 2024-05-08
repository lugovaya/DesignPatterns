using System;
using System.Collections.Generic;
using DesignPatterns.Common;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Decorator
{
    // represents concrete "Decorator"
    public class LoggerRepository<T> : LoggerRepository<T, int>, IRepository<T> where T : BaseEntity
    {
        public LoggerRepository(IRepository<T, int> decorated) : base(decorated)
        {
        }
    }

    // represents "Decorator"
    public class LoggerRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey> 
    {
        private readonly IRepository<T, TKey> _decorated;

        protected LoggerRepository(IRepository<T, TKey> decorated)
        {
            _decorated = decorated;
        }
        
        private static void Log<TValue>(string msg, TValue arg = default(TValue))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        
        private static void Log(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        
        public void Add(T entity)
        {
            Log("In decorator - Before Adding {0}", entity);
            
            _decorated.Add(entity);
            
            Log("In decorator - After Adding {0}", entity);
        }
        
        public void Delete(T entity)
        {
            Log("In decorator - Before Deleting {0}", entity);
            
            _decorated.Delete(entity);
            
            Log("In decorator - After Deleting {0}", entity);
        }
        
        public void Update(T entity)
        {
            Log("In decorator - Before Updating {0}", entity);
            
            _decorated.Update(entity);
            
            Log("In decorator - After Updating {0}", entity);
        }
        
        public IEnumerable<T> GetAll()
        {
            Log("In decorator - Before Getting Entities");
            
            var result = _decorated.GetAll();
            
            Log("In decorator - After Getting Entities");
            
            return result;
        }
        
        public T GetById(int id)
        {
            Log("In decorator - Before Getting Entity {0}", id);
            
            var result = _decorated.GetById(id);
            
            Log("In decorator - After Getting Entity {0}", id);
            
            return result;
        }
    }
}