using Core.Externals;
using Core.Externals.Repository;
using Infrastructor;
using Infrastructor.Repositories;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;
using StructureMap.TypeRules;
using StructureMap.Web.Pipeline;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

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
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            For<IFilterProvider>().Use<DependencyResolverFilterProvider>();
            Policies.FillAllPropertiesOfType<IContainer>();
            For<UnitOfWork>().Use<UnitOfWork>().Named("UnitOfWorkObject").LifecycleIs<HttpContextLifecycle>();
            For<IUnitOfWork>().Use<UnitOfWork>(x => x.GetInstance<UnitOfWork>("UnitOfWorkObject")).LifecycleIs<HttpContextLifecycle>();

            // Asp.net Identity dependencys in managers
            For<DbContext>().Use<UnitOfWork>(x => x.GetInstance<UnitOfWork>("UnitOfWorkObject"));
            For<ICategoriesRepository>().Use<CategoriesRepository>().Ctor<UnitOfWork>("context").Is(t => t.GetInstance<UnitOfWork>("UnitOfWorkObject"));
            For<ICustomersRepository>().Use<CustomersRepository>().Ctor<UnitOfWork>("context").Is(t=>t.GetInstance<UnitOfWork>("UnitOfWorkObject"));
            For<IEmployeesRepository>().Use<EmployeesRepository>().Ctor<UnitOfWork>("context").Is(t => t.GetInstance<UnitOfWork>("UnitOfWorkObject"));
            For<MasterRepository>().Use<MasterRepository>().Ctor<UnitOfWork>("context").Is(t => t.GetInstance<UnitOfWork>("UnitOfWorkObject"));
        }
    }
    public class ControllerConvention : IRegistrationConvention
    {
        #region Public Methods and Operators

        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo<ApiController>() && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
        #endregion
    }
}