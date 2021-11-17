using Application.Artworks.Commands.ReserveArtwork;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.Artworks.Commands.ReserveArtwork
{
    public class ReserveArtworkCommandValidatorTests
    {
        [Fact]
        public void validator_SHOULD_validate_command_WITH_proper_values()
        {
            //Arrange
            var reserveArtworkCommand = new ReserveArtworkCommand
            {
                ArtworkId = Consts.ArtworkId,
                CustomerId = Consts.CustomerId
            };

            var validator = new ReserveArtworkCommandValidator();

            //Act
            var result = validator.Validate(reserveArtworkCommand);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void validator_SHOULD_invalidate_command_WHEN_no_ArtworkId_is_passed()
        {
            //Arrange
            var reserveArtworkCommand = new ReserveArtworkCommand
            {
                CustomerId = Consts.CustomerId
            };

            var validator = new ReserveArtworkCommandValidator();

            //Act
            var result = validator.Validate(reserveArtworkCommand);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void validator_SHOULD_invalidate_command_WHEN_no_CustomerId_is_passed()
        {
            //Arrange
            var reserveArtworkCommand = new ReserveArtworkCommand
            {
                ArtworkId = Consts.ArtworkId
            };

            var validator = new ReserveArtworkCommandValidator();

            //Act
            var result = validator.Validate(reserveArtworkCommand);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }
    }
}
