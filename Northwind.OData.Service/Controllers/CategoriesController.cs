using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Packt.Shared;

namespace Northwind.OData.Service.Controllers;

public class CategoriesController : ODataController
{
    protected readonly NorthwindContext db;

    public CategoriesController(NorthwindContext db)
    {
        this.db = db;
    }

    [EnableQuery]
    public IActionResult GetCategories()
    {
        return Ok(db.Categories);
    }

    [EnableQuery]
    public IActionResult GetCategory(int key) 
    {
        return Ok(db.Categories.Where(
            category => category.CategoryId == key));
    }
}
