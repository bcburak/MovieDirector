using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieDirectorApp.Domain.Interfaces;
using MovieDirectorApp.Infrastructure.Repositories;

namespace MovieDirectorApp.Application.Configurations
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
        }

    }


}
