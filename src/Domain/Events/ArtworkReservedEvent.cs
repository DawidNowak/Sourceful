using Domain.Common;
using System;

namespace Domain.Events
{
    public sealed class ArtworkReservedEvent : DomainEvent
    {
        public ArtworkReservedEvent(Guid aggregateRootId, Guid customerId) : base(aggregateRootId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
