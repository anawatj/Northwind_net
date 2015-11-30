using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Master
{
    public class City : SimpleMasterObject
    {
        public City()
        {
            this.Customers = new List<Customers.Customers>();
        }
        public virtual long? CountryID { get; set; }
       
        public virtual ICollection<Customers.Customers> Customers { get; set; }
    }
}
