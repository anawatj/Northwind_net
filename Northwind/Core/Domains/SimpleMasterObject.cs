﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public abstract class SimpleMasterObject:AbstractDomain<long>
    {
        public SimpleMasterObject()
        {

        }
        public virtual string Name { get; set; }

    }
}
