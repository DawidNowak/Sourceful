using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Simmilarly to Customer, ArtGallery will probably have it's own bounded context.
    /// Here we need only ID and Name
    /// </summary>
    public class ArtGallery : Entity
    {
        private List<Artwork> _artworks = new();

        public string Name { get; }
        public IReadOnlyCollection<Artwork> Artworks => _artworks;

        public ArtGallery(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
