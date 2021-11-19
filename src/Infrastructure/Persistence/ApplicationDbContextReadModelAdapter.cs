using Application.Contracts;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextReadModelAdapter : IReadModelContext
    {
        private readonly DbContext _dbContext;

        public ApplicationDbContextReadModelAdapter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<TEntity>> GetQueryAsync<TEntity>(params Expression<Func<TEntity, object>>[] includePaths) where TEntity : Entity
        {
            var dbSet = _dbContext.Set<TEntity>().AsNoTracking();

            var query = includePaths.Aggregate(dbSet, (current, item) => EvaluateInclude(current, item));

            return Task.FromResult(query);
        }

        private IQueryable<TEntity> EvaluateInclude<TEntity>(IQueryable<TEntity> current, Expression<Func<TEntity, object>> item)
            where TEntity : class
        {
            if (item.Body is MethodCallExpression)
            {
                var arguments = ((MethodCallExpression)item.Body).Arguments;
                if (arguments.Count > 1)
                {
                    var navigationPath = string.Empty;
                    for (var i = 0; i < arguments.Count; i++)
                    {
                        var arg = arguments[i];
                        var path = arg.ToString().Substring(arg.ToString().IndexOf('.') + 1);

                        navigationPath += (i > 0 ? "." : string.Empty) + path;
                    }
                    return current.Include(navigationPath);
                }
            }

            return current.Include(item);
        }
    }
}
