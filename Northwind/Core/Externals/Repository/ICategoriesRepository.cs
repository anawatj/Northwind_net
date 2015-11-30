using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Externals.Repository
{
    public interface ICategoriesRepository : Repository<Core.Domains.Categories.Categories,long>
    {
    }
}
