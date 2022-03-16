using DataDomain.Data.NoSql.Database;
using DataDomain.Data.NoSql.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoriesMongo
{
    public class BasketRepository : MongoDbBase<BasketModel>
    {
        protected override IMongoCollection<BasketModel> Collection { get; set; }
        public override async Task<BasketModel> AddAsync(BasketModel item)
        {
            var document = new BasketModel(item.Lego, item.Amount, item.User);

            await Collection.InsertOneAsync(document);

            return item;
        }
        public override async Task<BasketModel> UpdateAsync(BasketModel item)
        {
            await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<BasketModel>.
               Update.Set(c => c.Amount, item.Amount).Set(c => c.Lego,item.Lego).
               Set(c => c.DateDeal, DateTime.Now).Set(c => c.User, item.User));

            return item;
        }
    }
}
