using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
    {
        public void Configure(EntityTypeBuilder<Artwork> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired();

            builder.HasOne<ArtGallery>()
                .WithMany()
                .HasForeignKey(a => a.ArtGalleryId);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(a => a.ReservationCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(a => a.BoughtByCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.OwnsOne(a => a.Price, price =>
            {
                price.Property(m => m.Amount)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName(nameof(Money.Amount))
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                price.OwnsOne(m => m.Currency, money =>
                {
                    money.Property(c => c.IsoCode)
                        .UsePropertyAccessMode(PropertyAccessMode.Field)
                        .HasColumnName(nameof(Money.Currency))
                        .IsRequired();
                });
            });
        }
    }
}
