using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class RestaurantSettingsConfiguration : IEntityTypeConfiguration<RestaurantSettings>
    {
        public void Configure(EntityTypeBuilder<RestaurantSettings> builder)
        {

            builder.ToTable("RestaurantSettings");

            builder.HasKey(setting => setting.Id);

            builder.Property(settings => settings.AutomationEnabled).IsRequired();

            builder.HasIndex(settings => settings.RestaurantId).IsUnique();

            builder.HasOne<Restaurant>().WithOne().HasForeignKey<RestaurantSettings>(settings => settings.RestaurantId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
