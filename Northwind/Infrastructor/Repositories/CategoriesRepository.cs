using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains.Categories;
using System.Data.Entity;
using Core.Externals;

namespace Infrastructor.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private DbContext dbContext;
        private DbSet<Categories> dbSet;
    
        public CategoriesRepository(DbSet<Categories> dbSet, DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbSet;
        }
        public IQueryable<Categories> AsQueryable()
        {
            return this.dbSet.AsQueryable();
        }

        public List<Categories> GetAll()
        {
            return this.dbSet.AsQueryable().ToList<Categories>();
        }

        public Categories GetById(long id)
        {
            return this.dbSet.AsQueryable()
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public void Remove(long id)
        {
            Categories data = GetById(id);
            this.dbSet.Remove(data);
            this.dbContext.SaveChanges();
        }

        public Categories Save(Categories entity)
        {
            if(entity.Id ==0 )
            {
                Categories ret = this.dbSet.Add(entity);
                this.dbContext.SaveChanges();
                return ret;
            }else
            {
                Categories data = GetById(entity.Id);
                data.CategoryName = entity.CategoryName;
                data.Description = entity.Description;
                data.UpdateBy = entity.UpdateBy;
                data.UpdateDate = DateTime.Now;
                this.dbContext.SaveChanges();
                return data;
            }
        }
    }
}
