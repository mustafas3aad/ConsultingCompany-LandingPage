using ConsultingCompany.DAL.Data.Context;
using ConsultingCompany.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsultingCompany.DAL.Data.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly AppDbContext _dbContext;

        public DataInitializer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            try
            {
                var hasServices = await _dbContext.Services.AnyAsync();
                var hasConsultationRequests = await _dbContext.ConsultationRequests.AnyAsync();
                var hasNewsletterSubscribers = await _dbContext.NewsletterSubscribers.AnyAsync();

              
                if (hasServices && hasConsultationRequests && hasNewsletterSubscribers)
                    return;

              
                if (!hasServices)
                {
                    await SeedDataFromJsonAsync<Service>("Services.json", _dbContext.Services);
                    await _dbContext.SaveChangesAsync();
                }

            
                if (!hasNewsletterSubscribers)
                {
                    await SeedDataFromJsonAsync<NewsletterSubscriber>("NewsletterSubscribers.json", _dbContext.NewsletterSubscribers);
                    await _dbContext.SaveChangesAsync();
                }

                if (!hasConsultationRequests)
                {
                    await SeedDataFromJsonAsync<ConsultationRequest>("ConsultationRequests.json", _dbContext.ConsultationRequests);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Data Seeding Failed: {ex}");
            }
        }

        #region Helper Methods

        private async Task SeedDataFromJsonAsync<T>(string fileName, DbSet<T> dbSet) where T : class
        {
            var filePath = ResolveFilePath(fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Seed file not found: {filePath}");

            try
            {
                using var dataStream = File.OpenRead(filePath);

                var data = await JsonSerializer.DeserializeAsync<List<T>>(dataStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                });

                if (data is not null && data.Count > 0)
                    await dbSet.AddRangeAsync(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading seed file '{fileName}': {ex}");
            }
        }

        private static string ResolveFilePath(string fileName)
        {
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            return isDevelopment
                ? Path.Combine("..", "ConsultingCompany.DAL", "Data", "DataSeed", "JSONFiles", fileName)
                : Path.Combine("Data", "DataSeed", "JSONFiles", fileName);
        }

        #endregion
    }
}