using DataDomain.Data.NoSql.Models;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;

namespace Repositories.RepositoriesMongo
{
    public class LegoRepository : MongoDbBase<LegoModel>
    {
        protected override IMongoCollection<LegoModel> Collection { get ; set ; }
        public async override Task<LegoModel> AddAsync(LegoModel item)
        {
            var document = new LegoModel() { 
                Name = item.Name, 
                Category = item.Category, 
                ImageUrl = item.ImageUrl , 
                Price = item.Price, 
                Description = item.Description,
                isFavorite = item.isFavorite};

            await Collection.InsertOneAsync(document);

            return item;
        }
        public async override Task<LegoModel> UpdateAsync(LegoModel item)
        {
            await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<LegoModel>.
                Update.Set(c => c.Name, item.Name).Set(c => c.Description, item.Description).
                Set(c=> c.ImageUrl, item.ImageUrl).Set(c => c.Category, item.Category).
                Set(c => c.Price , item.Price).Set(c => c.isFavorite, item.isFavorite));

            return item;
        }
    }
}
