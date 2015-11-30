using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Master
{
    public class Region : SimpleMasterObject
    {
        public Region()
        {
            this.Customers = new List<Customers.Customers>();
            this.Territories = new List<Territories.Territories>();
        }
        public virtual ICollection<Customers.Customers> Customers { get; set; }
        public virtual ICollection<Territories.Territories> Territories { get; set; }

    }
}
