using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Master
{
    public class DemoGraphics : SimpleMasterObject
    {
        public DemoGraphics()
        {
            this.Customers = new List<Customers.Customers>();
        }
        public virtual ICollection<Customers.Customers> Customers { get; set; }
    }
}
