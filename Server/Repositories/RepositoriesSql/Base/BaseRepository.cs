
using DataDomain.Data.Sql.Database;

namespace Repositories.Repositories.Base
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly AppDBContent _db;
        public BaseRepository(AppDBContent appDBContent)
        {
            _db = appDBContent;
        }

        public abstract Task<T> Create(T item);

        public abstract Task<List<T>> GetAll();

        public abstract Task<T> Login(T item);

        public abstract Task Logout();
    }
}
