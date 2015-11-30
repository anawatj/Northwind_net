﻿using Core.Domains.Categories;
using Core.Externals.Repository;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.Api
{
    public class CategoriesController : ApiController
    {

        private ICategoriesRepository repository;
        public CategoriesController()
        {
            IContainer container = IoC.StructureMapInit.InitializeContainer();
            this.repository = container.GetInstance<ICategoriesRepository>();


        }
        [Route("Categories/All")]
        [HttpGet]
        public IEnumerable<Categories> GetAll()
        {
            return repository.GetAll();
        }
    }
}
