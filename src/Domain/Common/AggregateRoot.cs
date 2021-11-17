using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public abstract class AggregateRoot : IHasDomainEvent
    {
        private readonly List<DomainEvent> _events = new();

        public Guid Id { get; protected set; }

        public IEnumerable<DomainEvent> GetUnpublishedEvents()
        {
            return _events;
        }

        protected void PublishEvent(DomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}
