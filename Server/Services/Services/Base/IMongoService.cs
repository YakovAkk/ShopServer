using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Base
{
    public interface IMongoService<T>
    {
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task Delete(string id);
        Task<T> GetByID(string id);
        Task<List<T>> GetAll();
    }
}
