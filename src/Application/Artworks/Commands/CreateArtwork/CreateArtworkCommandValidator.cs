using FluentValidation;
using System;

namespace Application.Artworks.Commands.CreateArtwork
{
    public class CreateArtworkCommandValidator : AbstractValidator<CreateArtworkCommand>
    {
        public CreateArtworkCommandValidator()
        {
            RuleFor(a => a.GalleryId).NotEmpty();
            RuleFor(a => a.Name).MinimumLength(3);
            RuleFor(a => a.Price).NotEmpty();
            RuleFor(a => a.CurrencyIsoCode).NotEmpty();

            RuleFor(a => a.Created)
                .LessThan(DateTime.Now)
                .When(a => a.Created != null);
        }
    }
}
