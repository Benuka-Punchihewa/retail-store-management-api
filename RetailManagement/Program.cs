using RetailManagement.Services.Customers;
using RetailManagement.Services.Orders;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ICustomerService, CustomerService>();
    builder.Services.AddSingleton<IOrderService, OrderService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


