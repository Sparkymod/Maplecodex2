using Microsoft.EntityFrameworkCore;
using Maplecodex2.Data.Models;

namespace Maplecodex2.Database
{
    public class DatabaseContext : DbContext
    {
        // Add all Model entities here.
        public DbSet<Item> Items { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(Item.Build);
        }
    }
}