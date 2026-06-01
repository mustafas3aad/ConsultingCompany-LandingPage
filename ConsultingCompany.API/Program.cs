using ConsultingCompany.API.Extensions;
using ConsultingCompany.API.MiddleWares;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();



#region Data Seeding

await app.MigrateDatabaseAsync();
await app.SeedDatabaseAsync();

#endregion Data Seeding


var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(locOptions.Value);


app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionMiddleware>();

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
