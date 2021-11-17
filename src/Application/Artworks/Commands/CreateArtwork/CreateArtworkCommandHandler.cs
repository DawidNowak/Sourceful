using Domain.Contracts;
using Domain.Factories;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Artworks.Commands.CreateArtwork
{
    public class CreateArtworkCommandHandler : IRequestHandler<CreateArtworkCommand, Guid>
    {
        private readonly IArtworkFactory _artworkFactory;
        private readonly IArtworkRepository _artworkRepository;

        public CreateArtworkCommandHandler(
            IArtworkFactory artworkFactory,
            IArtworkRepository artworkRepository)
        {
            _artworkFactory = artworkFactory;
            _artworkRepository = artworkRepository;
        }

        public Task<Guid> Handle(CreateArtworkCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var price = new Money(request.Price, new Currency(request.CurrencyIsoCode));

            var artwork = _artworkFactory.Create(
                id, request.GalleryId, request.Name, price, request.Created, request.Creator);

            _artworkRepository.Save(artwork);

            return Task.FromResult(id);
        }
    }
}
