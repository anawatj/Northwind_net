using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Employees
{
    public class EmployeesMap : EntityTypeConfiguration<Core.Domains.Employees.Employees>
    {
        public EmployeesMap()
        {
            ToTable("TBL_EMPLOYEES");
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.EmployeeCode).HasColumnName("EMPLOYEE_CODE").HasMaxLength(20);
            Property(t => t.TitleID).HasColumnName("TITLE_ID");
            Property(t => t.FirstName).HasColumnName("FIRST_NAME").HasMaxLength(200);
            Property(t => t.LastName).HasColumnName("LAST_NAME").HasMaxLength(200);
            Property(t => t.BirthDate).HasColumnName("BIRTH_DATE");
            Property(t => t.HireDate).HasColumnName("HIRE_DATE");
            Property(t => t.Address).HasColumnName("ADDRESS").HasMaxLength(1000);
            Property(t => t.CityID).HasColumnName("CITY_ID");
            Property(t => t.RegionID).HasColumnName("REGION_ID");
            Property(t => t.CountryID).HasColumnName("COUNTRY_ID");
            Property(t => t.PostalCode).HasColumnName("POSTAL_CODE").HasMaxLength(20);
            Property(t => t.DepartmentID).HasColumnName("DEPARTMENT_ID");
            Property(t => t.Notes).HasColumnName("NOTES").HasMaxLength(1000);
            Property(t => t.ReportTo).HasColumnName("REPORT_TO");

            Property(t => t.HomePhone).HasColumnName("HOME_PHONE").HasMaxLength(20);
            Property(t => t.Extentions).HasColumnName("EXTENTIIONS").HasMaxLength(20);

            HasOptional(t => t.Title).WithMany(t => t.Employees).HasForeignKey(t => t.TitleID);
            HasOptional(t => t.City).WithMany(t => t.Employees).HasForeignKey(t => t.CityID);
            HasOptional(t => t.Country).WithMany(t => t.Employees).HasForeignKey(t => t.CountryID);
            HasOptional(t => t.Region).WithMany(t => t.Employees).HasForeignKey(t => t.RegionID);
            HasOptional(t => t.Department).WithMany(t => t.Employees).HasForeignKey(t => t.DepartmentID);
            HasOptional(t => t.ParentEmployee).WithMany(t => t.ChildEmployees).HasForeignKey(t => t.ReportTo);

            HasMany(t => t.Educations).WithOptional(t => t.Employee).HasForeignKey(t => t.EmployeeID);
            HasMany(t => t.Experiences).WithOptional(t => t.Employee).HasForeignKey(t => t.EmployeeID);
            HasMany(t => t.Territories).WithMany(t => t.Employees).Map(t => t.ToTable("TBL_EMPLOYEES_TERRITORIES").MapLeftKey("EMPLOYEE_ID").MapRightKey("TERRITORY_ID"));


            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");
        }
    }
}
