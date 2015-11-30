using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains.Territories;
using System.Data.Entity;
namespace Infrastructor.Repositories
{
    public class TerritoriesRepository : ITerritoriesRepository
    {
        private UnitOfWork context;
        public TerritoriesRepository(UnitOfWork  context)
        {
            this.context = context;
        }
        public IQueryable<Territories> AsQueryable()
        {
            return this.context.Territories.AsQueryable();
        }

        public List<Territories> GetAll()
        {
            return this.AsQueryable().ToList<Territories>();
        }

        public Territories GetById(long id)
        {
            return this.AsQueryable()
                .Include(t => t.Region)
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public void Remove(long id)
        {
            Territories data = GetById(id);
            this.context.Territories.Remove(data);
            this.context.SaveChanges();
        }

        public Territories Save(Territories entity)
        {
            if(entity.Id ==0 )
            {
                var ret =   this.context.Territories.Add(entity);
                this.context.SaveChanges();
                return ret;
            }
            else
            {
                var data = GetById(entity.Id);
                data.Name = entity.Name;
                data.Region = entity.Region;
                data.RegionID = entity.RegionID;
                this.context.SaveChanges();
                return data;
            }
        }
    }
}
