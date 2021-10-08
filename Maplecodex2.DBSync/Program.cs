using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;
using Maplecodex2.DBSync.Data.Storage;
using Serilog;

namespace Maplecodex2.DBSync
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Settings.InitializeSerilog();
            Log.Logger.Warning($"DO YOU WANT TO PARSE THE DATABASE? \"yes\" to parse.".Yellow());

            string? read = Console.ReadLine();
            if (read != null && read.Contains("yes", StringComparison.OrdinalIgnoreCase))
            {
                Settings.InitDatabase();
                Timerwatch.Start();
                // Initialize Metadata
                Log.Logger.Information($"Initialize Metadata...\n".Yellow());
                InitializeMetadata();

                Log.Logger.Information($"Metadata loaded!".Green());
                // Foreach class Type Storage, GetAll items and parse them using the same Type Services.
                Log.Logger.Information($"Starting Database Sync... Please Wait!\n");

                int count = 1;
                DatabaseRequest<Item> itemContext = new();

                IEnumerable<Item> items = ItemStorage.GetAll().OrderBy(i => i.Id);
                foreach (Item item in items)
                {
                    if (await itemContext.Exist(item))
                    {
                        ConsoleUtility.WriteProgressBar(count++, items.Count());
                        continue;
                    }
                    await itemContext.Add(item).ContinueWith(t => ConsoleUtility.WriteProgressBar(count++, items.Count()));
                }

                Timerwatch.Stop();
            }
        }

        // TODO foreach class type [Storage], get the Method {Init} to initialize them all by Reflection.
        public static void InitializeMetadata() => ItemStorage.Init();
    }
}