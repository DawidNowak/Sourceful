using Application.Contracts;
using Domain.Contracts;
using Domain.Factories;
using Infrastructure.Factories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("SqlConnectionString"),
                    opts => opts.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IReadModelContext, ApplicationDbContextReadModelAdapter>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();

            services.AddSingleton<IArtworkFactory, ArtworkFactory>();

            services.AddScoped<IArtworkRepository, ArtworkRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IArtGalleryRepository, ArtGalleryRepository>();

            return services;
        }
    }
}
