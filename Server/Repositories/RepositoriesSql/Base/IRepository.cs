using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Base
{
    public interface IRepository<T>
    {
        Task<T> FindUserByEmail(string usersEmail);
        Task<List<T>> GetAll();
        Task<T> Create(T item);
        Task<T> Login(T item);
        Task Logout();
    }
}
