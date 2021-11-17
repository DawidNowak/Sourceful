using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public interface IHasDomainEvent
    {
        IEnumerable<DomainEvent> GetUnpublishedEvents();
    }

    public abstract class DomainEvent
    {
        protected DomainEvent(Guid aggregateRootId)
        {
            AggregateRootId = aggregateRootId;
            DateOccurred = DateTimeOffset.UtcNow;
        }

        public Guid AggregateRootId { get; }
        public DateTimeOffset DateOccurred { get; }
    }
}
