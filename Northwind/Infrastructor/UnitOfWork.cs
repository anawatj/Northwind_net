﻿using Core.Externals;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Externals.Repository;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using StructureMap;
using Core.Domains.Categories;
using Core.Domains.Customers;
using Core.Domains.Master;
using Infrastructor.Repositories;
using Core.Domains.Territories;
using Core.Domains.Employees;
using Core.Domains.Suppliers;

namespace Infrastructor
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
      


        public  DbSet<Categories> Categories { get; set; }
        public  DbSet<Customers> Customers { get; set; }
        public  DbSet<Country> Countries { get; set; }
        
        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<DemoGraphics> DemoGraphics { get; set; }

        public DbSet<Territories> Territories { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<Experiences> Experiences { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }




        public UnitOfWork():base("UnitOfWork")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer(new MigrationInitialize.MigrateDbInitializer());
        }
        /*public UnitOfWork(IContainer container)
        {
            this.container = container;
            this.Configuration.AutoDetectChangesEnabled = true;
        }*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

        }
        public ICategoriesRepository CategoryRepository
        {
            get;
        }

        public ICustomersRepository CustomerRepository
        {
            get;
        }
        public MasterRepository MasterRepository
        {
            get;
        }
    }
}
