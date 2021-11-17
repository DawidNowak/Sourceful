using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Customer : AggregateRoot
    {
        private string _firstName;
        private string _lastName;
        private bool _isVip;

        public Customer(Guid id, string firstName, string lastName, bool isVip)
        {
            Id = id;
            _firstName = firstName;
            _lastName = lastName;
            _isVip = isVip;
        }

        public bool CanReserve()
        {
            return _isVip;
        }
    }
}
