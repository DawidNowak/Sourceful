using Domain.Contracts;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class ArtGalleryRepository : EfRepository<ArtGallery>, IArtGalleryRepository
    {
        public ArtGalleryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
