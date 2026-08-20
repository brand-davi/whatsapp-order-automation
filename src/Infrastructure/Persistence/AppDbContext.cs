using System;
using System.Collections.Generic;
using System.Text;
using Domain.Catalog;
using Domain.Conversations;
using Domain.Customers;
using Domain.Orders;
using Domain.Printing;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<RestaurantSettings> RestaurantSettings => Set<RestaurantSettings>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<MenuItemVariant> MenuItemVariants => Set<MenuItemVariant>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Conversation> Conversations => Set<Conversation>();
        public DbSet<ConversationMessage> ConversationMessages => Set<ConversationMessage>();
        public DbSet<PrintJob> PrintJobs => Set<PrintJob>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
