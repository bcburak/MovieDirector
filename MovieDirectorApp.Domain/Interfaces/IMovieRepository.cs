using MovieDirectorApp.Domain.Entities;

namespace MovieDirectorApp.Domain.Interfaces
{
    public interface IMovieRepository //IGenericRepository<Movie>
    {

        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(string id);
        Task AddAsync(Movie entity);
        Task UpdateAsync(Movie entity);
        Task DeleteAsync(string id);
    }
}
