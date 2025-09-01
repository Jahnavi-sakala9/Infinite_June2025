using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeChallenge10.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly northwindEntities1 db = new northwindEntities1();

        // GET: api/orders/buchanan
        [HttpGet]
        [Route("buchanan")]
        public IHttpActionResult GetOrdersForBuchanan()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .Select(o => new
                           {
                               o.OrderID,
                               o.OrderDate,
                               o.ShipCity,
                               Customer = o.Customer.CompanyName
                           }).ToList();

            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}





