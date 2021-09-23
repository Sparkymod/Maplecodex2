using Maplecodex2.Data.Models;
using Maplecodex2.Data.Services;
using Maplecodex2.DBSync.Data.Storage;
using Serilog;
using System;
using System.Diagnostics;

namespace Maplecodex2.DBSync
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            Settings.InitializeSerilog();
            Settings.InitDatabase();

            Log.Logger.Warning($"ARE YOU WANT TO PARSE THE DATABASE? \"Yes\" to parse.");

            string? read = Console.ReadLine();
            if (read != null && read.Contains("yes", StringComparison.OrdinalIgnoreCase))
            {
                Stopwatch timer = Stopwatch.StartNew();
                timer.Start();

                // Initialize Metadata
                Log.Logger.Information($"Initialize Metadata...");
                InitializeMetadata();

                Log.Logger.Information($"Metadata load!");

                // Foreach class Type Storage, GetAll items and parse them using the same Type Services.
                Log.Logger.Information($"Starting Database Sync... Please Wait!");
                ItemService service = new();
                foreach (Item item in ItemStorage.GetAll())
                {
                    await service.Add(item);
                }

                timer.Stop();
                Log.Logger.Information($"Parse to Database finished in: {timer.Elapsed.TotalSeconds}");
            }
        }

        // TODO foreach class type [Storage], get the Method {Init} to initialize them all by Reflection.
        public static void InitializeMetadata() => ItemStorage.Init();
    }
}