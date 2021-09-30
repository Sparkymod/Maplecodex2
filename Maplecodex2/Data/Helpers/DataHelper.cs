using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;
using Serilog;
using System.Diagnostics;
using System.Xml;

namespace Maplecodex2.Data.Helpers
{
    public static class DataHelper
    {
        /// <summary>
        /// Read an xml file.
        /// </summary>
        /// <param name="filename">File path.</param>
        /// <returns>XmlDocument with the data from the xml.</returns>
        public static XmlDocument ReadDataFromXml(string filename)
        {
            FileStream stream = File.OpenRead(filename);
            if (stream == null) 
            { 
                return null; 
            }

            XmlDocument document = new();
            document.Load(stream);
            return document;
        }

        /// <summary>
        /// Read all files in a directory and subdirectory.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <param name="resource">Resource you want to get all the files from.</param>
        /// <returns>List of folders with their files.</returns>
        public static List<string> GetAllFilesFrom(string path, string resource)
        {
            string delimiter = $"{resource}/*.*";
            List<string> files = new();
            foreach (string file in Directory.GetFiles(path, delimiter, SearchOption.AllDirectories))
            {
                if (string.IsNullOrEmpty(file)) 
                {
                    continue; 
                }
                files.Add(file);
            }
            return files;
        }

        public static List<PagingLink> CreatePaginationLinks(PagedList<Item> pagedItemList, int paginationSize)
        {
            List<PagingLink> links = new ();
            PagingLink newPage = new (pagedItemList.CurrentPage - 1, pagedItemList.HasPrevious, "Previous");

            links.Add(newPage);
            newPage = new (1, pagedItemList.HasPrevious, "First");
            links.Add(newPage);

            for (int pageNumber = 1; pageNumber <= pagedItemList.TotalPages; pageNumber++)
            {
                if (pageNumber >= pagedItemList.CurrentPage - paginationSize && pageNumber <= pagedItemList.CurrentPage + paginationSize)
                {
                    // Add new page
                    newPage = new (pageNumber, true, pageNumber.ToString()) { Active = pagedItemList.CurrentPage == pageNumber };
                    links.Add(newPage);

                    if (pageNumber == pagedItemList.CurrentPage + paginationSize)
                    {
                        newPage = new (pageNumber, false, "...");
                        links.Add(newPage);
                        // Show the last page available
                        newPage = new (pagedItemList.TotalPages, true, "Last") { Active = pagedItemList.CurrentPage == pagedItemList.TotalPages };
                        links.Add(newPage);
                    }
                }
            }
            newPage = new (pagedItemList.CurrentPage + 1, pagedItemList.HasNext, "Next");
            links.Add(newPage);
            return links;
        }
    }

    public static class Timerwatch
    {
        private static Stopwatch? Watch { get; set; }

        public static void Start()
        {
            Watch = new Stopwatch();
            Watch.Start();
        }

        public static void Stop()
        {
            Watch.Stop();
            Log.Logger.Information($"\nTimer finished in: {Watch.Elapsed.Minutes} minutes {Watch.Elapsed.Seconds} seconds.");
        }
    }
}
