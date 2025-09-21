using MediatR;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Application.Queries.Handlers
{
    public class MovieQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _repository;

        public MovieQueryHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Movie?> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(query.Id);
        }

    }
}
