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
            var isoCode = "PLN";
            var expectedCurr = CurrencyRepo.Get(isoCode);

            //Act
            var actualCurr = new Currency(isoCode);

            //Assert
            actualCurr.Should().Be(expectedCurr);
        }

        [Fact]
        public void ctor_SHOULD_throw_ArgumentException_WHEN_invalid_isoCode_is_passed()
        {
            //Arrange
            Action action = () => new Currency("Fake iso code");

            //Act & Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
