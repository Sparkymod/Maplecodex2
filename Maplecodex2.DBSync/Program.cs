using Maplecodex2.Data.Models;
using Maplecodex2.Data.Services;
using Maplecodex2.DBSync;
using Maplecodex2.DBSync.Data.Storage;
using Serilog;
using System.Diagnostics;

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

                Stopwatch timer = Stopwatch.StartNew();
                timer.Start();

                // Initialize Metadata
                Log.Logger.Information($"Initialize Metadata...");
                InitializeMetadata();

                Log.Logger.Information($"Metadata loaded!".Green());

                // Foreach class Type Storage, GetAll items and parse them using the same Type Services.
                Log.Logger.Information($"Starting Database Sync... Please Wait!");

                int count = 1;
                ItemService service = new();

                IEnumerable<Item> items = ItemStorage.GetAll();

                foreach (Item item in items)
                {
                    await Task.Run( () => service.Add(item).ContinueWith(t => ConsoleUtility.WriteProgressBar((float)count++ / items.Count() * 100f)));
                }

                timer.Stop();
                Log.Logger.Information($"Parse to Database finished in: {timer.Elapsed.TotalSeconds}".Green());
            }
        }

        // TODO foreach class type [Storage], get the Method {Init} to initialize them all by Reflection.
        public static void InitializeMetadata() => ItemStorage.Init();
    }
}