using Application.Artworks.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Artworks.Queries.GetArtworksByArtGalleryId
{
    public class GetArtworksByArtGalleryIdQuery : IRequest<IEnumerable<ArtworkDto>>
    {
        public Guid ArtGalleryId { get; set; }
    }
}
