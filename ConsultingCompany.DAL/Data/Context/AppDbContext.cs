using ConsultingCompany.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }


        public DbSet<ConsultationRequest> ConsultationRequests => Set<ConsultationRequest>();
        public DbSet<NewsletterSubscriber> NewsletterSubscribers => Set<NewsletterSubscriber>();
        public DbSet<Service> Services => Set<Service>();


    }
}
