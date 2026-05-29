using ConsultingCompany.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.Data.Configurations
{
    public class NewsletterSubscriberConfiguration : IEntityTypeConfiguration<NewsletterSubscriber>
    {
        public void Configure(EntityTypeBuilder<NewsletterSubscriber> builder)
        {
            builder.ToTable("NewsletterSubscribers", Tb =>
            {
                Tb.HasCheckConstraint(
                    "CK_NewsletterSubscriber_Email",
                    "Email LIKE '_%@_%._%'"
                );
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(256);

    
            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.Property(x => x.IsActive)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
