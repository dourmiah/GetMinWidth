using GetMinWidthAPI.Data;
using GetMinWidthAPI.Models;
using GetMinWidthAPI.Repositories;
using GetMinWidthAPI.Requests;
using GetMinWidthAPI.Services.Calculation;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories (Product and Order) will be created in memory with a single instance
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

// Create a single Factory instance to generate the different calculation methods
builder.Services.AddSingleton<WidthCalculationFactory>();

// Create specific instances to calculate product width and process the orders
builder.Services.AddScoped<WidthCalculator>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Feeds product repository
using (var scope = app.Services.CreateScope())
{
    var repository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
    await Data.FeedData(repository);
}

// API documentation
app.UseSwagger();
app.UseSwaggerUI();

// Error handling
app.UseExceptionHandler(exceptionHanler =>
{
    exceptionHanler.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error is not null)
        {
            var response = new
            {
                message = "An error occured.",
                detail = error.Error.Message
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    });
});

// POST request
app.MapPost("/orders", async (OrderRequest request, IOrderService service) =>
{
    var order = new Order { Id = request.Id, products = request.Products };
    var newOrder = await service.CreateOrder(order);
    return Results.Created($"/orders/{newOrder.Id}", newOrder);
});


// GET request
app.MapGet("/orders/{id}", async (string id, IOrderService service) =>
{
    var order = await service.GetOrder(id);
    return order is null ? Results.NotFound() : Results.Ok(order);
});

app.Run();

// For the unit tests : (WebApplicationFactory<Program> requires explicit presence of a Program class) 
public partial class Program 
{
}


