using System;

namespace Application.UnitTests
{
    public static class Consts
    {
        public const string Name = nameof(Name);
        public const string Creator = nameof(Creator);
        public const decimal Price = 1000m;
        public const string PLN = nameof(PLN);

        public static Guid GalleryId = Guid.NewGuid();
        public static Guid ArtworkId = Guid.NewGuid();
        public static Guid CustomerId = Guid.NewGuid();
    }
}
