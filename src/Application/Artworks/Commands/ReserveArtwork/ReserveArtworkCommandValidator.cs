using FluentValidation;

namespace Application.Artworks.Commands.ReserveArtwork
{
    public class ReserveArtworkCommandValidator : AbstractValidator<ReserveArtworkCommand>
    {
        public ReserveArtworkCommandValidator()
        {
            RuleFor(x => x.ArtworkId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
