using Domain.Common;
using Domain.ValueObjects;
using System;

namespace Domain.Events
{
    public sealed class ArtworkCreatedEvent : DomainEvent
    {
        public ArtworkCreatedEvent(Guid aggregateRootId, string name, Money price, DateTime? created, string creator)
            : base(aggregateRootId)
        {
            Name = name;
            Price = price;
            Created = created;
            Creator = creator;
        }

        public string Name { get; }
        public Money Price { get; }
        public DateTime? Created { get; }
        public string Creator { get; }
    }
}
