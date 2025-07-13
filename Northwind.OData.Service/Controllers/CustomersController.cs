using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Packt.Shared;

namespace Northwind.OData.Service.Controllers;

public class CustomersController : ODataController
{
    protected readonly NorthwindContext db;

    public CustomersController(NorthwindContext db)
    {
        this.db = db;
    }

    [EnableQuery]
    public IActionResult GetCustomers()
    {
        return Ok(db.Customers);
    }

    [EnableQuery]
    public IActionResult GetCustomer(string key)
    {
        return Ok(db.Customers.Where(
            customer => customer.CustomerId == key));
    }
}