using MediatR;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Application.Commands.Handlers
{
    public class DirectorCommandHandler :
        IRequestHandler<CreateDirectorCommand, string>,
        IRequestHandler<DeleteDirectorCommand, bool>
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorCommandHandler(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<string> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = new Director
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                BirthDate = request.BirthDate,
                CreateDate = DateTime.Now
            };
            await _directorRepository.AddAsync(director);
            return director.Id;
        }

        public async Task<bool> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            // Here you would typically check if the director exists before attempting to delete
            await _directorRepository.DeleteAsync(request.Id.ToString());
            return true;
        }
    }
}
