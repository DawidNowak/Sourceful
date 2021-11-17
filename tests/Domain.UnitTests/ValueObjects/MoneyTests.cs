using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.ValueObjects
{
    public class MoneyTests
    {

        [Fact]
        public void two_Money_SHOULD_be_equal_WHEN_they_have_the_same_values()
        {
            //Arrange
            var pln = new Currency(Consts.PlnIsoCode);

            var first = new Money(1000m, pln);
            var second = new Money(1000m, pln);

            //Act
            var areEqual = first == second;

            //Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void two_Money_SHOULD_not_be_equal_WHEN_they_have_different_amounts()
        {
            //Arrange
            var pln = new Currency(Consts.PlnIsoCode);

            var first = new Money(1000m, pln);
            var second = new Money(2000m, pln);

            //Act
            var areEqual = first == second;

            //Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void two_Money_SHOULD_not_be_equal_WHEN_they_have_different_currencies()
        {
            //Arrange
            var amount = 1000m;
            var pln = new Currency(Consts.PlnIsoCode);
            var usd = new Currency(Consts.UsdIsoCode);

            var first = new Money(amount, pln);
            var second = new Money(amount, usd);

            //Act
            var areEqual = first == second;

            //Assert
            areEqual.Should().BeFalse();
        }
    }
}
