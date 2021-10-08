using Maplecodex2.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace Maplecodex2.Database
{
    public class DatabaseContext : DbContext
    {
        // Add all Model entities here.
        public DbSet<Item>? Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(Item.Build);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL(Settings.GetConnectionString());

        // Database Manager Controller.
        private static bool Exists()
        {
            using DatabaseContext Context = new();
            return ((RelationalDatabaseCreator)Context.Database.GetService<IDatabaseCreator>()).Exists();
        }

        private static void CreateDatabase()
        {
            using DatabaseContext Context = new();
            Context.Database.EnsureCreated();
        }

        public void InitDatabase()
        {
            if (Exists())
            {
                Log.Information("Database already exists.");
                return;
            }
            Log.Information("Creating database...");
            CreateDatabase();

            Log.Information("Database created.");
        }
    }
}