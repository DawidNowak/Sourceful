using Domain.Common;
using System;

namespace Domain.Events
{
    public sealed class ArtworkReservationRevokedEvent : DomainEvent
    {
        public ArtworkReservationRevokedEvent(Guid aggregateRootId, Guid customerId)
            : base(aggregateRootId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
