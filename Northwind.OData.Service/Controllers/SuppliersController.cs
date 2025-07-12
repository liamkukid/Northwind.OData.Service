using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Packt.Shared;

namespace Northwind.OData.Service.Controllers;

public class SuppliersController : ODataController
{
    protected readonly NorthwindContext db;

    public SuppliersController(NorthwindContext db)
    {
        this.db = db;
    }

    [EnableQuery]
    public IActionResult GetSuppliers()
    {
        return Ok(db.Suppliers);
    }

    [EnableQuery]
    public IActionResult GetSupplier(int key)
    {
        return Ok(db.Suppliers.Where(
            supplier => supplier.SupplierId == key));
    }
}
