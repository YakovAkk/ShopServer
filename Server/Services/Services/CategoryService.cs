using DataDomain.Data.NoSql.Models;
using Repositories.RepositoriesMongo.Base;
using Services.Services.Base;

namespace Services.Services
{
    public class CategoryService : BaseServiceForMongo<CategoryModel>
    {
        public CategoryService(MongoDbBase<CategoryModel> repository) : base(repository)
        {

        }
    }
}
