using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Employees
{
    public class Experiences : AbstractDomain<long>
    {
        public Experiences()
        {

        }
        public virtual long? EmployeeID { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual string Company { get; set; }
        public virtual DateTime? Start { get; set; }
        public virtual DateTime? End { get; set; }
        public virtual decimal? Salary { get; set; }
        public virtual string ReasonOfResign { get; set; }

    }
}
