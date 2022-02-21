using DataDomain.Data.NoSql.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;


namespace Repositories.RepositoriesMongo
{
    
    public class CategoryRepositoty : MongoDbBase<CategoryModel>
    {
        protected override IMongoCollection<CategoryModel> Collection { get; set; }
        public async override Task<CategoryModel> Add(CategoryModel item)
        {
            var document = new CategoryModel() { Name = item.Name };

            await Collection.InsertOneAsync(document);

            return item;
        }
        public async override Task Delete(string id)
        {
            await Collection.DeleteOneAsync(i => i.Id == id);
        }
        public async override Task<CategoryModel> Update(CategoryModel item)
        {
            await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<CategoryModel>.
               Update.Set(c => c.Name, item.Name));

            return item;
        }
    }
}
