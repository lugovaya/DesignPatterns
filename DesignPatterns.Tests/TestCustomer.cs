using System;
using System.Linq;
using DesignPattern.Proxy;
using DesignPatterns.Common;
using DesignPatterns.Common.Models;
using DesignPatterns.Decorator;
using Xunit;

namespace DesignPatterns.Tests
{
    public class TestCustomer // represents "Client"
    {
        private IRepository<Customer> _customerRepository;

        [Fact]
        public void AddCustomerWithLogging()
        {
            // Arrange
            _customerRepository = new LoggerRepository<Customer>(new MockRepository<Customer>());
            var entity = MockHelper.CreateNew<Customer>();
            
            // Assert
            _customerRepository.Add(entity);
            var collectionSize = _customerRepository.GetAll().Count();
            
            // Assert
            Assert.Equal(1, collectionSize);
        }
        
        [Fact]
        public void AddCustomerWithLoggingUsingProxy()
        {
            // Arrange
            _customerRepository = new LoggerRepository<Customer>(new MockRepository<Customer>());
            var entity = MockHelper.CreateNew<Customer>();
            
            // Assert
            var proxy = DynamicProxy<IRepository<Customer>>.Create(_customerRepository,
                (sender, info) => Console.WriteLine($"Before execution of method {info.Name}"),
                (sender, info) => Console.WriteLine($"Success execution of the method {info.Name}"), 
                (sender, info) => Console.WriteLine($"Execution {info.Name} is failed"));
            proxy.Add(entity);
            var collectionSize = _customerRepository.GetAll().Count();
            
            // Assert
            Assert.Equal(1, collectionSize);
        }
    }
}