using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.IoC
{
    public class DependencyResolverFilterProvider : FilterAttributeFilterProvider
    {
        private IContainer container;
        public DependencyResolverFilterProvider(IContainer container)
        {
            this.container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var container = StructureMapInit.InitializeContainer();
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}