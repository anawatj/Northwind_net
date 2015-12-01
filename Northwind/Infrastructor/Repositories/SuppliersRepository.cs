using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains.Suppliers;
using System.Data.Entity;
namespace Infrastructor.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private UnitOfWork context;
        public SuppliersRepository(UnitOfWork context)
        {
            this.context = context;
        }
        public IQueryable<Suppliers> AsQueryable()
        {
            return this.context.Suppliers.AsQueryable();
        }

        public List<Suppliers> GetAll()
        {
            return AsQueryable().ToList<Suppliers>();
        }

        public Suppliers GetById(long id)
        {
            return AsQueryable()
               .Include(t => t.City)
               .Include(t => t.Region)
               .Include(t => t.Country)
               .Where(t => t.Id == id)
               .SingleOrDefault();
        }

        public void Remove(long id)
        {
            var data = GetById(id);
            this.context.Suppliers.Remove(data);
            this.context.SaveChanges();
        }

        public Suppliers Save(Suppliers entity)
        {
           if(entity.Id ==0)
            {
                var ret  = this.context.Suppliers.Add(entity);
                this.context.SaveChanges();
                return ret;
            }else
            {
                var data = GetById(entity.Id);
                data.SupplierCode = entity.SupplierCode;
                data.CompanyName = entity.CompanyName;
                data.ContactName = entity.ContactName;
                data.ContactTitle = entity.ContactTitle;
                data.Address = entity.Address;
                data.City = entity.City;
                data.Country = entity.Country;
                data.Region = entity.Region;
                data.PostalCode = entity.PostalCode;
                data.Phone = entity.Phone;
                data.Fax = entity.Fax;
                data.HomePage = entity.HomePage;
                data.UpdateBy = entity.UpdateBy;
                data.UpdateDate = DateTime.Now;
                this.context.SaveChanges();
                return data;
            }
        }
    }
}
