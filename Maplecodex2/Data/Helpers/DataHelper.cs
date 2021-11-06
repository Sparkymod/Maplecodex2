using Maplecodex2.Data.Models;
using Maplecodex2.Data.Services;
using Maplecodex2.Database.Core;
using Serilog;
using System.Diagnostics;

namespace Maplecodex2.Data.Helpers
{
    public class DataHelper
    {
        public string LastSearch { get; private set; }

        public DataHelper()
        {
            LastSearch = "";
        }

        public List<PagingLink> CreatePaginationLinks(PagedList<Item> pagedList, int paginationSize)
        {
            List<PagingLink> links = new();

            PagingLink newPage = new(pagedList.CurrentPage - 1, pagedList.HasPrevious, "Previous", "Previous page");
            links.Add(newPage);

            newPage = new(1, pagedList.HasPrevious, "<<", "First page");
            links.Add(newPage);

            for (int pageNumber = 1; pageNumber <= pagedList.TotalPages; pageNumber++)
            {
                newPage = new(pageNumber, true, pageNumber.ToString(), $"Page {pageNumber}");

                if (pageNumber == pagedList.CurrentPage)
                {
                    newPage.Active = pagedList.CurrentPage == pageNumber;
                }
                if (pageNumber >= pagedList.CurrentPage && pageNumber <= pagedList.CurrentPage + paginationSize)
                {
                    links.Add(newPage);
                }
                else if (pageNumber >= pagedList.CurrentPage - paginationSize && pageNumber <= pagedList.CurrentPage && pageNumber + paginationSize >= pagedList.TotalPages)
                {
                    links.Add(newPage);
                }
            }

            // Show the last page available
            newPage = new(pagedList.TotalPages, pagedList.HasNext, ">>", "Last page");
            links.Add(newPage);

            newPage = new(pagedList.CurrentPage + 1, pagedList.HasNext, "Next", "Next page");
            links.Add(newPage);
            return links;
        }

        internal bool VerifyNewSearch(string search)
        {
            if (LastSearch != search)
            {
                LastSearch = search;
                return true;
            }

            return false;
        }

        internal void FirstInitialize(string search)
        {
            LastSearch = search;
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
