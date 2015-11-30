using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Master
{
    public class Country : SimpleMasterObject
    {
        public Country()
        {
            this.Customers = new List<Customers.Customers>();
            this.Employees = new List<Employees.Employees>();
        }
        public virtual ICollection<Customers.Customers> Customers { get; set; }
        public virtual ICollection<Employees.Employees> Employees { get; set; }
    }
}
