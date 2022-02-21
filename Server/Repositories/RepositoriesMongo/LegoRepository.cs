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
    public class LegoRepository : MongoDbBase<LegoModel>
    {
        protected override IMongoCollection<LegoModel> Collection { get ; set ; }

        public async override Task<LegoModel> Add(LegoModel item)
        {
            var document = new LegoModel() { Name = item.Name , Category = item.Category, ImageUrl = item.ImageUrl };

            await Collection.InsertOneAsync(document);

            return item;
        }
        public async override Task Delete(string id)
        {
            await Collection.DeleteOneAsync(i => i.Id == id);
        }
        public async override Task<LegoModel> Update(LegoModel item)
        {
            await Collection.UpdateOneAsync(i => i.Id == item.Id, Builders<LegoModel>.
                Update.Set(c => c.Name, item.Name));

            return item;
        }
    }
}
