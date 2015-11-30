using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Master
{
    public class EducationLevel : SimpleMasterObject
    {
        public EducationLevel()
        {
            this.Educations = new List<Employees.Educations>();
        }
        public virtual ICollection<Employees.Educations> Educations { get; set; }
    }
}
