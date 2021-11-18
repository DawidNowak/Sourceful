using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public abstract class AggregateRoot : Entity, IHasDomainEvent
    {
        private readonly List<DomainEvent> _events = new();

        protected AggregateRoot(Guid id) : base(id)
        {
        }


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
