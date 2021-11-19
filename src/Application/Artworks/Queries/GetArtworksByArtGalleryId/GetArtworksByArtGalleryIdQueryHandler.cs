using Application.Artworks.Queries.Common;
using Application.Contracts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Artworks.Queries.GetArtworksByArtGalleryId
{
    public class GetArtworksByArtGalleryIdQueryHandler : IRequestHandler<GetArtworksByArtGalleryIdQuery, IEnumerable<ArtworkDto>>
    {
        private readonly IReadModelContext _readModel;
        private readonly IMapper _mapper;

        public GetArtworksByArtGalleryIdQueryHandler(IReadModelContext readModel, IMapper mapper)
        {
            _readModel = readModel;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtworkDto>> Handle(GetArtworksByArtGalleryIdQuery request, CancellationToken cancellationToken)
        {
            var artworks = (await _readModel.GetQueryAsync<Artwork>())
                .Where(a => a.ArtGalleryId == request.ArtGalleryId)
                .ToList();

            return _mapper.Map<IEnumerable<ArtworkDto>>(artworks);
        }
    }
}
