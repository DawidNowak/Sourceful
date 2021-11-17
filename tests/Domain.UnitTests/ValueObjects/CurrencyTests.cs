using Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.UnitTests.ValueObjects
{
    public class CurrencyTests
    {
        private static Currency.CurrencyRepository CurrencyRepo = new();

        [Fact]
        public void ctor_SHOULD_instantiate_Currency_WHEN_valid_isoCode_is_passed()
        {
            //Arrange
            var expectedCurr = CurrencyRepo.Get(Consts.PlnIsoCode);

            //Act
            var actualCurr = new Currency(Consts.PlnIsoCode);

            //Assert
            actualCurr.Should().Be(expectedCurr);
        }

        [Fact]
        public void ctor_SHOULD_throw_ArgumentException_WHEN_invalid_isoCode_is_passed()
        {
            //Arrange
            Action action = () => new Currency("Fake iso code");

            //Act & Assert
            action.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void two_Currency_SHOULD_be_equal_WHEN_they_have_the_same_values()
        {
            //Arrange
            var first = new Currency(Consts.PlnIsoCode, Consts.PlnSymbol);
            var second = new Currency(Consts.PlnIsoCode, Consts.PlnSymbol);

            //Act
            var areEqual = first == second;

            //Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void two_Currency_SHOULD_not_be_equal_WHEN_they_have_different_values()
        {
            //Arrange
            var first = new Currency(Consts.PlnIsoCode, "symbol1");
            var second = new Currency(Consts.PlnIsoCode, "symbol2");

            //Act
            var areEqual = first == second;

            //Assert
            areEqual.Should().BeFalse();
        }
    }
}
