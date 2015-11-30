using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Externals
{
    public interface IUnitOfWork
    {
         Repository.ICategoriesRepository CategoryRepository { get; }
        Repository.ICustomersRepository CustomerRepository { get; }

    }
}
