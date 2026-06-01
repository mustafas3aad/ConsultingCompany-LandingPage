using ConsultingCompany.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.Data.Configurations
{
    public class ConsultationRequestConfiguration : IEntityTypeConfiguration<ConsultationRequest>
    {
        public void Configure(EntityTypeBuilder<ConsultationRequest> builder)
        {
            builder.ToTable("ConsultationRequests", Tb =>
            {
                Tb.HasCheckConstraint(
                    "CK_ConsultationRequest_Email",
                    "Email LIKE '_%@_%._%'"
                );
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.FullName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(x => x.CompanyName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Message)
                   .HasMaxLength(2000);

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasConversion<string>()   
                   .HasMaxLength(50);

            builder.Property(x => x.IsRead)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

          
            builder.HasOne(x => x.Service)
                   .WithMany(s => s.ConsultationRequests)
                   .HasForeignKey(x => x.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => x.Status);
        }
    }
}
