using Maplecodex2.Database.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace Maplecodex2.Database.Managers
{
    public class DatabaseManager : DatabaseRequest<IEntity>
    {
        private static bool Exists() => ((RelationalDatabaseCreator)Context.Database.GetService<IDatabaseCreator>()).Exists();

        private static void CreateDatabase() => Context.Database.EnsureCreated();

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