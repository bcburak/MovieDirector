using MongoDB.Driver;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Infrastructure.Repositories
{

    public class DirectorRepository : IDirectorRepository
    {
        private readonly IMongoCollection<Director> _director;

        public DirectorRepository(IMongoDatabase database)
        {
            _director = database.GetCollection<Director>("Director");
        }
        public async Task AddAsync(Director movie) =>
           await _director.InsertOneAsync(movie);


        public async Task DeleteAsync(string id) =>
            await _director.DeleteOneAsync(m => m.Id == id);
    }
}
