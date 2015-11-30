using Core.Domains.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Customers
{
    public class Customers : AbstractDomain<long>
    {
        public Customers()
        {
            this.DemoGraphics = new List<DemoGraphics>();
        }
        public virtual string CustomerCode { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }

        public virtual long? CityID { get; set; }
        public virtual long? RegionID { get; set; }
        public virtual long? CountryID { get; set; }

        public virtual string PostalCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }

        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<DemoGraphics> DemoGraphics { get; set; }

    }
}
