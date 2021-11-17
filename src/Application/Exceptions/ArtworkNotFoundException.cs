using System;

namespace Application.Exceptions
{
    public sealed class ArtworkNotFoundException : ApplicationException
    {
        public ArtworkNotFoundException(Guid id) : base($"Artwork ({id}) was not found.")
        {
        }
    }
}
