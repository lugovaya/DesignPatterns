using System;
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
            return CreateSequence(() => new Mock<T>().Object, size);
        }

        public static IList<T> CreateSequence<T>(Func<T> createInstance, int count) where T : class
        {
            var array = new T[count];

            for (var i = 0; i < count; i++)
            {
                array[i] = createInstance();
            }

            return array;
        }
    }
}