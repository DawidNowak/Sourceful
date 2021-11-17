using Domain.Entities;
using System;

namespace Domain.Contracts
{
    public interface IArtGalleryRepository
    {
        ArtGallery Get(Guid id);
    }
}
