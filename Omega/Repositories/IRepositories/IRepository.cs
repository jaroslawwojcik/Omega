using System.Collections.Generic;
using System.Linq;

namespace Omega.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetSingle(long id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}