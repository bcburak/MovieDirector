using MediatR;
using MovieDirectorApp.Domain.Entities;

namespace MovieDirectorApp.Application.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {
    }
}
