using DataDomain.Data.NoSql.Database;
using DataDomain.Data.NoSql.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;


namespace Repositories.RepositoriesMongo
{
    
    public class CategoryRepositoty : MongoDbBase<CategoryModel>
    {

        protected override IMongoCollection<CategoryModel> Collection { get; set; }
        public override async Task<CategoryModel> AddAsync(CategoryModel item)
        {
            var document = new CategoryModel() { Name = item.Name , ImageUrl = item.ImageUrl};

            await Collection.InsertOneAsync(document);

            return item;
        }
        public override async Task<CategoryModel> UpdateAsync(CategoryModel item)
        {
            await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<CategoryModel>.
               Update.Set(c => c.Name, item.Name).Set(c => c.ImageUrl, item.ImageUrl));

            return item;
        }
    }
}
