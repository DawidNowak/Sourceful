using System;

namespace Domain.Entities
{
    /// <summary>
    /// Simmilarly to Customer, ArtGallery will probably have it's own bounded context.
    /// Here we need only ID and Name
    /// </summary>
    public class ArtGallery
    {
        public Guid Id { get; }
        public string Name { get; }

        public ArtGallery(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
