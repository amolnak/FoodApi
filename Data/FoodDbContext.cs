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

    }
}
