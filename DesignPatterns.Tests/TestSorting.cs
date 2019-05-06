using System.Linq;
using DesignPatterns.Common.Models;
using DesignPatterns.Strategy;
using DesignPatterns.Strategy.Strategies;
using Xunit;

namespace DesignPatterns.Tests
{
    public class TestSorting
    {
        private ISortStrategy<Customer> _sortStrategy;

        [Fact]
        public void TestBubbleSorting()
        {
            // Arrange
            _sortStrategy = new BubbleSort<Customer>();
            var sortList = new SortedList<Customer>(_sortStrategy);

            // Act
            foreach (var customer in MockHelper.CreateCollection<Customer>())
            {
                sortList.Add(customer);
            }
            sortList.Sort();
            
            // Assert
        }
        
        [Fact]
        public void TestQuickSorting()
        {
            // Arrange
            _sortStrategy = new QuickSort<Customer>();
            var sortList = new SortedList<Customer>(_sortStrategy);
            var collection = MockHelper.CreateCollection<Customer>().ToList();

            // Act
            foreach (var customer in collection)
            {
                sortList.Add(customer);
            }
            sortList.Sort();
            

            // Assert
        }
        
        [Fact]
        public void TestShellSorting()
        {
            // Arrange
            _sortStrategy = new ShellSort<Customer>();
            var sortList = new SortedList<Customer>(_sortStrategy);

            // Act
            foreach (var customer in MockHelper.CreateCollection<Customer>())
            {
                sortList.Add(customer);
            }
            sortList.Sort();
            
            // Assert
        }
        
        [Fact]
        public void TestMergeSorting()
        {
            // Arrange
            _sortStrategy = new MergeSort<Customer>();
            var sortList = new SortedList<Customer>(_sortStrategy);

            // Act
            foreach (var customer in MockHelper.CreateCollection<Customer>())
            {
                sortList.Add(customer);
            }
            sortList.Sort();
            
            // Assert
        }
    }
}