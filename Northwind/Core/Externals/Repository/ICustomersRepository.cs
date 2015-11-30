using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Externals.Repository
{
    public interface ICustomersRepository : Repository<Core.Domains.Customers.Customers,long>
    {
    }
}
