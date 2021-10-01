using Maplecodex2.Data.Models;
using Maplecodex2.Data.Services;
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
            List<PagingLink> links = new();

            PagingLink newPage = new(pagedItemList.CurrentPage - 1, pagedItemList.HasPrevious, "Previous");
            links.Add(newPage);

            newPage = new(1, pagedItemList.HasPrevious, "First");
            links.Add(newPage);

            for (int pageNumber = 1; pageNumber <= pagedItemList.TotalPages; pageNumber++)
            {
                newPage = new(pageNumber, true, pageNumber.ToString());

                if (pageNumber == pagedItemList.CurrentPage)
                {
                    newPage.Active = pagedItemList.CurrentPage == pageNumber;
                }
                if ( pageNumber >= pagedItemList.CurrentPage && pageNumber <= pagedItemList.CurrentPage + paginationSize)
                {
                    links.Add(newPage);
                }
            }

            // Show the last page available
            newPage = new(pagedItemList.TotalPages, pagedItemList.HasNext, "Last");
            links.Add(newPage);

            newPage = new(pagedItemList.CurrentPage + 1, pagedItemList.HasNext, "Next");
            links.Add(newPage);
            return links;
        }

        public static async Task<PagedList<Item>> GeneratePagedList(string? searchValue, PagingLink link, int pageSize, ItemService service)
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                // Search by ID
                if (char.IsDigit(searchValue, 0) && int.Parse(searchValue) > 0)
                {
                    return await service.GetItemPerPageById(int.Parse(searchValue), link.Page, pageSize);
                }
                // Search by Name
                else if (char.IsLetter(searchValue, 0))
                {
                    return await service.GetItemPerPageByName(searchValue, link.Page, pageSize);
                }
                else
                {
                    return await service.GetItemsPerPage(link.Page, pageSize);
                }
            }
            else
            {
                return await service.GetItemsPerPage(link.Page, pageSize);
            }
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
            Log.Logger.Information(Watch.Elapsed.ToString());
        }
    }
}
