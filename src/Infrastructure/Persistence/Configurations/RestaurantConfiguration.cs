using System;
using System.Collections.Generic;
using System.Text;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class RestaurantConfiguration: IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants"); //Nomeia a tabela no banco de dados como "Restaurants"

            builder.HasKey(restaurant => restaurant.Id); // Define a propriedade "Id" como chave primária da entidade "Restaurant"

            builder.Property(restaurant => restaurant.Name).IsRequired() 
                .HasMaxLength(150); // Define a propriedade "Name" como obrigatória e com tamanho máximo de 150 caracteres

            builder.Property(restaurant=> restaurant.WhatsAppNumber).IsRequired()
                .HasMaxLength(13); 

            builder.Property(restaurant => restaurant.IsActive).IsRequired();

            builder.HasIndex(restaurant => restaurant.WhatsAppNumber)
                .IsUnique();
        }
    }
}
