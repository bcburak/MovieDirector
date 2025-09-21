using MongoDB.Driver;
using MovieDirectorApp.Domain.Entities;

namespace MovieDirectorApp.Infrastructure.Context
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _mongoClient;

        public ApplicationDbContext(string connectionString, string dbName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(dbName);
        }

        public IMongoCollection<Movie> Movies => _database.GetCollection<Movie>("Movies");
        public IMongoCollection<Director> Directors => _database.GetCollection<Director>("Directors");

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
