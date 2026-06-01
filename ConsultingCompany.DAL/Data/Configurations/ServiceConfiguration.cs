using ConsultingCompany.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.Data.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.NameAr)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(x => x.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasMany(x => x.ConsultationRequests)
                   .WithOne(c => c.Service)
                   .HasForeignKey(c => c.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
