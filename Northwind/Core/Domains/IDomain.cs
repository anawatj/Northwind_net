using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public interface IDomain<K>
    {
         K Id { get; set; }
         int Version { get; set; }

         string CreateBy { get; set; }
       
         DateTime? CreateDate { get; set; }

         string UpdateBy { get; set; }

         DateTime? UpdateDate { get; set; }


    }
}
