using Core.Domains.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Employees
{
    public class EducationsMap : EntityTypeConfiguration<Educations>
    {
        public EducationsMap()
        {
            ToTable("TBL_EDUCATIONS");
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.EmployeeID).HasColumnName("EMPLOYEE_ID");
            Property(t => t.EducationLevelID).HasColumnName("EDUCATION_LEVEL_ID");
            Property(t => t.University).HasColumnName("UNIVERSITY").HasMaxLength(200);
            Property(t => t.Major).HasColumnName("MAJOR").HasMaxLength(200);
            Property(t => t.Minor).HasColumnName("MINOR").HasMaxLength(200);
            Property(t => t.Gpa).HasColumnName("GPA");
            HasOptional(t => t.Employee).WithMany(t => t.Educations).HasForeignKey(t => t.EmployeeID);
            HasOptional(t => t.EducationLevel).WithMany(t => t.Educations).HasForeignKey(t => t.EducationLevelID);

            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");
        }
    }
}
