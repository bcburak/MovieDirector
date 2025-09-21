using MediatR;
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

        public MovieCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
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
            return true;
        }

    }
}
