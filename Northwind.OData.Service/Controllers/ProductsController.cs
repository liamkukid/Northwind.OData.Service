using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Packt.Shared;

namespace Northwind.OData.Service.Controllers;

public class ProductsController : ODataController
{
    protected readonly NorthwindContext db;

    public ProductsController(NorthwindContext db)
    {
        this.db = db;
    }

    [EnableQuery]
    public IActionResult Get(string version = "1")
    {
        Console.WriteLine($"*** {nameof(ProductsController)} version: {version}");
        return Ok(db.Products);
    }

    [EnableQuery]
    public IActionResult Get(int key, string version = "1")
    {
        Console.WriteLine($"*** {nameof(ProductsController)} version: {version}");
        IQueryable<Product> products = db.Products.Where(
            product => product.ProductId == key);

        Product? product = products.FirstOrDefault();

        if (product is null || products is null)
        {
            return NotFound($"Product with id {key} not found.");
        }
        if (version == "2")
        {
            product.ProductName += " version 2.0";
        }
        return Ok(product);
    }

    public IActionResult Post([FromBody] Product product)
    {
        if (product is null)
        {
            return BadRequest("Product cannot be null.");
        }
        db.Products.Add(product);
        db.SaveChanges();
        return Created(product);
    }
}
