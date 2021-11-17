using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.UnitTests.Entities
{
    public class CustomerTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void canReserve_SHOULD_return_value_according_to_clients_vip_status(bool isVip)
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var customer = new Customer(id, isVip);

            //Assert
            customer.Id.Should().Be(id);
            customer.CanReserve().Should().Be(isVip);
        }
    }
}
