using Core.Domains.Master;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Master
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("TBL_CITY");
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("NAME").HasMaxLength(200);
            Property(t =>t.CountryID).HasColumnName("COUNTRY_ID");
            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");

            HasMany(t => t.Customers).WithOptional(t => t.City).HasForeignKey(t => t.CityID);
        }
    }
}
