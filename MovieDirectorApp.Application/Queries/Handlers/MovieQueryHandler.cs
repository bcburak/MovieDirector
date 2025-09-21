using MediatR;
using MovieDirectorApp.Application.Interfaces;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Application.Queries.Handlers
{
    public class MovieQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _repository;
        private readonly IRedisCacheService _cache;

        public MovieQueryHandler(IMovieRepository repository, IRedisCacheService cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {

            const string cacheKey = "all_movies";

            // Sample using distrşbuted redis cache
            // to use it, you need to set up redis server(local or docjker) and configure it in the appsetitngs.json
            var cachedMovies = await _cache.GetAsync<List<Movie>>(cacheKey);
            if (cachedMovies != null)
            {
                return cachedMovies;
            }


            var movies = await _repository.GetAllAsync();
            await _cache.SetAsync(cacheKey, movies, expirationMinutes: 10);

            return movies;
        }

        public async Task<Movie?> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(query.Id);
        }

    }
}
