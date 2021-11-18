using Domain.Entities;
using Domain.Factories;
using Domain.ValueObjects;
using System;

namespace Infrastructure.Factories
{
    public class ArtworkFactory : IArtworkFactory
    {
        public Artwork Create(Guid id, Guid galleryId, string name, Money price, int? created, string creator)
        {
            return new Artwork(id, galleryId, name, price, created, creator);
        }
    }
}
