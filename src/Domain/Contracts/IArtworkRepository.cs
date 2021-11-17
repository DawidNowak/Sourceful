using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IArtworkRepository
    {
        Task<Artwork> GetAsync(Guid id);
        void Save(Artwork artwork);
    }
}
