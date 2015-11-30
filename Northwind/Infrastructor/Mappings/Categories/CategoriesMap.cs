using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Mappings.Categories
{
    public class CategoriesMap : EntityTypeConfiguration<Core.Domains.Categories.Categories>
    {
        public CategoriesMap()
        {
            HasKey(t => t.Id).Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(t => t.CategoryName).HasColumnName("CATEGORY_NAME").HasMaxLength(200);
            Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            Property(t => t.CreateBy).HasColumnName("CREATE_BY").HasMaxLength(20);
            Property(t => t.CreateDate).HasColumnName("CREATE_DATE");
            Property(t => t.UpdateBy).HasColumnName("UPDATE_BY").HasMaxLength(20);
            Property(t => t.UpdateDate).HasColumnName("UPDATE_DATE");
        }
    }
}
