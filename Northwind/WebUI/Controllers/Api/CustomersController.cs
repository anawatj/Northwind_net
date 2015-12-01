using Core.Domains.Customers;
using Core.Externals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ICustomersRepository repository;
        public CustomersController(ICustomersRepository  repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Customers> GetAll()
        {
            return repository.GetAll();
        }
    }
}
