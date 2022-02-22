using DataDomain.Data.NoSql.Models.Base;
using Repositories.RepositoriesMongo.Base;


namespace Services.Services.Base
{
    public abstract class BaseServiceForMongo<T> : IMongoService<T> where T : IModel  
    {
        private readonly MongoDbBase<T> _repository;
        public async Task<T> Add(T item)
        {
           return await _repository.Add(item);
        }
        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }
        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<T> GetByID(string id)
        {
            return await _repository.GetByID(id);
        }
        public async Task<T> Update(T item)
        {
            return await _repository.Update(item);
        }
        public BaseServiceForMongo(MongoDbBase<T> repository)
        {
            _repository = repository;
        }
    }
}
