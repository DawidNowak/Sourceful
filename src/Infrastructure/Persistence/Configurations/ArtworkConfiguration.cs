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
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(a => a.BoughtByCustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.OwnsOne(a => a.Price, price =>
            {
                price.Property(p => p.Amount)
                    .HasColumnName(nameof(Money.Amount))
                    .IsRequired();

                price.Property(p => p.Currency)
                    .HasColumnName(nameof(Money.Currency))
                    .IsRequired();
            });
        }
    }
}
