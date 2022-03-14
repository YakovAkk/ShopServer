
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

        public abstract Task<T> Create(T item);

        public abstract Task<T> FindUserByEmail(string usersEmail);

        public abstract Task<List<T>> GetAll();

        public abstract Task<T> Login(T item);

        public abstract Task Logout();

    }
}
