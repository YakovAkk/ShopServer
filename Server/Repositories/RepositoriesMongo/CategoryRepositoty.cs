using DataDomain.Data.NoSql.Models;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;


namespace Repositories.RepositoriesMongo
{
    
    public class CategoryRepositoty : MongoDbBase<CategoryModel>
    {

        protected override IMongoCollection<CategoryModel> Collection { get; set; }
        public override async Task<CategoryModel> AddAsync(CategoryModel item)
        {
            if (item == null)
            {
                var category = new CategoryModel();

                category.messageThatWrong = "Item was null";

                return category;
            }

            var document = new CategoryModel() { Name = item.Name , ImageUrl = item.ImageUrl};

            await Collection.InsertOneAsync(document);

            return item;
        }
        public override async Task<CategoryModel> UpdateAsync(CategoryModel item)
        {

            if (item == null)
            {
                var category = new CategoryModel();

                category.messageThatWrong = "Item was null";

                return category;
            }

            var result = await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<CategoryModel>.
               Update.Set(c => c.Name, item.Name).Set(c => c.ImageUrl, item.ImageUrl));

            if(result == null)
            {
                var category = new CategoryModel();
                category.messageThatWrong = " The element hasn't contained in database";
                return category;
            }

            return item;
        }
    }
}
