using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
