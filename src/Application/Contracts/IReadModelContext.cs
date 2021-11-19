using Domain.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IReadModelContext
    {
        Task<IQueryable<TEntity>> GetQueryAsync<TEntity>(params Expression<Func<TEntity, object>>[] includePaths) where TEntity : Entity;
    }
}
