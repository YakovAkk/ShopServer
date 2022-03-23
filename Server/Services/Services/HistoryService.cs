using DataDomain.Data.NoSql.Models;
using Repositories.RepositoriesMongo.Base;
using Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class HistoryService : BaseServiceForMongo<UserHistoryModel>
    {
        public HistoryService(MongoDbBase<UserHistoryModel> repository) : base(repository)
        {

        }
    }
}
