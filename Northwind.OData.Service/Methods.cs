using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Packt.Shared;

namespace Northwind.OData.Service;

public static class Methods
{
    public static IEdmModel GetEdmModelForCatalog()
    {
        ODataConventionModelBuilder modelBuilder = new ();
        modelBuilder.EntitySet<Category>("Categories");
        modelBuilder.EntitySet<Product>("Products");
        modelBuilder.EntitySet<Supplier>("Suppliers");
        return modelBuilder.GetEdmModel();
    }

    public static IEdmModel GetEdmModelForOrderSystem()
    {
        ODataConventionModelBuilder modelBuilder = new ();
        modelBuilder.EntitySet<Customer>("Customers");
        modelBuilder.EntitySet<Order>("Orders");
        modelBuilder.EntitySet<Employee>("Employees");
        modelBuilder.EntitySet<Product>("Products");
        modelBuilder.EntitySet<Shipper>("Shippers");
        return modelBuilder.GetEdmModel();
    }
}
