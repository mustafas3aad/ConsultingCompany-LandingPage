using Asp.Versioning;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.Mapping;
using ConsultingCompany.BLL.Services;
using ConsultingCompany.DAL.Data.Context;
using ConsultingCompany.DAL.Data.DataSeed;
using ConsultingCompany.DAL.Repositories;
using ConsultingCompany.DAL.Repositories.IRepositories;
using ConsultingCompany.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

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
           services.AddScoped<IConsultationService,ConsultationService>();
           services.AddAutoMapper(X => X.AddProfile<ConsultationRequestProfile>(), typeof(ConsultationRequestProfile).Assembly);



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

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            })
             .AddApiExplorer(options =>
             {
                 options.GroupNameFormat = "'v'VVV";
                 options.SubstituteApiVersionInUrl = true;
             });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Consulting Company API",
                    Version = "v1",
                    Description = "API for managing consulting company data (v1)"
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Consulting Company API",
                    Version = "v2",
                    Description = "API for managing consulting company data (v2 - updated)"
                });
            });

            return services;
        }
    }
}
