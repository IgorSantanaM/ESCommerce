using ESCommerce.QueryAPI.Endpoints.Internal;
using Marten;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;    
services.AddOpenApi();

services.AddMarten(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("MartenQueryDB");
    opt.Connection(connectionString!);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/EventSourcing.json");
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/EventSourcing.json", "Event Sourcing Commerce QueryAPI V1");
    });
}

app.MapGet("/", () => "It's Working!");

app.UseEndpoints<Program>();

app.UseHttpsRedirection();

app.Run();

