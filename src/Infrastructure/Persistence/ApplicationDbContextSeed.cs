using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (context.Artworks.Any())
            {
                return;
            }

            context.Customers.AddRange(new[] {
                new Customer(Guid.NewGuid(), true),
                new Customer(Guid.NewGuid(), true),
                new Customer(Guid.NewGuid(), false)
            });

            var amfilada = new ArtGallery(Guid.NewGuid(), "Amfilada");
            var esta = new ArtGallery(Guid.NewGuid(), "Esta");

            context.ArtGalleries.AddRange(new[]
            {
                amfilada,
                esta
            });

            context.Artworks.AddRange(new[]
            {
                new Artwork(Guid.NewGuid(), amfilada.Id, "Untitled", new Money(110500000, new Currency("USD")), 2017, "Jean-Michel Basquiat"),
                new Artwork(Guid.NewGuid(), amfilada.Id, "The Scream", new Money(119900000, new Currency("USD")), 1895, "Edvard Munch"),
                new Artwork(Guid.NewGuid(), amfilada.Id, "Madonna and Child", new Money(45000000, new Currency("USD")), 1300, "Duccio"),
                new Artwork(Guid.NewGuid(), amfilada.Id, "Le Bassin aux nymphéas", new Money(70350000, new Currency("USD")), 2017, "Claude Monet"),

                new Artwork(Guid.NewGuid(), esta.Id, "Artemis and the Stag", new Money(28600000, new Currency("EUR")), 100, "Unknown"),
                new Artwork(Guid.NewGuid(), esta.Id, "Rabbit", new Money(380000000, new Currency("PLN")), 1986, "Jeff Koons"),
                new Artwork(Guid.NewGuid(), esta.Id, "Spider", new Money(32100000, new Currency("USD")), 1995, "Louise Bourgeois"),
                new Artwork(Guid.NewGuid(), esta.Id, "Reclining Figure: Festival", new Money(30100000, new Currency("USD")), 1951, "Henry Moore")
            });

            await context.SaveChangesAsync();
        }
    }
}
