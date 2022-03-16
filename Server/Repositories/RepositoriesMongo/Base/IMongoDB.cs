

namespace Repositories.RepositoriesMongo.Base
{
    public interface IMongoDB<T> 
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIDAsync(string id);
        Task<T> AddAsync(T item);
        Task DeleteAsync(string id);
        Task<T> UpdateAsync(T item);

    }
}
