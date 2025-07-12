using Microsoft.AspNetCore.OData;
using Northwind.OData.Service;
using Packt.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddNorthwindContext();
builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents(routePrefix: "catalog",
            model: Methods.GetEdmModelForCatalog())
        .AddRouteComponents(routePrefix: "orderSystem",
            model: Methods.GetEdmModelForOrderSystem())
        .AddRouteComponents(routePrefix: "catalog/v{version}",
            model: Methods.GetEdmModelForCatalog())
        .Select()
        .Expand()
        .Filter()
        .OrderBy()
        .SetMaxTop(100)
        .Count()
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
