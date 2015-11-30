using Core.Domains.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Employees
{
    public class ExperiencesMap : EntityTypeConfiguration<Experiences>
    {
        public ExperiencesMap()
        {
            ToTable("TBL_EXPERIENCES");
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.Company).HasColumnName("COMPANY").HasMaxLength(200);
            Property(t => t.EmployeeID).HasColumnName("EMPLOYEE_ID");
            Property(t => t.Start).HasColumnName("START");
            Property(t => t.End).HasColumnName("END");
            Property(t => t.Salary).HasColumnName("SALARY");
            Property(t => t.ReasonOfResign).HasColumnName("REASON_OF_RESIGN").HasMaxLength(1000);

            HasOptional(t => t.Employee).WithMany(t => t.Experiences).HasForeignKey(t => t.EmployeeID);
            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");

        }
    }
}

