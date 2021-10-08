using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Maplecodex2.Database.Core
{
    public class DatabaseRequest<TEntity> : DatabaseContext, IModel<TEntity> where TEntity : class
    {
        public async Task<TEntity> Add(TEntity entity)
        {
            using DatabaseContext Context = new();
            Context.Set<TEntity>().Add(entity);
            await Commit(Context);
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            using DatabaseContext Context = new();
            TEntity entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            Context.Set<TEntity>().Remove(entity);
            await Commit(Context);

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            using DatabaseContext Context = new();
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            using DatabaseContext Context = new();
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using DatabaseContext Context = new();
            Context.Entry(entity).State = EntityState.Modified;
            await Commit(Context);
            return entity;
        }

        public async Task<bool> Exist(TEntity entity)
        {
            using DatabaseContext Context = new();
            return await Context.Set<TEntity>().ContainsAsync(entity);
        }

        public async Task<bool> Commit(DatabaseContext Context)
        {
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
}