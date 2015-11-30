using Core.Domains.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Territories
{
    public class Territories : AbstractDomain<long>
    {
        public Territories()
        {

        }
        public virtual string Name { get; set; }
        public virtual long? RegionID { get; set; }

        public virtual Region Region { get; set; }
    }
}
