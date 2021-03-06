using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataDomain.Data.NoSql.Database
{
    public class MongoDatabase
    {
        private IMongoDatabase _db;
        public MongoDatabase()
        {
            string _connectionString = "mongodb://localhost:27017/Lego";
            MongoUrlBuilder _connection = new MongoUrlBuilder(_connectionString);
            MongoClient _client = new MongoClient(_connectionString);
            _db = _client.GetDatabase(_connection.DatabaseName);
        }

        public IMongoDatabase GetConnectionToDB()
        {
            return _db;
        }
    }
}
