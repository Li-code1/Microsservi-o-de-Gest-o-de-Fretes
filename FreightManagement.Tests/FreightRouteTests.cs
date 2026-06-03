// FreightManagement.Tests/FreightRouteTests.cs
using Xunit;
using FluentAssertions;
using FreightManagement.Api.Models;

namespace FreightManagement.Tests
{
    public class FreightRouteTests
    {
        [Fact]
        public void CalculateTotalFreight_ShouldCalculateCorrectly_WhenDistanceIsStandard()
        {
            // Arrange
            var route = new FreightRoute
            {
                Origin = "São Paulo",
                Destination = "Santos",
                DistanceInKm = 100
            };

            // Act
            var total = route.CalculateTotalFreight();

            // Assert
            // 100km * 2.50 = 250
            total.Should().Be(250.00m);
        }

        [Fact]
        public void CalculateTotalFreight_ShouldApplyExtraCharge_WhenDistanceIsLongerThan500Km()
        {
            // Arrange
            var route = new FreightRoute
            {
                Origin = "São Paulo",
                Destination = "Brasília",
                DistanceInKm = 1000
            };

            // Act
            var total = route.CalculateTotalFreight();

            // Assert
            // (1000km * 2.50) + 100 (taxa adicional) = 2600
            total.Should().Be(2600.00m);
        }

        [Fact]
        public void CalculateTotalFreight_ShouldThrowException_WhenDistanceIsZeroOrNegative()
        {
            // Arrange
            var route = new FreightRoute { DistanceInKm = -10 };

            // Act
            Action act = () => route.CalculateTotalFreight();

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("A distância deve ser maior que zero.");
        }
    }
}
