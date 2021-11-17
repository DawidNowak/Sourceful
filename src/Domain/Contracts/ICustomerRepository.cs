using Domain.Entities;
using System;

namespace Domain.Contracts
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
    }
}
