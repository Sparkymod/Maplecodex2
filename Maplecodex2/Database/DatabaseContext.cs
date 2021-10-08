using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;
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

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(Item.Build);
        }

        // Database Manager Controller.
        private static bool Exists()
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            return ((RelationalDatabaseCreator)Context.Database.GetService<IDatabaseCreator>()).Exists();
        }

        private static void CreateDatabase()
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
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

    #region Generic DbContext using DatabaseContext
    public class DatabaseContext<TEntity> : DatabaseContext, IModel<TEntity> where TEntity : class
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public async Task<TEntity> Add(TEntity entity)
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            Context.Set<TEntity>().Add(entity);
            await Commit();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            TEntity entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            Context.Set<TEntity>().Remove(entity);
            await Commit();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            Context.Entry(entity).State = EntityState.Modified;
            await Commit();
            return entity;
        }

        public async Task<bool> Exist(TEntity entity)
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            return await Context.Set<TEntity>().ContainsAsync(entity);
        }

        public async Task<bool> Commit()
        {
            using DatabaseContext Context = new(Settings.GetDbContextOptions().Options);
            try
            {
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error($"Error saving changes => {ex.InnerException.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Error saving changes => {ex}");
                return false;
            }
        }
    }

    #endregion
}