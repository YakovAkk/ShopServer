using DataDomain.Data.NoSql.Models;
using DataDomain.Data.Sql.Models;
using Repositories.RepositoriesMongo.Base;
using Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BasketService : BaseServiceForMongo<BasketModel>
    {
        public BasketService(MongoDbBase<BasketModel> repository) : base(repository)
        {

        }
    }
}
