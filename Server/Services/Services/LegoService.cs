using DataDomain.Data.NoSql.Models;
using Repositories.RepositoriesMongo.Base;
using Services.Services.Base;

namespace Services.Services
{
    public class LegoService : BaseServiceForMongo<LegoModel>
    {
        public LegoService(MongoDbBase<LegoModel> repository) : base(repository)
        {

        }
    }
}
