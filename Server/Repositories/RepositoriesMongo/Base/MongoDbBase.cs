using DataDomain.Attributes;
using DataDomain.Data.NoSql.Database;
using DataDomain.Data.NoSql.Models.Base;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Repositories.RepositoriesMongo.Base
{
    public abstract class MongoDbBase<T> : IMongoDB<T> where T : IModel
    {
        private readonly IMongoDatabase _db;
        abstract protected IMongoCollection<T> Collection { get; set; }
        public MongoDbBase()
        {
            _db = new MongoDatabase().GetConnectionToDB();
            Collection = _db.GetCollection<T>(GetNameAtributes() == "" ? typeof(T).Name : GetNameAtributes());
        }
        public string GetNameAtributes()
        {
            var type = typeof(T);

            var atributes = type.GetCustomAttributes(typeof(NameCollectionAttribute), false);

            foreach (NameCollectionAttribute atribute in atributes)
            {
                return atribute.CollectionName;
            }
            return "";
        }
        public abstract Task<T> Add(T item);
        public async virtual Task Delete(string id)
        {
            await Collection.DeleteOneAsync(i => i.Id == id);
        }
        public async virtual Task<List<T>> GetAll()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
        public async virtual Task<T> GetByID(string id)
        {
            return await Collection.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        public abstract Task<T> Update(T item);
    }
}
