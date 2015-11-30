using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Territories
{
    public class TerritoriesMap :EntityTypeConfiguration<Core.Domains.Territories.Territories>
    {
        public TerritoriesMap()
        {
            ToTable("TBL_TERRITORIES");
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("NAME").HasMaxLength(200);
            Property(t => t.RegionID).HasColumnName("REGION_ID");

            HasOptional(t => t.Region).WithMany(t => t.Territories).HasForeignKey(t => t.RegionID);

            HasMany(t => t.Employees).WithMany(t => t.Territories).Map(t => t.ToTable("TBL_EMPLOYEES_TERRITORIES").MapLeftKey("TERRITORY_ID").MapRightKey("EMPLOYEE_ID"));



            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");
        }
    }
}
