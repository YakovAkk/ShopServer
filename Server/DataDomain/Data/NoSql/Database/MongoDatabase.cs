using DataDomain.Data.NoSql.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Data.NoSql.Database
{
    public class MongoDatabase
    {

        private IGridFSBucket _gridFS;
        private IMongoDatabase _db;
        public IMongoCollection<CategoryModel> Categories; // коллекция в базе данных
        public MongoDatabase()
        {
            string _connectionString = "mongodb://localhost:27017/Lego";
            MongoUrlBuilder _connection = new MongoUrlBuilder(_connectionString);
            MongoClient _client = new MongoClient(_connectionString);
            _db = _client.GetDatabase(_connection.DatabaseName);

            Categories = _db.GetCollection<CategoryModel>("Categories");
        }

        public IMongoDatabase GetConnectionToDB()
        {
            return _db;
        }

        public async Task<List<CategoryModel>> GetALL()
        {
            return await Categories.Find(_ => true).ToListAsync();
        }
        //public async Task<CategoryModel> GetCategory(string id)
        //{
        //    return await Categories.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        //}

        //public async Task Add(string name)
        //{
        //    var document = new CategoryModel() { Name = name };

        //    await Categories.InsertOneAsync(document);
        //}
        //public async Task Delete(string Id)
        //{
        //    await Categories.DeleteOneAsync(i => i.Id == Id);
        //}
        //public async Task UpdateItem(string Id, string updateName)
        //{
        //    await Categories.UpdateOneAsync(i => i.Id == Id, Builders<CategoryModel>.
        //        Update.Set(c => c.Name, updateName));
        //}

    }
}
