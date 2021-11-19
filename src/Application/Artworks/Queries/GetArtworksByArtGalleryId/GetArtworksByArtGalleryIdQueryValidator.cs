using FluentValidation;

namespace Application.Artworks.Queries.GetArtworksByArtGalleryId
{
    public class GetArtworksByArtGalleryIdQueryValidator : AbstractValidator<GetArtworksByArtGalleryIdQuery>
    {
        public GetArtworksByArtGalleryIdQueryValidator()
        {
            RuleFor(x => x.ArtGalleryId).NotEmpty();
        }
    }
}
