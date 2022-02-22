using DataDomain.Data.NoSql.Models;
using Repositories.RepositoriesMongo.Base;
using Services.Services.Base;


namespace Services.Services
{
    public class BasketService : BaseServiceForMongo<BasketModel>
    {
        public BasketService(MongoDbBase<BasketModel> repository) : base(repository)
        {

        }
    }
}
