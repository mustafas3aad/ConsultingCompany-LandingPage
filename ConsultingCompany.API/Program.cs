using ConsultingCompany.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();

#region Data Seeding

await app.MigrateDatabaseAsync();
await app.SeedDatabaseAsync();

#endregion Data Seeding


 app.UseSwagger();

 app.UseSwaggerUI(option =>
 {
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "Consulting Company API v1");
    option.SwaggerEndpoint("/swagger/v2/swagger.json", "Consulting Company API v2");
 });


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
