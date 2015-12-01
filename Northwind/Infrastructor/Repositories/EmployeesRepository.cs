using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains.Employees;
using System.Data.Entity;
namespace Infrastructor.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private UnitOfWork context;
        public EmployeesRepository(UnitOfWork context)
        {
            this.context = context;
        }
        public IQueryable<Employees> AsQueryable()
        {
            return this.context.Employees.AsQueryable();
        }

        public List<Employees> GetAll()
        {
            return AsQueryable().ToList();
        }

        public Employees GetById(long id)
        {
            return AsQueryable()
                .Include(t => t.City)
                .Include(t => t.Region)
                .Include(t => t.Country)
                .Include(t => t.Department)
                .Include(t => t.Title)
                .Include(t => t.Educations
                .AsQueryable()
                .Include(e=>e.EducationLevel))
                .Include(t => t.Experiences)
                .Include(t => t.Territories)
                .Include(t => t.ParentEmployee)
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public void Remove(long id)
        {
            var data = GetById(id);
            this.context.Employees.Remove(data);
            this.context.SaveChanges();
        }

        public Employees Save(Employees entity)
        {
            if(entity.Id ==0)
            {
                var ret = this.context.Employees.Add(entity);
                this.context.SaveChanges();
                return ret;

            }else
            {
                var data = GetById(entity.Id);
                data.Title = entity.Title;
                data.FirstName = entity.FirstName;
                data.LastName = entity.LastName;
                data.BirthDate = entity.BirthDate;
                data.HireDate = entity.HireDate;
                data.Address = entity.Address;
                data.City = entity.City;
                data.Region = entity.Region;
                data.Country = entity.Country;
                data.PostalCode = entity.PostalCode;
                data.HomePhone = entity.HomePhone;
                data.Extentions = entity.Extentions;
                data.Department = entity.Department;
                data.ParentEmployee = entity.ParentEmployee;
                data.Educations = entity.Educations;
                data.Experiences = entity.Experiences;
                data.Territories = entity.Territories;
                this.context.SaveChanges();
                return data;
            }
        }
    }
}
