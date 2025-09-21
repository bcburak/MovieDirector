using StackExchange.Redis;

namespace MovieDirectorApp.Infrastructure.Caching
{
    public class RedisCacheService
    {
        private readonly IDatabase _db;

        public RedisCacheService(string connectionString)
        {
            var redis = ConnectionMultiplexer.Connect(connectionString);
            _db = redis.GetDatabase();
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
            => await _db.StringSetAsync(key, value, expiry);

        public async Task<string?> GetAsync(string key)
            => await _db.StringGetAsync(key);
    }
}
