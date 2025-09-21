using MediatR;

namespace MovieDirectorApp.Application.Commands
{
    public record DeleteDirectorCommand(Guid Id) : IRequest<bool>;
}
