var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


