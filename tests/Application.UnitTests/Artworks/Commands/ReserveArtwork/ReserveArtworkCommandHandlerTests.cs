using Application.Artworks.Commands.ReserveArtwork;
using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Events;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Artworks.Commands.ReserveArtwork
{
    public class ReserveArtworkCommandHandlerTests
    {
        [Fact]
        public async Task handler_SHOULD_reserve_artwork()
        {
            //Arrange
            var price = new Money(Consts.Price, new(Consts.PLN));
            var artwork = new Artwork(Consts.ArtworkId, Consts.GalleryId, Consts.Name, price, null, null);
            var customer = new Customer(Consts.CustomerId, true);

            var artworkRepoMock = new Mock<IArtworkRepository>();
            artworkRepoMock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(artwork)
                .Verifiable();

            var customerRepoMock = new Mock<ICustomerRepository>();
            customerRepoMock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(customer)
                .Verifiable();


            var command = new ReserveArtworkCommand
            {
                ArtworkId = Consts.ArtworkId,
                CustomerId = Consts.CustomerId
            };

            var handler = new ReserveArtworkCommandHandler(artworkRepoMock.Object, customerRepoMock.Object);

            //Act
            await handler.Handle(command, CancellationToken.None);

            //Assert
            artworkRepoMock.Verify(m => m.GetByIdAsync(Consts.ArtworkId), Times.Once);
            customerRepoMock.Verify(m => m.GetByIdAsync(Consts.CustomerId), Times.Once);

            var @event = artwork.GetUnpublishedEvents().Last();
            @event.Should().BeOfType<ArtworkReservedEvent>();
        }

        [Fact]
        public void handler_SHOULD_throw_axception_WHEN_artwork_not_found()
        {
            //Arrange
            var artworkRepoMock = new Mock<IArtworkRepository>();
            artworkRepoMock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Artwork)null)
                .Verifiable();

            var command = new ReserveArtworkCommand
            {
                ArtworkId = Consts.ArtworkId
            };

            var handler = new ReserveArtworkCommandHandler(artworkRepoMock.Object, null);

            //Act
            Func<Task> func = async () => await handler.Handle(command, CancellationToken.None);

            //Assert
            func.Should().ThrowAsync<ArtworkNotFoundException>();
        }
    }
}
