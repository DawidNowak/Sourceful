using MediatR;
using System;

namespace Application.Artworks.Commands.CreateArtwork
{
    public class CreateArtworkCommand : IRequest<Guid>
    {
        public Guid GalleryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CurrencyIsoCode { get; set; }
        public DateTime? Created { get; set; }
        public string Creator { get; set; }
    }
}
