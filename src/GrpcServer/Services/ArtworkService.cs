using Application.Artworks.Commands.CreateArtwork;
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
    }
}
