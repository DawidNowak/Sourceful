using System;

namespace Domain.Entities
{
    /// <summary>
    /// In Artwork bounded context Customer is not an aggregate root,
    /// here we need only information about it's ID and Vip status.
    /// Clients will be added into db by IntegrationEventHandler as a result of
    /// emiting ClientCreatedIntegrationEvent from CustomerBoundedContext
    /// </summary>
    public class Customer
    {
        private bool _isVip;

        public Guid Id { get; }

        public Customer(Guid id, bool isVip)
        {
            Id = id;
            _isVip = isVip;
        }

        public bool CanReserve()
        {
            return _isVip;
        }
    }
}
