using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains.Customers;
using System.Data.Entity;
using Core.Domains.Master;

namespace Infrastructor.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {

        private UnitOfWork context;
        public CustomersRepository(UnitOfWork context)
        {
            this.context = context;
        }
        public IQueryable<Customers> AsQueryable()
        {
            return this.context.Customers.AsQueryable();
        }

        public List<Customers> GetAll()
        {
            return this.AsQueryable().ToList<Customers>();
        }

        public Customers GetById(long id)
        {
            return this.AsQueryable()
                .Include(t=>t.City)
                .Include(t=>t.Country)
                .Include(t=>t.Region)
                .Include(t=>t.DemoGraphics)
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public void Remove(long id)
        {
            Customers data = GetById(id);
            this.context.Customers.Remove(data);
            this.context.SaveChanges();
        }

        public Customers Save(Customers entity)
        {
            if(entity.Id==0)
            {
                var ret =  this.context.Customers.Add(entity);
                this.context.SaveChanges();
                return ret;
            }else
            {
                Customers data = GetById(entity.Id);
                data.CustomerCode = entity.CustomerCode;
                data.CompanyName = entity.CompanyName;
                data.ContactName = entity.ContactName;
                data.ContactTitle = entity.ContactTitle;
                data.Address = entity.Address;
                data.CountryID = entity.CountryID;
                data.CityID = entity.CityID;
                data.RegionID = entity.RegionID;
                data.PostalCode = entity.PostalCode;
                data.Phone = entity.Phone;
                data.Fax = entity.Fax;
                data.UpdateBy = entity.UpdateBy;
                data.UpdateDate = DateTime.Now;

                data.DemoGraphics = entity.DemoGraphics;

                this.context.SaveChanges();
                return data;

            }
        }
    }
}
