using MediatR;
using MovieDirectorApp.Application.Interfaces;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Application.Commands.Handlers
{
    public class MovieCommandHandler :
             IRequestHandler<CreateMovieCommand, string>,
        IRequestHandler<UpdateMovieCommand, bool>,
        IRequestHandler<DeleteMovieCommand, bool>

    {

        private readonly IMovieRepository _repository;
        private readonly IRedisCacheService _cache;

        public MovieCommandHandler(IMovieRepository repository, IRedisCacheService cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<string> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Title = command.Title,
                Year = command.Year,
                ImdbId = command.ImdbId
            };
            await _repository.AddAsync(movie);
            return movie.Id;
        }

        public async Task<bool> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Id = command.Id,
                Title = command.Title,
                Year = command.Year
                // Other properties can be updated similarly
            };

            await _repository.UpdateAsync(movie);
            return true;
        }

        public async Task<bool> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(command.Id);
            await _cache.RemoveAsync("all_movies"); // Cache invalidation sample
            //still need transaction handling for real world app
            return true;
        }

    }
}
