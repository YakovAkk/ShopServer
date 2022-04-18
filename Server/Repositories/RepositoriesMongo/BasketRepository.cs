using DataDomain.Data.NoSql.Models;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;


namespace Repositories.RepositoriesMongo
{
    public class BasketRepository : MongoDbBase<BasketModel>
    {
        protected override IMongoCollection<BasketModel> Collection { get; set; }
        public override async Task<BasketModel> AddAsync(BasketModel item)
        {
            var Lego = await GetAllAsync();
            var updateLego = Lego.FirstOrDefault(i => (i.Lego.Name == item.Lego.Name) && (i.User.Name == item.User.Name));
            if (updateLego == null)
            {
                var document = new BasketModel(item.Lego, item.Amount, item.User);

                await Collection.InsertOneAsync(document);

                return item;
            }
            return null;
           
        }
        public override async Task<BasketModel> UpdateAsync(BasketModel item)
        {
            var Lego = await GetAllAsync();
            var updateLego = Lego.FirstOrDefault(i => (i.Lego.Name == item.Lego.Name) && (i.User.Name == item.User.Name));

            await Collection.UpdateOneAsync(i => i.Id == updateLego.Id, Builders<BasketModel>.
               Update.Set(c => c.Amount, item.Amount).Set(c => c.Lego, item.Lego).
               Set(c => c.DateDeal, DateTime.Now).Set(c => c.User, item.User));

            return item;
        }
    }
}
