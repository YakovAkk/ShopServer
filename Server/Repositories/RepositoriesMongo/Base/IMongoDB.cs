

namespace Repositories.RepositoriesMongo.Base
{
    public interface IMongoDB<T> 
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(string id);
        Task<T> Add(T item);
        Task Delete(string id);
        Task<T> Update(T item);

    }
}
