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
            if (item == null)
            {
                var lego = new LegoModel();
                lego.messageThatWrong = "Item was null";
                return lego;
            }

            await Collection.InsertOneAsync(item);

            return item;
        }
        public async override Task<LegoModel> UpdateAsync(LegoModel item)
        {
            if (item == null)
            {
                var lego = new LegoModel();
                lego.messageThatWrong = "Item was null";
                return lego;
            }

            var result = await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<LegoModel>.
                Update.Set(c => c.Name, item.Name).Set(c => c.Description, item.Description).
                Set(c=> c.ImageUrl, item.ImageUrl).Set(c => c.Category, item.Category).
                Set(c => c.Price , item.Price).Set(c => c.isFavorite, item.isFavorite));

            if(result == null)
            {
                var lego = new LegoModel();
                lego.messageThatWrong = "Database can't update the element";
                return lego;
            }

            return item;
        }
    }
}
