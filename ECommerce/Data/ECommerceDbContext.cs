﻿using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PricesArchive> PricesArchives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<Preset> Presets { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }
    }
}
