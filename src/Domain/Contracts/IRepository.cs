using Domain.Common;
using System;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);
    }
}
