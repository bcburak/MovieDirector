using MovieDirectorApp.Domain.Entities;

namespace MovieDirectorApp.Domain.Interfaces
{
    interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(string id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(string id);
    }
}
