using ESCommerce.CommandAPI.Endpoints.Internal;
using ESCommerce.Domain;
using Marten;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddOpenApi();
services.RegisterDomain();

services.AddMarten(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("MartenDB");
    opt.Connection(connectionString!);
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/EventSourcing.json");

    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/EventSourcing.json", "Event Sourcing Commerce V1");
    });
}
app.MapGet("/", () => "It's Working!");
app.UseEndpoints<Program>();

app.UseHttpsRedirection();

app.Run();