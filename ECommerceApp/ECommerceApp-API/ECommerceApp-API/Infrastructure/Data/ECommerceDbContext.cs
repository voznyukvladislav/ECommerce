using ECommerceApp_API.Core.Entities;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp_API.Infrastructure.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<ECommerceCMS_API.Core.Entities.Attribute> Attributes { get; set; }
        public DbSet<Attribute_AttributeSet> Attribute_AttributeSets { get; set; }
        public DbSet<AttributeSet> AttributeSets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<MeasurementSet> MeasurementSets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order_Product> Order_Product { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart_Product> ShoppingCart_Product { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Value> Values { get; set; }

        public ECommerceDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
