using Application.Exceptions;
using Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Artworks.Commands.ReserveArtwork
{
    public class ReserveArtworkCommandHandler : IRequestHandler<ReserveArtworkCommand>
    {
        private readonly IArtworkRepository _artworkRepo;
        private readonly ICustomerRepository _customerRepo;

        public ReserveArtworkCommandHandler(IArtworkRepository artworkRepo, ICustomerRepository customerRepo)
        {
            _artworkRepo = artworkRepo;
            _customerRepo = customerRepo;
        }

        public async Task<Unit> Handle(ReserveArtworkCommand request, CancellationToken cancellationToken)
        {
            var artwork = await _artworkRepo.GetAsync(request.ArtworkId);
            if (artwork is null)
            {
                throw new ArtworkNotFoundException(request.ArtworkId);
            }

            artwork.Reserve(request.CustomerId, _customerRepo);

            return Unit.Value;
        }
    }
}
