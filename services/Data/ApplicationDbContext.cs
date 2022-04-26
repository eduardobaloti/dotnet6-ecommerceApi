using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using udemy_dotnet.models.Domains;

namespace udemy_dotnet.services.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(p => p.Description).HasMaxLength(600).IsRequired(false);
            builder.Entity<Product>().Property(p => p.Name).HasMaxLength(155).IsRequired();
            builder.Entity<Product>().Property(p => p.Id).HasMaxLength(20).IsRequired();
            builder.Entity<Category>().ToTable("Categories");  
            builder.Ignore<Notification>();     
        }

    }
}