using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Customers
{
    public class CustomersMap : EntityTypeConfiguration<Core.Domains.Customers.Customers>
    {
        public CustomersMap()
        {
            ToTable("TBL_CUSTOMERS");
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.CustomerCode).HasColumnName("CUSTOMER_CODE").HasMaxLength(20);
            Property(t => t.CompanyName).HasColumnName("COMPANY_NAME").HasMaxLength(200);
            Property(t => t.ContactName).HasColumnName("CONTACT_NAME").HasMaxLength(200);
            Property(t => t.ContactTitle).HasColumnName("CONTACT_TITLE").HasMaxLength(200);
            Property(t => t.Address).HasColumnName("ADDRESS").HasMaxLength(1000);

            Property(t => t.CityID).HasColumnName("CITY_ID");
            Property(t => t.CountryID).HasColumnName("COUNTRY_ID");
            Property(t => t.RegionID).HasColumnName("REGION_ID");
            Property(t => t.PostalCode).HasColumnName("POSTAL_CODE").HasMaxLength(20);
            Property(t => t.Phone).HasColumnName("PHONE").HasMaxLength(20);
            Property(t => t.Fax).HasColumnName("FAX").HasMaxLength(20);

            HasOptional(t => t.City).WithMany(t => t.Customers).HasForeignKey(t => t.CityID);
            HasOptional(t => t.Country).WithMany(t => t.Customers).HasForeignKey(t => t.CountryID);
            HasOptional(t => t.Region).WithMany(t => t.Customers).HasForeignKey(t => t.RegionID);

            HasMany(t => t.DemoGraphics).WithMany(t => t.Customers).Map(t => t.ToTable("TBL_CUSTOMERS_DEMOGRAPHICS").MapLeftKey(new string[] { "CUSTOMER_ID" }).MapRightKey(new string[] { "DEMOGRAPHIC_ID" }));


            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");






        }
    }
}
