using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieDirectorApp.Application.Interfaces;
using MovieDirectorApp.Domain.Interfaces;
using MovieDirectorApp.Infrastructure.Caching;
using MovieDirectorApp.Infrastructure.Repositories;


namespace MovieDirectorApp.Application.Configurations
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "MovieDirector_";
            });

            services.AddScoped<IRedisCacheService, RedisCacheService>();
        }
    }


}
