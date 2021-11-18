using Domain.Common;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext DbContext;
        protected IUnitOfWork UnitOfWork => DbContext as IUnitOfWork;

        protected EfRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<TEntity>().FindAsync(new[] { id });
        }
    }
}
