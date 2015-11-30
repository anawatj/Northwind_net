using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Master
{
    public class Department : SimpleMasterObject
    {
        public Department()
        {
            this.Employees = new List<Employees.Employees>();
        }
        public virtual ICollection<Employees.Employees> Employees { get; set; }
    }
}
