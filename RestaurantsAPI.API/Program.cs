

using RestaurantsAPI.Infrastructure.Extensions;
using RestaurantsAPI.Infrastructure.Seeders;
using RestaurantsAPI.Application.Extensions;




var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddApplicationServices();
builder.Services.AddInfraStructureServices(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
