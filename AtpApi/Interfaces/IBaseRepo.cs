using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtpApi.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<int> Create(T t);
        Task<int> Delete(int id);
        Task<int> Update(int oldid, T t2);
    }
}
