using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IArtworkRepository : IRepository<Artwork>
    {
        Task SaveAsync(Artwork artwork);
    }
}
