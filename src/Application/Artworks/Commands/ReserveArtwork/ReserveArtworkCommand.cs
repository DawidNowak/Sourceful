using MediatR;
using System;

namespace Application.Artworks.Commands.ReserveArtwork
{
    public class ReserveArtworkCommand : IRequest
    {
        public Guid ArtworkId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
