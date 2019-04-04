using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarmeBakkerLib;
using Microsoft.EntityFrameworkCore;

namespace WarmeBakker.Data
{
    public class WarmeBakkerContext : DbContext
    {
        public WarmeBakkerContext(DbContextOptions<WarmeBakkerContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<NewsMessages> NewsMessages { get; set; }
        public DbSet<topicsContactForm> topicsContactforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().HasIndex(p => p.Name); /////////////////bijgevoegde lijn voor test
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderLine>().ToTable("OrderLine");
            modelBuilder.Entity<NewsMessages>().ToTable("NewsMessages");
            modelBuilder.Entity<topicsContactForm>().ToTable("topicsContactforms");
        }
    }
}
