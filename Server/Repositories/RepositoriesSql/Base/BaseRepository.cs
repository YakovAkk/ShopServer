
using DataDomain.Data.Sql.Database;
using DataDomain.Data.Sql.Models;

namespace Repositories.Repositories.Base
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly AppDBContent _db;
        public BaseRepository(AppDBContent appDBContent)
        {
            _db = appDBContent;
        }

        public abstract Task<T> CreateAsync(T item);
        public abstract Task<T> FindUserByEmailAsync(string usersEmail);
        public abstract Task<List<T>> GetAllAsync();
        public abstract Task<bool> isDataBaseHasUser(T item);
        public abstract Task<T> LoginAsync(T item);
        public abstract Task LogoutAsync();

    }
}
