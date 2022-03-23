using DataDomain.Data.NoSql.Models;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoriesMongo
{
    public class HistoryRepository : MongoDbBase<UserHistoryModel>
    {
        protected override IMongoCollection<UserHistoryModel> Collection { get; set; }

        public override async Task<UserHistoryModel> AddAsync(UserHistoryModel item)
        {
            var historyOfUser = (await GetAllAsync()).FirstOrDefault(i => i.User.Email == item.User.Email);

            if (historyOfUser == null)
            {
                await Collection.InsertOneAsync(item);
                return item;
            }
            return await UpdateAsync(item);
        }

        public override async Task<UserHistoryModel> UpdateAsync(UserHistoryModel item)
        {
            var Orders = (await GetAllAsync()).FirstOrDefault(i => i.User.Email == item.User.Email).Orders.ToList();
            Orders.AddRange(item.Orders);
            await Collection.UpdateOneAsync(i => i.User.Email == item.User.Email, Builders<UserHistoryModel>.
                Update.Set(c => c.Orders, Orders));
            return item;
        }
    }
}
