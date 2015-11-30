using Core.Externals;
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

namespace Infrastructor
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private IContainer container;
        private ICategoriesRepository categoriesRepository;
        private ICustomersRepository customersRepository;
        private MasterRepository masterRepository;


        public  DbSet<Categories> Categories { get; set; }
        public  DbSet<Customers> Customers { get; set; }
        public  DbSet<Country> Countries { get; set; }
        
        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<DemoGraphics> DemoGraphics { get; set; }

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
