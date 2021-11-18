using Domain.Common;
using System;

namespace Domain.Entities
{
    /// <summary>
    /// In Artwork bounded context Customer is not an aggregate root,
    /// here we need only information about it's ID and Vip status.
    /// Clients will be added into db by IntegrationEventHandler as a result of
    /// emiting ClientCreatedIntegrationEvent from CustomerBoundedContext
    /// </summary>
    public class Customer : Entity
    {

        public bool IsVip { get; private set; }


        public Customer(Guid id, bool isVip) : base(id)
        {
            IsVip = isVip;
        }

        public bool CanReserve()
        {
            return IsVip;
        }
    }
}
