using Domain.Entities;
using Domain.ValueObjects;
using System;

namespace Domain.Factories
{
    public interface IArtworkFactory
    {
        Artwork Create(Guid id, Guid galleryId, string name, Money price, DateTime? created, string creator);
    }

    public class ArtworkFactory : IArtworkFactory
    {
        public Artwork Create(Guid id, Guid galleryId, string name, Money price, DateTime? created, string creator)
        {
            return new Artwork(id, galleryId, name, price, created, creator);
        }
    }
}
