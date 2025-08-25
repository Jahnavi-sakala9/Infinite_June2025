using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeChallenge9;

namespace CodeChallenge9.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities db = new northwindEntities();

        // Action 1: Customers in Germany
        public ActionResult GermanCustomers()
        {
            var germanCustomers = db.Customers
                                     .Where(c => c.Country == "Germany")
                                     .ToList();
            return View(germanCustomers);
        }

        // Action 2: Customer with OrderId == 10248
        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();
            return View(customer);
        }
    }

}



