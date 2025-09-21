using MongoDB.Driver;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieRepository(IMongoDatabase database)
        {
            _movies = database.GetCollection<Movie>("Movies");
        }

        public async Task<IEnumerable<Movie>> GetAllAsync() =>
            await _movies.Find(_ => true).ToListAsync();

        public async Task<Movie?> GetByIdAsync(string id) =>
            await _movies.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task AddAsync(Movie movie) =>
            await _movies.InsertOneAsync(movie);

        public async Task UpdateAsync(Movie movie) =>
            await _movies.ReplaceOneAsync(m => m.Id == movie.Id, movie);

        public async Task DeleteAsync(string id) =>
            await _movies.DeleteOneAsync(m => m.Id == id);

    }
}
