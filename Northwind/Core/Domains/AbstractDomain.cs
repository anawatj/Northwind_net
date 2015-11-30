using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public abstract class AbstractDomain<K> : IDomain<K>
    {
        public virtual string CreateBy
        {
            get; set;
        }

        public virtual DateTime? CreateDate
        {
            get; set;
        }

        public virtual K Id
        {
            get; set;
        }

        public virtual  string UpdateBy
        {
            get; set;
        }

        public virtual DateTime? UpdateDate
        {
            get; set;
        }

        /*public virtual int Version
        {
            get; set;
        }*/
    }
}
