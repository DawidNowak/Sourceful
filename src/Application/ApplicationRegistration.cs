using Application.Artworks.Queries.Common;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new ArtworkProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
