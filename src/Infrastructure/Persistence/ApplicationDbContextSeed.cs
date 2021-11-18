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
                new Customer(new Guid("9A562C3B-3229-451D-A6D2-FB08EE00AE3E"), true),
                new Customer(new Guid("E1010A48-678D-4BF6-A046-4344CD40CB1D"), true),
                new Customer(new Guid("F70EF082-68B4-4EFE-8DFD-225C1C7EB470"), false)
            });

            var amfilada = new ArtGallery(new Guid("5E9ABDB5-E4B8-4880-9BAF-7089D75DB294"), "Amfilada");
            var esta = new ArtGallery(new Guid("FC1A9651-019A-4199-A433-B328574D8145"), "Esta");

            context.ArtGalleries.AddRange(new[]
            {
                amfilada,
                esta
            });

            context.Artworks.AddRange(new[]
            {
                new Artwork(new Guid("87D44829-E29C-44AE-A499-A72B65C588A1"), amfilada.Id, "Untitled", new Money(110500000, new Currency("USD")), 2017, "Jean-Michel Basquiat"),
                new Artwork(new Guid("1905DFA9-C241-45EB-BA4C-C7386DCAA4F2"), amfilada.Id, "The Scream", new Money(119900000, new Currency("USD")), 1895, "Edvard Munch"),
                new Artwork(new Guid("89C51235-0276-4655-BE3D-AE3362EA8C03"), amfilada.Id, "Madonna and Child", new Money(45000000, new Currency("USD")), 1300, "Duccio"),
                new Artwork(new Guid("A38DDB66-96A9-439E-AF15-6CFF0CF8D8F2"), amfilada.Id, "Le Bassin aux nymphéas", new Money(70350000, new Currency("USD")), 2017, "Claude Monet"),

                new Artwork(new Guid("84668C96-47C9-4EEC-A2D5-A19523840FB5"), esta.Id, "Artemis and the Stag", new Money(28600000, new Currency("EUR")), 100, "Unknown"),
                new Artwork(new Guid("EF462D4A-715A-4592-BB71-D7A1B977C419"), esta.Id, "Rabbit", new Money(380000000, new Currency("PLN")), 1986, "Jeff Koons"),
                new Artwork(new Guid("8A38B9BD-C3E5-47E5-ADDC-83DFF0139F2B"), esta.Id, "Spider", new Money(32100000, new Currency("USD")), 1995, "Louise Bourgeois"),
                new Artwork(new Guid("0473D5B9-EA31-419F-91B6-2D04D653A7BC"), esta.Id, "Reclining Figure: Festival", new Money(30100000, new Currency("USD")), 1951, "Henry Moore")
            });

            await context.SaveChangesAsync();
        }
    }
}
