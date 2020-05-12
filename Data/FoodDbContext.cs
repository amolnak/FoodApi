using FoodApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<DeliveryBoys> DeliveryBoys { get; set; }
        public DbSet<FamilyMemberDetails> FamilyMemberDetails { get; set; }
        public DbSet<ADMINMast> ADMINMast { get; set; }
        public DbSet<Offices> Offices { get; set; }
        public DbSet<SubscriptionSchedule> SubscriptionSchedule { get; set; }
        public DbSet<ModeTypes> ModeTypes { get; set; }
        public DbSet<AppInstallations> AppInstallations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }  
        public DbSet<ItemAddOns> ItemAddOns { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ItemTypes> ItemTypes { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Schools> Schools { get; set; }
        public DbSet<UserSubscriptions> UserSubscriptions { get; set; }
        public DbSet<VendorItems> VendorItems { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
		public DbSet<DeliveryVehicles> DeliveryVehicles { get; set; }
		public DbSet<City> City { get; set; }
        public DbSet<AdminRegions> AdminRegions { get; set; }
    }
}
