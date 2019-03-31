using System;
using System.Linq;
using DesignPatterns.Singleton;
using Xunit;

namespace DesignPatterns.Tests
{
    public class TestLoadBalancer
    {
        [Fact]
        public void InstanceShouldBeTheSame()
        {
            // Arrange
            bool result;
            var balancersSequence = MockHelper.CreateSequence<LoadBalancer>(5);

            // Act
            result = balancersSequence.Any(x => x == balancersSequence[0]);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PrintUsingServers()
        {
            // Arrange
            Server server = null;
            var balancer = LoadBalancer.Instance;

            // Act
            for (var i = 0; i < 10; i++)
            {
                server = balancer.NextServer;
                Console.WriteLine($"Dispatch Request to: {server.Name}");
            }

            // Assert
            Assert.NotNull(server);
        }
    }
}