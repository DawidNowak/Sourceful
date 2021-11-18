using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ArtworkRepository : EfRepository<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task SaveAsync(Artwork artwork)
        {
            DbContext.Add(artwork);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
