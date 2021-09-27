using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;
using System.Xml;
using System.Xml.Serialization;

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
            if (stream == null) { return null; }

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
                if (string.IsNullOrEmpty(file)) { continue; }
                files.Add(file);
            }

            return files;
        }


        public static void CreatePaginationLinks(List<PagingLink> links, PagedList<Item> pagedLists, int paginationSize)
        {
            links.Clear();

            PagingLink newPage = new PagingLink(pagedLists.CurrentPage - 1, pagedLists.HasPrevious, "Previous");
            links.Add(newPage);

            for (int pageNumber = 1; pageNumber <= pagedLists.TotalPages; pageNumber++)
            {
                if (pageNumber >= pagedLists.CurrentPage && pageNumber <= pagedLists.CurrentPage + paginationSize)
                {
                    // Return the the first page if the current page is in the last one
                    if (pageNumber == pagedLists.TotalPages)
                    {
                        newPage = new PagingLink(1, true, "1") { Active = pagedLists.CurrentPage == 1 };
                        links.Add(newPage);
                    }

                    // Add new page
                    newPage = new PagingLink(pageNumber, true, pageNumber.ToString()) { Active = pagedLists.CurrentPage == pageNumber };
                    links.Add(newPage);

                    if (pageNumber == pagedLists.CurrentPage + paginationSize)
                    {
                        newPage = new PagingLink(pageNumber, true, "...") { Active = pagedLists.CurrentPage == pageNumber };
                        links.Add(newPage);
                        
                        // Show the last page available
                        newPage = new PagingLink(pagedLists.TotalPages, true, pagedLists.TotalPages.ToString()) { Active = pagedLists.CurrentPage == pagedLists.TotalPages };
                        links.Add(newPage);
                    }
                }
            }

            links.Add(new PagingLink(pagedLists.CurrentPage + 1, pagedLists.HasNext, "Next"));
        }
    }
}
