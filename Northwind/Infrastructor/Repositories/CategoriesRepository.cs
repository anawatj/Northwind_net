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
        private UnitOfWork context;

    
        public CategoriesRepository(UnitOfWork context)
        {
            this.context = context;
 
        }
        public IQueryable<Categories> AsQueryable()
        {
            return this.context.Categories.AsQueryable();
        }

        public List<Categories> GetAll()
        {
            return this.AsQueryable().ToList<Categories>();
        }

        public Categories GetById(long id)
        {
            return this.AsQueryable()
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public void Remove(long id)
        {
            Categories data = GetById(id);
            this.context.Categories.Remove(data);
            this.context.SaveChanges();
        }

        public Categories Save(Categories entity)
        {
            if(entity.Id ==0 )
            {
                Categories ret = this.context.Categories.Add(entity);
                this.context.SaveChanges();
                return ret;
            }else
            {
                Categories data = GetById(entity.Id);
                data.CategoryName = entity.CategoryName;
                data.Description = entity.Description;
                data.UpdateBy = entity.UpdateBy;
                data.UpdateDate = DateTime.Now;
                this.context.SaveChanges();
                return data;
            }
        }
    }
}
