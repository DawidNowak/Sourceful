using Domain.Contracts;
using Domain.Entities;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Domain.UnitTests.Entities
{
    public class ArtworkTests
    {
        private const string Name = "Artwork name";
        private const string Creator = "Author";

        private static Guid Id = Guid.NewGuid();
        private static Guid GalleryId = Guid.NewGuid();
        private static Guid CustomerId = Guid.NewGuid();
        private static int Created = DateTime.Now.Year;
        private static Money Price = new(1000m, new("PLN"));

        [Fact]
        public void buy_artwork_SHOULD_publish_bought_event_WHEN_no_reservation_is_made_AND_was_not_sold_already()
        {
            //Arrange
            var artwork = new Artwork(Id, GalleryId, Name, Price, Created, Creator);

            //Act
            artwork.Buy(CustomerId);

            //assert
            var events = artwork.GetUnpublishedEvents();

            events.Should().HaveCount(2);
            events.First().Should().BeOfType(typeof(ArtworkCreatedEvent));
            events.Last().Should().BeOfType(typeof(ArtworkBoughtEvent));
        }

        [Fact]
        public void reserve_artwork_SHOULD_publish_event_WHEN_no_reservation_is_made_AND_was_not_sold_already()
        {
            //Arrange
            var artwork = new Artwork(Id, GalleryId, Name, Price, Created, Creator);
            var customer = new Customer(CustomerId, true);

            //Act
            artwork.ReserveAsync(CustomerId, SetupCustomerRepositoryMock(customer));

            //Assert
            var events = artwork.GetUnpublishedEvents();

            events.Should().HaveCount(2);
            events.Last().Should().BeOfType(typeof(ArtworkReservedEvent));
        }

        [Fact]
        public void buy_artwork_SHOULD_throw_exception_WHEN_already_sold()
        {
            //Arrange
            var artwork = new Artwork(Id, GalleryId, Name, Price, Created, Creator);
            artwork.Buy(CustomerId);

            //Act
            Action action = () => artwork.Buy(CustomerId);

            //assert
            action.Should().ThrowExactly<ArtworkAlreadyBoughtException>();
        }

        [Fact]
        public void buy_artwork_SHOULD_throw_exception_WHEN_reserved_by_other_Customer()
        {
            //Arrange
            var otherCustomer = new Customer(Guid.NewGuid(), true);

            var artwork = new Artwork(Id, GalleryId, Name, Price, Created, Creator);
            artwork.ReserveAsync(otherCustomer.Id, SetupCustomerRepositoryMock(otherCustomer));

            //Act
            Action action = () => artwork.Buy(CustomerId);

            //Assert
            action.Should().ThrowExactly<ArtworkReservedByOtherCustomerException>();
        }

        //****************************************
        //TODO: PREPARE THE REST OF THE TEST CASES
        //****************************************

        private static ICustomerRepository SetupCustomerRepositoryMock(Customer customer)
        {
            var mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetByIdAsync(customer.Id))
                .ReturnsAsync(customer);

            return mock.Object;
        }
    }
}
