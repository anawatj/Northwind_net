using Core.Domains.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructor.Repositories
{
    public class MasterRepository
    {
        private UnitOfWork context;
        public MasterRepository(UnitOfWork  context)
        {
            this.context = context;
        }
        public IQueryable<Country> AsCountryQueryable()
        {
            return this.context.Countries.AsQueryable();
        }
        public IQueryable<City> AsCityQueryable()
        {
            return this.context.Cities.AsQueryable();
        }
        public IQueryable<Region> AsRegionQueryable()
        {
            return this.context.Regions.AsQueryable();
        }

        public IQueryable<DemoGraphics> AsDemoGraphicQueryable()
        {
            return this.context.DemoGraphics.AsQueryable();
        }
    }
}
