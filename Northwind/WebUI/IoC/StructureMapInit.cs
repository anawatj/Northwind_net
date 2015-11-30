using Core.Externals;
using Core.Externals.Repository;
using Infrastructor;
using Infrastructor.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebUI.IoC
{
    internal class StructureMapInit
    {
        public static IContainer InitializeContainer()
        {
            var container = new Container(c => c.AddRegistry<DefaultRegistry>());
            return container;
        }
    }
    internal class DefaultRegistry : StructureMap.Configuration.DSL.Registry
    {
        public DefaultRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<UnitOfWork>();
            For<UnitOfWork>().Use<UnitOfWork>();
            For<ICategoriesRepository>().Use<CategoriesRepository>();
            For<ICustomersRepository>().Use<CustomersRepository>();
            For<MasterRepository>().Use<MasterRepository>();
        }
    }
}