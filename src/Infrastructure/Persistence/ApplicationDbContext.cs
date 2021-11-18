using Application.Contracts;
using Domain.Common;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IDomainEventPublisher _domainEventPublisher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDomainEventPublisher domainEventPublisher)
            : base(options)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ArtGallery> ArtGalleries { get; set; }

        public async Task SaveChangesAsync()
        {
            var events = ChangeTracker.Entries<IHasDomainEvent>()
                .SelectMany(x => x.Entity.GetUnpublishedEvents());

            await base.SaveChangesAsync();

            await DispatchEvents(events);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private async Task DispatchEvents(IEnumerable<DomainEvent> events)
        {
            foreach (var @event in events)
            {
                await _domainEventPublisher.Publish(@event);
            }
        }
    }
}
