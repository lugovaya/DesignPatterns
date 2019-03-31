using System.Collections.Generic;
using Moq;

namespace DesignPatterns.Tests
{
    public static class MockHelper
    {
        public static T CreateNew<T>() where T : class
        {
            return new Mock<T>().Object;
        }

        public static IEnumerable<T> CreateCollection<T>() where T : class
        {
            return new Mock<List<T>>().Object;
        }

        public static IList<T> CreateSequence<T>(int size) where T : class
        {
            var array = new T[size];

            for (var i = 0; i < size; i++)
            {
                array[i] = new Mock<T>().Object;
            }

            return array;
        }
    }
}