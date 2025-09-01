using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeChallenge10.Models;

namespace CodeChallenge10.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        private readonly northwindEntities1 db = new northwindEntities1();

        // GET: api/customers/bycountry/USA
        [HttpGet]
        [Route("bycountry/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();

            var result = customers.Select(c => new
            {
                c.CustomerID,
                c.CompanyName,
                c.ContactName,
                c.City,
                c.Country
            });

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}


