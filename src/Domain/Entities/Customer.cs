using System;

namespace Domain.Entities
{
    /// <summary>
    /// In Artwork bounded context Customer is not an aggregate root,
    /// here we need only information about it's ID and Vip status
    /// </summary>
    public class Customer
    {
        public Guid Id;
        private bool _isVip;

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
