using ConsultingCompany.BLL.Contracts.IDataInitializer;
using ConsultingCompany.BLL.Contracts.IUnitOfWork;
using ConsultingCompany.BLL.Contracts.Repositories;
using ConsultingCompany.DAL.Data.Context;
using ConsultingCompany.DAL.Data.DataSeed;
using ConsultingCompany.DAL.Repositories;
using ConsultingCompany.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ConsultingCompany.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

           services.AddScoped<IUnitOfWork, UnitOfWork>();
           services.AddScoped<IDataInitializer, DataInitializer>();

           services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

           services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                              
                    });
            });



            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            return services;
        }
    }
}
