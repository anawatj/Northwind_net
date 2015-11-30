using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Categories
{
    public class Categories : AbstractDomain<long>
    {
        public Categories()
        {

        }
        public virtual string CategoryName { get; set; }
        public virtual string Description { get; set; }
    }
}
