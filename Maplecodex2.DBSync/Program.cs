using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;
using Maplecodex2.DBSync.Data.Storage;
using Maplecodex2.DBSync.Data.Types;
using Serilog;
using System.Reflection;
using System.Dynamic;

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

                // Foreach class Type Storage, GetAll items and parse them using the same Type Services.
                Log.Logger.Information($"Starting Database Sync... Please Wait!\n");
                await DatabaseSync();

                Log.Logger.Information($"Metadata loaded!".Green());
                Timerwatch.Stop();
            }
        }

        // TODO foreach class type [Storage], get the Method {Init} to initialize them all by Reflection.
        public static void InitializeMetadata()
        {
            List<Type> listStaticClass = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAbstract && t.IsClass && t.Namespace == "Maplecodex2.DBSync.Data.Storage").ToList();

            foreach (Type staticClass in listStaticClass)
            {
                staticClass.GetMethod("Init")?.Invoke(null, null);
            }
        }

        public static async Task DatabaseSync()
        {
            DatabaseRequest<Item> itemContext = new();
            IEnumerable<Item> items = ItemStorage.GetAll().OrderBy(i => i.Id);

            ConsoleUtility.TotalProgressCount = items.Count();
            ConsoleUtility.ProgressCount = 1;

            foreach (Item item in items)
            {
                ConsoleUtility.ClassName = $"{item.Id}";
                if (await itemContext.Exist(item))
                {
                    continue;
                }
                await itemContext.Add(item).ContinueWith(t => ConsoleUtility.ProgressCount++).ContinueWith(t => ConsoleUtility.WriteProgressBar());
            }

            DatabaseRequest<Node> itemXml = new();
        }
    }
}