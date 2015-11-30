using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains.Employees;

namespace Infrastructor.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public IQueryable<Employees> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employees GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Employees Save(Employees entity)
        {
            throw new NotImplementedException();
        }
    }
}
