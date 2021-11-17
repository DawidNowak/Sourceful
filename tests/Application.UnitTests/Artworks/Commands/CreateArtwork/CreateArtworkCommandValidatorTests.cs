using Application.Artworks.Commands.CreateArtwork;
using FluentAssertions;
using System;
using Xunit;

namespace Application.UnitTests.Artworks.Commands.CreateArtwork
{
    public class CreateArtworkCommandValidatorTests
    {

        [Fact]
        public void validator_SHOULD_validate_command_WITH_proper_values()
        {
            //Arrange
            var createArtworkCommand = new CreateArtworkCommand
            {
                GalleryId = Consts.GalleryId,
                Name = Consts.Name,
                Creator = Consts.Creator,
                Price = Consts.Price,
                CurrencyIsoCode = Consts.PLN,
                Created = DateTime.Now.AddDays(-7)
            };

            var validator = new CreateArtworkCommandValidator();

            //Act
            var result = validator.Validate(createArtworkCommand);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void validator_SHOULD_invalidate_command_WHEN_Name_too_short()
        {
            //Arrange
            var createArtworkCommand = new CreateArtworkCommand
            {
                GalleryId = Consts.GalleryId,
                Name = "12",
                Creator = Consts.Creator,
                Price = Consts.Price,
                CurrencyIsoCode = Consts.PLN
            };

            var validator = new CreateArtworkCommandValidator();

            //Act
            var result = validator.Validate(createArtworkCommand);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void validator_SHOULD_invalidate_command_WHEN_future_creation_date()
        {
            //Arrange
            var createArtworkCommand = new CreateArtworkCommand
            {
                GalleryId = Consts.GalleryId,
                Name = Consts.Name,
                Creator = Consts.Creator,
                Price = Consts.Price,
                CurrencyIsoCode = Consts.PLN,
                Created = DateTime.Now.AddDays(7)
            };

            var validator = new CreateArtworkCommandValidator();

            //Act
            var result = validator.Validate(createArtworkCommand);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }
    }
}
