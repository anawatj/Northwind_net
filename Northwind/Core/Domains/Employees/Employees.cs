using Core.Domains.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Employees
{
    public class Employees : AbstractDomain<long>
    {
        public Employees()
        {
            this.Educations = new List<Educations>();
            this.Experiences = new List<Experiences>();
            this.ChildEmployees = new List<Employees>();
            this.Territories = new List<Territories.Territories>();
        }
        public virtual string EmployeeCode { get; set; }
        public virtual Title Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual DateTime? HireDate { get; set; }
        public virtual string Address { get; set; }
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual Country Country { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string Extentions { get; set; }
        public virtual Department Department { get; set; }
        public virtual string Notes { get; set; }
        public virtual long ReportTo { get; set; }
        public virtual Employees ParentEmployee { get; set; }
        public virtual ICollection<Employees> ChildEmployees { get; set; }
        public virtual ICollection<Territories.Territories> Territories { get; set; }
        public virtual ICollection<Educations> Educations { get; set; }
        public virtual ICollection<Experiences> Experiences { get; set; }



    }
}
