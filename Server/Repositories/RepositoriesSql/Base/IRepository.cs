using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Base
{
    public interface IRepository<T>
    {
        Task<T> FindUserByEmailAsync(string usersEmail);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T item);
        Task<T> LoginAsync(T item);
        Task LogoutAsync();
        Task<bool> isDataBaseHasUser(T item);
    }
}
