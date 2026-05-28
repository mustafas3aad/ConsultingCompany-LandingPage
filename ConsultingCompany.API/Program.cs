using ConsultingCompany.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();

#region Data Seeding

await app.MigrateDatabaseAsync();
await app.SeedDatabaseAsync();

#endregion Data Seeding

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
