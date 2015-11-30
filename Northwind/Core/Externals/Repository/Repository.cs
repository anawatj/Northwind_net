using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Externals.Repository
{
    public interface Repository<T,K>
    {
        IQueryable<T> AsQueryable();
        List<T> GetAll();
        T GetById(K id);

        T Save(T entity);

        void Remove(K id);
    }
}
