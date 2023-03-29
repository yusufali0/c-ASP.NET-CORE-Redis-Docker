using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using IDatabase = StackExchange.Redis.IDatabase;

namespace YAB.App.Api.Redis
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string url)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
        }

        public IDatabase GetDb(int db)
        {
            return _connectionMultiplexer.GetDatabase(db);
        }
    }
}
