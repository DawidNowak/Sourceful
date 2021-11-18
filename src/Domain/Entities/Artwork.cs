using Domain.Common;
using Domain.Contracts;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Artwork : AggregateRoot
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public int? Created { get; private set; }
        public string Creator { get; private set; }
        public Guid ArtGalleryId { get; private set; }
        public Guid? BoughtByCustomerId { get; private set; }
        public Guid? ReservationCustomerId { get; private set; }

        //EF ctor
        private Artwork(Guid id) : base(id)
        { }

        internal Artwork(Guid id, Guid galleryId, string name, Money price, int? created, string creator)
            : base(id)
        {
            ArtGalleryId = galleryId;
            Name = name;
            Price = price;
            Created = created;
            Creator = creator;

            PublishEvent(new ArtworkCreatedEvent(Id, name, price, created, creator));
        }

        public void Buy(Guid customerId)
        {
            if (BoughtByCustomerId != null)
            {
                throw new ArtworkAlreadyBoughtException();
            }

            if (ReservationCustomerId != null && ReservationCustomerId != customerId)
            {
                throw new ArtworkReservedByOtherCustomerException();
            }

            BoughtByCustomerId = customerId;
            PublishEvent(new ArtworkBoughtEvent(Id, customerId));
        }

        public async Task ReserveAsync(Guid customerId, ICustomerRepository customerRepository)
        {
            //******************************************
            //TODO: EXTRACT VALIDATION LOGIC TO A POLICY
            //******************************************

            if (BoughtByCustomerId == customerId)
            {
                throw new ArtworkAlreadyBoughtByCustomerException();
            }

            if (BoughtByCustomerId != null)
            {
                throw new ArtworkAlreadyBoughtException();
            }

            if ((await customerRepository.GetByIdAsync(customerId))?.CanReserve() == false)
            {
                throw new CustomerCantReserveArtworkException();
            }

            if (ReservationCustomerId == customerId)
            {
                throw new ArtworkAlreadyReservedByCustomerException();
            }

            if (ReservationCustomerId != null)
            {
                throw new ArtworkAlreadyReservedException();
            }

            ReservationCustomerId = customerId;
            PublishEvent(new ArtworkReservedEvent(Id, customerId));
        }

        public void RevokeReservation(Guid customerId)
        {
            if (ReservationCustomerId == null)
            {
                throw new ArtworkNotReservedException();
            }

            if (ReservationCustomerId == customerId)
            {
                throw new ArtworkReservedByOtherCustomerException();
            }

            ReservationCustomerId = null;
            PublishEvent(new ArtworkReservationRevokedEvent(Id, customerId));
        }
    }
}
