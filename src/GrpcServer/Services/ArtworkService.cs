using Application.Artworks.Commands.CreateArtwork;
using Application.Artworks.Queries.GetArtworksByArtGalleryId;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class ArtworkService : Artwork.ArtworkBase
    {
        private readonly ILogger<ArtworkService> _logger;
        private readonly IMediator _mediator;

        public ArtworkService(ILogger<ArtworkService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task<CreateArtworkResponse> CreateArtwork(CreateArtworkRequestModel request, ServerCallContext context)
        {
            var command = new CreateArtworkCommand
            {
                GalleryId = new Guid(request.GalleryId),
                Name = request.Name,
                Price = Convert.ToDecimal(request.Price),
                CurrencyIsoCode = request.CurrencyIsoCode,
                Created = request.Created,
                Creator = request.Creator
            };

            var result = await _mediator.Send(command);

            var response = new CreateArtworkResponse
            {
                Id = result.ToString()
            };

            return response;
        }

        public override async Task GetArtworksByArtGalleryId(GetArtworksByArtGalleryIdModel request,
            IServerStreamWriter<ArtworkResponse> responseStream,
            ServerCallContext context)
        {
            _logger.LogInformation($"{nameof(GetArtworksByArtGalleryId)}: ({request.GalleryId})");

            var query = new GetArtworksByArtGalleryIdQuery
            {
                ArtGalleryId = new Guid(request.GalleryId)
            };

            var artworks = await _mediator.Send(query);

            foreach (var artwork in artworks)
            {
                var current = new ArtworkResponse
                {
                    Name = artwork.Name,
                    Price = artwork.Price,
                    Creator = artwork.Creator,
                    Created = artwork.Created,
                    IsReserved = artwork.IsReserved,
                    IsSold = artwork.IsSold
                };

                await responseStream.WriteAsync(current);
            }
        }
    }
}
