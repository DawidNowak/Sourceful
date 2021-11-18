using Domain.Common;
using System;

namespace Domain.Entities
{
    /// <summary>
    /// Simmilarly to Customer, ArtGallery will probably have it's own bounded context.
    /// Here we need only ID and Name
    /// </summary>
    public class ArtGallery : Entity
    {
        public string Name { get; private set; }

        public ArtGallery(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
