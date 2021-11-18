using Application.Artworks.Commands.CreateArtwork;
using Domain.Contracts;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Factories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Artworks.Commands.CreateArtwork
{
    public class CreateArtworkCommandHandlerTests
    {
        [Fact]
        public async Task handler_SHOULD_add_new_artwork()
        {
            //Arrange
            var artworkRepoMock = new Mock<IArtworkRepository>();
            artworkRepoMock.Setup(x => x.SaveAsync(It.IsAny<Artwork>()))
                .Verifiable();

            var artworkFactory = new ArtworkFactory();

            var command = new CreateArtworkCommand
            {
                GalleryId = Consts.GalleryId,
                Name = Consts.Name,
                Creator = Consts.Creator,
                Price = Consts.Price,
                CurrencyIsoCode = Consts.PLN,
                Created = DateTime.Now.Year
            };

            var handler = new CreateArtworkCommandHandler(artworkFactory, artworkRepoMock.Object);

            //Act
            var artworkId = await handler.Handle(command, CancellationToken.None);

            //Assert
            artworkId.Should().NotBeEmpty();
            artworkRepoMock.Verify(r => r.SaveAsync(It.IsAny<Artwork>()), Times.Once);
        }
    }
}
