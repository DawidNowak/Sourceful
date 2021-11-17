using Domain.Common;
using System;

namespace Domain.Events
{
    public sealed class ArtworkBoughtEvent : DomainEvent
    {
        public ArtworkBoughtEvent(Guid aggregateRootId, Guid customerId)
            : base(aggregateRootId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
