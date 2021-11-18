using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ArtGalleryConfiguration : IEntityTypeConfiguration<ArtGallery>
    {
        public void Configure(EntityTypeBuilder<ArtGallery> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .IsRequired();
        }
    }
}
