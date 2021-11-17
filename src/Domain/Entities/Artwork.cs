using Domain.Common;
using Domain.Contracts;
using Domain.Events;
using Domain.Exceptions;
using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class Artwork : AggregateRoot
    {
        private string _name;
        private Money _price;
        private DateTime _created;
        private string _creator;

        private Guid? _boughtByCustomerId;
        private Guid? _reservationCustomerId;

        internal Artwork(Guid id, string name, Money price, DateTime created, string creator)
        {
            Id = id;
            _name = name;
            _price = price;
            _created = created;
            _creator = creator;

            PublishEvent(new ArtworkCreatedEvent(Id, name, price, created, creator));
        }

        public void Buy(Guid customerId)
        {
            if (_boughtByCustomerId != null)
            {
                throw new ArtworkAlreadyBoughtException();
            }

            if (_reservationCustomerId != null && _reservationCustomerId != customerId)
            {
                throw new ArtworkReservedByOtherCustomerException();
            }

            _boughtByCustomerId = customerId;
            PublishEvent(new ArtworkBoughtEvent(Id, customerId));
        }

        public void Reserve(Guid customerId, ICustomerRepository customerRepository)
        {
            //TODO: conditional logic can be extracted into policy with CanReserve method.

            if (_boughtByCustomerId == customerId)
            {
                throw new ArtworkAlreadyBoughtByCustomerException();
            }

            if (_boughtByCustomerId != null)
            {
                throw new ArtworkAlreadyBoughtException();
            }

            if (customerRepository.Get(customerId)?.CanReserve() == false)
            {
                throw new CustomerCantReserveArtworkException();
            }

            if (_reservationCustomerId == customerId)
            {
                throw new ArtworkAlreadyReservedByCustomerException();
            }

            if (_reservationCustomerId != null)
            {
                throw new ArtworkAlreadyReservedException();
            }

            _reservationCustomerId = customerId;
            PublishEvent(new ArtworkReservedEvent(Id, customerId));
        }

        public void RevokeReservation(Guid customerId)
        {
            if (_reservationCustomerId == null)
            {
                throw new ArtworkNotReservedException();
            }

            if (_reservationCustomerId == customerId)
            {
                throw new ArtworkReservedByOtherCustomerException();
            }

            _reservationCustomerId = null;
        }
    }
}
